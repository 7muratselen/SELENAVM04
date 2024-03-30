
using System.Net;

namespace SELENAVM04.Helpers
{
    public class EmailConnectionInfo
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string MailServer { get; set; }
        public int Port { get; set; } // Eklemeniz gereken özellik
        public bool EnableSsl { get; set; } // Eklemeniz gereken özellik
        public NetworkCredential NetworkCredentials { get; set; }
    }


}
