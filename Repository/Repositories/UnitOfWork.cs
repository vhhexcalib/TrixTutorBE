using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrixTutorDBContext _context;
        public IAccountRepository AccountRepository { get; set; }
        public ISystemAccountRepository SystemAccountRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IConfirmationOTPRepository ConfirmationOTPRepository { get; set; }
        public ITutorCategoryRepository TutorCategoryRepository { get; set; }
        public ITutorContactRepository TutorContactRepository { get; set; }
        public ITutorInformationRepository TutorInformationRepository { get; set; }
        public IFeedbackRepository FeedbackRepository { get; set; }
        public IBankInformationRepository BankInformationRepository { get; set; }
        public ICertificateRepository CertificateRepository { get; set; }
        public IWalletRepository WalletRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }
        public ITransactionHistoryRepository TransactionHistoryRepository { get; set; }
        public ISystemAccountWalletRepository SystemAccountWalletRepository { get; set; }
        public ILearningHistoryRepository LearningHistoryRepository { get; set; }
        public ILearningScheduleRepository LearningScheduleRepository { get; set; }
        public ICoursesRepository CoursesRepository { get; set; }
        public ITeachingScheduleRepository TeachingScheduleRepository { get; set; }
        public ITeachingHistoryRepository TeachingHistoryRepository { get; set; }
        public ITeachingDateRepository TeachingDateRepository { get; set; }
        public ITeachingTimeRepository TeachingTimeRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }



        public UnitOfWork(TrixTutorDBContext context)
        {
            _context = context;
            AccountRepository = new AccountRepository(_context);
            SystemAccountRepository = new SystemAccountRepository(_context);
            RoleRepository = new RoleRepository(_context);
            ConfirmationOTPRepository = new ConfirmationOTPRepository(_context);
            TutorCategoryRepository = new TutorCategoryRepository(_context);
            TutorContactRepository = new TutorContactRepository(_context);
            TutorInformationRepository = new TutorInformationRepository(_context);
            FeedbackRepository = new FeedbackRepository(_context);
            BankInformationRepository = new BankInformationRepository(_context);
            CertificateRepository = new CertificateRepository(_context);
            WalletRepository = new WalletRepository(_context);
            PaymentRepository = new PaymentRepository(_context);
            TransactionHistoryRepository = new TransactionHistoryRepository(_context);
            SystemAccountWalletRepository = new SystemAccountWalletRepository(_context);
            LearningHistoryRepository = new LearningHistoryRepository(_context);
            LearningScheduleRepository = new LearningScheduleRepository(_context);
            CoursesRepository = new CoursesRepository(_context);
            TeachingScheduleRepository = new TeachingScheduleRepository(_context);
            TeachingHistoryRepository = new TeachingHistoryRepository(_context);
            TeachingDateRepository = new TeachingDateRepository(_context);
            TeachingTimeRepository = new TeachingTimeRepository(_context);
            OrderRepository = new OrderRepository(_context);


        }
        public async Task<string> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return "Save Change Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }   
        }
    }
}
