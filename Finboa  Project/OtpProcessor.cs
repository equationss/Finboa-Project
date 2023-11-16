using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Linq;

public class OtpProcessor
{
    public string FetchOTPFromEmail(string host, int port, string email, string password)
    {
        using (var client = new ImapClient())
        {
            client.Connect(host, port, true);
            client.Authenticate(email, password);

            var inbox = client.Inbox;
            inbox.Open(MailKit.FolderAccess.ReadOnly);

            var query = SearchQuery.NotSeen;
            var uids = inbox.Search(query);

            if (!uids.Any())
            {
                Console.WriteLine("No new messages.");
                return null;
            }

            var message = inbox.GetMessage(uids.First());
            var otp = message.TextBody;

            return otp;
        }
    }
}
