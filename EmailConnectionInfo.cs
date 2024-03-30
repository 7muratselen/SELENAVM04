using System.Net;

internal class EmailConnectionInfo
{
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public string MailServer { get; set; }
    public string EmailSubject { get; set; }
    public NetworkCredential NetworkCredentials { get; set; }
}