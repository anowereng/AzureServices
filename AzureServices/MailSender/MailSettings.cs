using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    static class MailSettings
    {
        public static string FromEmailAddress => "[SendGrid_Email]";
        public static string FromName => "anower";
        public static string SendGridAPIKey => "[SendGrid_API_KEY]"; // copy from google cloud credientials file . 
    }
}
