using Finboa__Project.Test_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finboa__Project.Test_Methods
{
    [TestClass]
    public class OnlyPass : Base
    {
        public TestContext TestContext { get; set; }


        LoginObjects Object = new LoginObjects();

        [TestMethod]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Credentials.xml", "OnlyPass", DataAccessMethod.Sequential)]

        public void Only_Email()
        {
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            Driver("FireFox");
            Object.login(username, password);
            Object.EmptyFieldsValidate();
            Close();

        }
    }
}
