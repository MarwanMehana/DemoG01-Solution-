using System.Net;
using System.Net.Mail;
namespace DemoG01.Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("marwanmehana14@gamil.com", "njkgyufkcbruvaww");
            client.Send("(marwanmehana14@gamil.com)", email.To, email.Subject, email.Body);
        }
    }
}
