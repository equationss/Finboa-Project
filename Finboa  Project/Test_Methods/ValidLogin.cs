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
    public class ValidLogin : Base
    {
        public TestContext TestContext { get; set; }


        LoginObjects Object = new LoginObjects();

        [TestMethod]
        public void Valid_Login()
        {

            Driver("FireFox");
            Object.login("abdul@finboa.com", "Password@6");
            Close();

        }
    }
}
