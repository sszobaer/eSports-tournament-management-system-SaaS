using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DAL.Repositories
{
    public class EmailRepo : IEmail
    {
        public async Task SendAsync(string to, string subject, string body)
        {
            var message = new MailMessage
            {
                From = new MailAddress("no-reply@etms.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(to);

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(
                    "eduwavelms@gmail.com",
                    "lgcjognxwigrkoxm"
                ),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}
