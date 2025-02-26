using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        ISystemAccountRepository SystemAccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        IConfirmationOTPRepository ConfirmationOTPRepository { get; }
        ITutorCategoryRepository TutorCategoryRepository { get; }
        ITutorContactRepository TutorContactRepository { get; }
        ITutorInformationRepository TutorInformationRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IBankInformationRepository BankInformationRepository { get; }
        ICertificateRepository CertificateRepository { get; }
        IWalletRepository WalletRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        ITransactionHistory TransactionHistory { get; }
        ISystemAccountWalletRepository SystemAccountWallet { get; }


        Task<string> SaveAsync();
    }
}
