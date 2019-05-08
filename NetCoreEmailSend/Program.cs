using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace NetCoreEmailSend
{
    class Program
    {
        static void Main(string[] args)
        {    
            Console.WriteLine("start");

            Console.ReadKey();
            
            var fileStream=new MemoryStream(); 

            var email = new EmailBase(new EmailConfig
            {
                Host = "mysmtpserver",
                Port = 0,
                UserName = "username",
                Password = "password", 
            });

            var result = email.Send(new EmailInfo()
            {
                FromEmail = "whoever@me.com",
                ReceiveEmail = "receiver@me.com",
                Body = "body",
                Subject = "subject",
                Attachments = new System.Collections.Generic.List<Attachment>() { new Attachment(fileStream, "", "") }
            });

            Console.WriteLine("result:" + result);
            Console.ReadKey(); 
        }
    }
}
