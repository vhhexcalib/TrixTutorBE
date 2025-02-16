using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
public class ConfirmationOTPBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public ConfirmationOTPBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var expiredOtp = await unitOfWork.ConfirmationOTPRepository.GetExpiredOTPAsync();
                if (expiredOtp != null)
                {
                    await unitOfWork.ConfirmationOTPRepository.DeleteAsync(expiredOtp);
                    await unitOfWork.SaveAsync();
                }

            }

            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken); // Thêm delay để không chạy liên tục
        }
    }
}
