using AutoMapper;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.SystemAccountWalletDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SystemAccountWalletService : ISystemAccountWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SystemAccountWalletService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> GetSystemAccountWallet(CurrentUserObject currentUserObject)
        {
            var wallets = await _unitOfWork.SystemAccountWallet.GetByIdAsync(currentUserObject.AccountId);
            DTOs.SystemAccountWalletDTO.SystemAccountWalletDTO wallet = new DTOs.SystemAccountWalletDTO.SystemAccountWalletDTO()
            {
                Balance = wallets.Balance,
                LastChangeAmount = wallets.LastChangeAmount,
                LastChangeDate = wallets.LastChangeDate
            };
            return Result.SuccessWithObject(wallet);
        }       
    }
}
