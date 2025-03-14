﻿using Service.DTOs.AccountDTO;
using Service.DTOs.TransactionHistoryDTO;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITransactionHistoryService
    {
        Task<PagedResult<TransactionDTO>> GetAllStudentTransactionAsync(CurrentUserObject currentUserObject);
        Task<dynamic> CreateTransactionAsync(int accountid, string PaymentId);
    }
}
