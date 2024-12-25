using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork _unitOfWork;
        public EmailService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this.configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        public async Task SendEmail(string receptor)
        {
            var email = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            var smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email, password)
            };
            string subject = "TRIX TUTOR REGISTERING CONFIRMATION EMAIL";
            string body = RandomGenerateOTP(); 
            string emailBody = GenerateEmailBody(receptor, body);
            var message = new MailMessage(email, receptor, subject, emailBody)
            {
                IsBodyHtml = true
            };
            await smtpClient.SendMailAsync(message);
        }

        private string GenerateEmailBody(string receptor, string body)
        {
            StringBuilder emailMessage = new StringBuilder();
            emailMessage.AppendLine("<html>");
            emailMessage.AppendLine("<body>");
            emailMessage.AppendLine($"<p>Hi {receptor},</p>");
            emailMessage.AppendLine("<p>Thank you for registering in Trix Tutor. Please verify your email address using the code below to complete your account registration.</p>");
            emailMessage.AppendLine($"<h2>Code: {body}</h2>");
            emailMessage.AppendLine("<p>This code will be deactive in five minutes.</p>");
            emailMessage.AppendLine("<p>If you didn't register for Trix Tutor, please ignore this email.</p>");
            emailMessage.AppendLine("<br>");
            emailMessage.AppendLine("<p>Best regards,</p>");
            emailMessage.AppendLine("<p><strong>Trix Tutor</strong></p>");
            emailMessage.AppendLine("</body>");
            emailMessage.AppendLine("</html>");

            return emailMessage.ToString();
        }

        private string RandomGenerateOTP()
        {
            Random rnd = new Random();
            int newOtp = rnd.Next(10000000, 99999999);
            string otp = newOtp.ToString();
            return otp;
        }
    }
}