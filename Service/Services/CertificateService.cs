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
        public async Task<dynamic> UploadCertificateAsync(CertificateDTO certificateDTO, CurrentUserObject currentUserObject)
        {
            var check = await _unitOfWork.CertificateRepository.CheckExistCertificateByTutorID(currentUserObject.AccountId);
            if (!check)
            {
                if (certificateDTO.Certification.Length > 500 * 1024 * 1024)
                {
                    return "Certificate file size exceeds the 500MB limit";
                }
                var courseFileUrl = await _certFileService.SaveFile(certificateDTO.AttachmentFile);
                var newCert = new Certificate
                {
                    Certification = courseFileUrl,
                    TutorId = currentUserObject.AccountId,
                    Verified = false
                };
                await _unitOfWork.CertificateRepository.AddAsync(newCert);
                await _unitOfWork.SaveAsync();
                return Result.Success();
            }
            else { return Result.Failure(CertificateErrors.ExistedCertificate);  }
        }
    }
}
