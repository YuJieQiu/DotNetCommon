using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace NetCoreEmailSend
{
    public class EmailBase
    {
        private EmailConfig emailConfig;

        public SmtpClient SmtpClient { get; set; }

        public EmailBase(EmailConfig  config)
        {
            this.emailConfig = config;

            InfoSmtpClient();
        }


        private void InfoSmtpClient()
        {
            SmtpClient = new SmtpClient()
            {
                Host = emailConfig.Host,
                Port = emailConfig.Port,
                EnableSsl = emailConfig.EnableSsl,
                UseDefaultCredentials = emailConfig.UseDefaultCredentials,
                Timeout = emailConfig.TimeoutMilliSecond * 1000,
                Credentials = new NetworkCredential(emailConfig.UserName, emailConfig.Password)
            };
        }

        //邮件发送
        public bool Send(EmailInfo info)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    if (SmtpClient == null)
                        InfoSmtpClient();

                    mailMessage.From = new MailAddress(info.FromEmail);
                    mailMessage.To.Add(info.ReceiveEmail);
                    mailMessage.Body = info.Body;
                    mailMessage.Subject = info.Subject; 


                    if (info.CCEmailList!=null&&info.CCEmailList.Count>0) 
                        foreach (var item in info.CCEmailList)
                            mailMessage.CC.Add(item);

                    if (info.Attachments != null && info.Attachments.Count > 0)
                        foreach (var item in info.Attachments)
                            mailMessage.Attachments.Add(item);

                    this.SmtpClient.Send(mailMessage);
                }

                return true;//ok
            }
            catch (Exception e)
            {
                return false; //false
            }
        } 
    }
}
