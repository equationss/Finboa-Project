using Finboa__Project.Test_Objects;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Finboa__Project.Test_Methods
{
    [TestClass]
    public class ValidLogin : Base
    {
        public TestContext TestContext { get; set; }


        LoginObjects Object = new LoginObjects();

        [TestMethod]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Credentials.xml", "Valid", DataAccessMethod.Sequential)]

        public void Valid_Login()
        {
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            Driver("FireFox");
            Object.login(username, password);
            //Close();

            // Retrieve OTP from Gmail
            string host = "imap.gmail.com";
            int port = 993;
            string email = "abdul@finboa.com";
            string gmailPassword = "$Pak35tan$2023";

            var otpProcessor = new OtpProcessor();
            var otp = otpProcessor.FetchOTPFromEmail(host, port, email, gmailPassword);

            // Print or use the OTP as needed
            if (!string.IsNullOrEmpty(otp))
            {
                Console.WriteLine($"OTP: {otp}");
            }
            else
            {
                Console.WriteLine("No OTP found.");
            }

            Thread.Sleep(10000);
            // Close the browser
            Close();
        }
    }
}
