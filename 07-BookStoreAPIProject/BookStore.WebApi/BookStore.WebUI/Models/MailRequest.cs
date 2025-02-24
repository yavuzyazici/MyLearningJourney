using MimeKit;

namespace BookStore.WebUI.Models
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string SenderAddress { get; set; }
        public string SenderPassword { get; set; }
        public string RecieverAddress { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
    }
}
