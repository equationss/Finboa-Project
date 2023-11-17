using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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

            var summaries = inbox.Fetch(uids, MessageSummaryItems.Envelope | MessageSummaryItems.UniqueId | MessageSummaryItems.Flags | MessageSummaryItems.BodyStructure);

            var latestSummary = summaries.OrderByDescending(summary => summary.Envelope.Date).FirstOrDefault();

            if (latestSummary == null)
            {
                Console.WriteLine("Error retrieving messages.");
                return null;
            }

            var latestMessage = inbox.GetMessage(latestSummary.UniqueId);
            var otp = ExtractVerificationCode(latestMessage);

            return otp;
        }
    }

    private string ExtractVerificationCode(MimeMessage message)
    {
        if (message == null)
        {
            Console.WriteLine("Message is null.");
            return null;
        }

        // Try to extract the verification code using a regular expression from HTMLBody
        var matchHtml = Regex.Match(message.HtmlBody ?? string.Empty, @"\b\d{6}\b");
        if (matchHtml.Success)
        {
            return matchHtml.Value;
        }

        Console.WriteLine("Verification code not found in the message.");
        return null;
    }
}
