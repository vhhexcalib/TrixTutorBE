using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;

namespace TrixTutorAPI.Helper
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Register BlobServiceClient
            services.AddSingleton(_ =>
            {
                var connectionString = configuration["AzureBlobStorage:ConnectionString"];
                return new BlobServiceClient(connectionString);
            });

            //repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
            services.AddScoped<IConfirmationOTPRepository, ConfirmationOTPRepository>();

            //service
            services.AddScoped<ISystemAccountService, SystemAccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IConfirmationOTPService, ConfirmationOTPService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }


    }
}
