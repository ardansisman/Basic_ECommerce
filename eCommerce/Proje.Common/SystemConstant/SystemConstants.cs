using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.SystemConstant
{
    public class SystemConstants
    {
        public const string SmtpCredentialUserName = "ardann.68@outlook.com";
        public const string SmtpCredentialPassword = "Mersus34.";
        public const string smtpClient = "smtp-mail.outlook.com";
        public const string displayName = "Mersus Destek";
        public const int smtpPort = 587;
        public const string webApiBaseAddress = "http://localhost:5006/";

        public enum ERRORS
        {
            SUCCESSFUL=1,
            NOTFOUND=2,
            SYSTEMERROR=3

        }

        public static Dictionary<int, string> SystemErrors = new Dictionary<int, string>()
        {
            {1,"İşlem Başarılı" },
            {2,"Aranan Bulunamadı" },
            {3,"Sistem Hatası" }
        };
    }
}
