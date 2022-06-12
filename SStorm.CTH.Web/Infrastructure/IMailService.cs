using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SStorm.CTH.Web
{
    public interface IMailService
    {
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="to">semi-colon seperated emails</param>
        /// <param name="title">email title</param>
        /// <param name="Body">email content</param>
        void SendEmail(string[] to, string title, string Body ,params Attachment[] Attachment);

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="to">semi-colon seperated emails</param>
        /// <param name="title">email title</param>
        /// <param name="Body">email content</param>
        void SendEmail(string to, string title, string Body, params Attachment[] Attachment);

    }
}
