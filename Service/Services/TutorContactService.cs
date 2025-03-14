﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorContactDTO;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class TutorContactService : ITutorContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> CreateContactInformation (CurrentUserObject currentUserObject, CreateContactDTO createContactDTO)
        {
            var createdContact = await _unitOfWork.TutorContactRepository.GetByIdAsync(currentUserObject.AccountId);
            if(createdContact != null)
            {
                return Result.Failure(TutorContactErrors.ExistedContact);
            }
            var tutorContact = new TutorContact 
            {
                TutorId = currentUserObject.AccountId,
                FacebookURL = createContactDTO.FacebookURL,
                InstagramURL = createContactDTO.InstagramURL,
                LinkedIn = createContactDTO.LinkedIn,
                XURL = createContactDTO.XURL
            };
            await _unitOfWork.TutorContactRepository.AddAsync(tutorContact);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(TutorContactErrors.FailCreatingContact);
            }
        }
        public async Task<dynamic> GetContactById(CurrentUserObject currentUserObject)
        {
            var contact = await _unitOfWork.TutorContactRepository.GetByIdAsync (currentUserObject.AccountId);
            if (contact == null)
            {
                return Result.Failure(TutorContactErrors.NotFoundContact);
            }
            var contactDTO = _mapper.Map<ContactDTO>(contact);
            return Result.SuccessWithObject(contactDTO);
        }
        public async Task<dynamic> UpdateContactInformation(CurrentUserObject currentUserObject, CreateContactDTO createContactDTO)
        {
            var createdContact = await _unitOfWork.TutorContactRepository.GetByIdAsync(currentUserObject.AccountId);
            if (createdContact == null)
            {
                return Result.Failure(TutorContactErrors.NotFoundContact);
            }
            createdContact.XURL = createContactDTO.XURL;
            createdContact.FacebookURL = createContactDTO.FacebookURL;
            createdContact.InstagramURL = createContactDTO.InstagramURL; 
            createdContact.LinkedIn = createContactDTO.LinkedIn;
            await _unitOfWork.TutorContactRepository.UpdateAsync(createdContact);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(TutorContactErrors.FailUpdatingContact);
            }
        }
    }
}
