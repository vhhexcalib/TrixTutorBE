﻿using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.BankDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BankInformationService : IBankInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankInformationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> UpdateBankInformation(CurrentUserObject currentUserObject, UpdateBankInformationDTO updateBankInformationDTO)
        {
            var bankInformation = await _unitOfWork.BankInformationRepository.GetByIdAsync(currentUserObject.AccountId);
            if(bankInformation == null)
            {
                return Result.Failure(BankInformationErrors.FailFindExistBankInformation);
            }
            bankInformation.BankNumber = updateBankInformationDTO.BankNumber;
            bankInformation.BankName = updateBankInformationDTO.BankName;
            bankInformation.OwnerName = updateBankInformationDTO.OwnerName;
            await _unitOfWork.BankInformationRepository.UpdateAsync(bankInformation);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(BankInformationErrors.FailUpdateBankInformation);
            }
        }
    }
}
