using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICertFileService _certFileService;

        public CertificateService(IUnitOfWork unitOfWork, IMapper mapper, ICertFileService certFileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _certFileService = certFileService;
        }
        public async Task<dynamic> UploadCertificatesAsync(CertificateDTO certificateDTO, CurrentUserObject currentUserObject)
        {
            var newCertificates = new List<Certificate>();
            var errors = new List<string>();

            foreach (var attachmentFile in certificateDTO.AttachmentFiles)
            {
                // Validate file size
                if (attachmentFile.Length > 500 * 1024 * 1024)
                {
                    return Result.Failure(CertificateErrors.OverLimitSize);
                }

                try
                {
                    // Save certificate file
                    var certFileUrl = await _certFileService.SaveFile("certificate", attachmentFile);
                    // Create certificate entity
                    var newCert = new Certificate
                    {
                        Certification = certFileUrl,
                        TutorId = currentUserObject.AccountId,
                        Verified = false,
                        UploadedAt = DateOnly.FromDateTime(DateTime.Now)
                    };

                    newCertificates.Add(newCert);
                }
                catch (Exception ex)
                {
                    errors.Add($"Failed to process file {attachmentFile.FileName}: {ex.Message}");
                }
            }

            // Save all valid certificates
            if (newCertificates.Any())
            {
                try
                {
                    await _unitOfWork.CertificateRepository.AddRangeAsync(newCertificates);
                    var saveResult = await _unitOfWork.SaveAsync();

                    if (saveResult != "Save Change Success")
                    {
                        return Result.Failure(CertificateErrors.SaveUploadFail);
                    }
                    else return Result.Success();
                }
                catch (Exception ex)
                {
                    return Result.Failure(CertificateErrors.UploadFail);
                }
            }

            return Result.Failure(CertificateErrors.UploadFail);
        }
    }
}
