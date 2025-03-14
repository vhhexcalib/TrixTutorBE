﻿using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Service.Common;
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
            string encodedotp = await HassPassword.HassPass(body);
            string emailBody = GenerateEmailBody(receptor, body);
            var message = new MailMessage(email, receptor, subject, emailBody)
            {
                IsBodyHtml = true
            };
            var otp = new ConfirmationOTP() { Email = receptor, OTP = encodedotp, CreatedAt = DateTime.Now };
            await _unitOfWork.ConfirmationOTPRepository.AddAsync(otp);
            await _unitOfWork.SaveAsync();
            await smtpClient.SendMailAsync(message);
        }

        private string GenerateEmailBody(string receptor, string body)
        {
            StringBuilder emailMessage = new StringBuilder();
            emailMessage.AppendLine("<html>");
            emailMessage.AppendLine("<body>");
            emailMessage.AppendLine($"<p>Chào {receptor},</p>");
            emailMessage.AppendLine("<p>Cảm ơn bạn đã đăng ký Trix Tutor. Vui lòng xác thực địa chỉ email của bạn bằng mã dưới đây để hoàn tất việc đăng ký tài khoản.</p>");
            emailMessage.AppendLine($"<h2>Mã: {body}</h2>");
            emailMessage.AppendLine("<p>Mã này sẽ hết hiệu lực sau 1 phút.</p>");
            emailMessage.AppendLine("<p>Nếu bạn không đăng ký Trix Tutor, vui lòng bỏ qua email này.</p>");
            emailMessage.AppendLine("<br>");
            emailMessage.AppendLine("<p>Trân trọng,</p>");
            emailMessage.AppendLine("<p><strong>Trix Tutor</strong></p>");
            emailMessage.AppendLine("</body>");
            emailMessage.AppendLine("</html>");

            return emailMessage.ToString();
        }

        private string RandomGenerateOTP()
        {
            Random rnd = new Random();
            int newOtp = rnd.Next(100000, 999999);
            string otp = newOtp.ToString();
            return otp;
        }
    }
}