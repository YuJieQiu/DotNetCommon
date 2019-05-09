using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace NetCoreEmailSend
{
    public class EmailInfo
    { 
        /// <summary>
        /// 邮箱主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 发件内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 是否包含html内容
        /// </summary>
        public bool IsHtml { get; set; }

        /// <summary>
        /// 收件人邮箱地址
        /// </summary>
        public string ReceiveEmail { get; set; }

        /// <summary>
        /// 收件人名称
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 发件人邮箱地址
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string FromEmailName { get; set; }

        /// <summary>
        /// 抄送人邮箱地址集合
        /// </summary>
        public List<string> CCEmailList { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public List<Attachment> Attachments { get; set; }

    }


    public class EmailConfig
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public bool EnableSsl { get; set; }
 
        public string Password { get; set; }
         
        public string UserName { get; set; }

        public bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// 发送邮件超时时间(秒)  
        /// Default:30
        /// </summary>
        public int TimeoutMilliSecond { get; set; } = 30;

    }
}
