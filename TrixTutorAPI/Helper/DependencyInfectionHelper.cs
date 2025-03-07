using Azure.Storage.Blobs;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;

public static class DependencyInjectionHelper
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // BlobServiceClient
        var azureConnectionString = configuration.GetSection("AzureBlobStorage")["ConnectionString"];
        services.AddSingleton(new BlobServiceClient(azureConnectionString));

        // Register the container name from configuration
        var containerName = configuration.GetValue<string>("AzureBlobStorage:ContainerName");
        services.AddSingleton(containerName);

        // Register repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
        services.AddScoped<IConfirmationOTPRepository, ConfirmationOTPRepository>();
        services.AddScoped<ICertFileRepository, CertFileRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();


        // Register services
        services.AddScoped<ISystemAccountService, SystemAccountService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IConfirmationOTPService, ConfirmationOTPService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<ICertFileService, CertFileService>();
        services.AddScoped<ITutorInformationService, TutorInformationService>();
        services.AddScoped<ITutorCategoryService, TutorCategoryService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IBankInformationService, BankInformationService>();
        services.AddScoped<IFeedbackService, FeedbackService>();
        services.AddScoped<ICoursesService, CoursesService>();
        services.AddScoped<ITutorContactService, TutorContactService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
        services.AddScoped<IPayOsService, PayOsService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ISystemAccountWalletService, SystemAccountWalletService>();
        services.AddScoped<ILearningScheduleService, LearningScheduleService>();
        services.AddScoped<ITeachingScheduleService, TeachingScheduleService>();
        services.AddScoped<ILearningHistoryService, LearningHistoryService>();
        services.AddScoped<ITeachingHistoryService, TeachingHistoryService>();


        return services;
    }
}
