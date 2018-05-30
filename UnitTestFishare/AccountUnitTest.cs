using System.Collections.Generic;
using Fishare.Logic;
using Fishare.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFishare
{
    [TestClass]
    public class AccountUnitTest
    {
        private List<User> TestUsers = new List<User>();

        private AccountLogic _accountLogic;

        public AccountUnitTest()
        {
            _accountLogic = new AccountLogic(null);
        }

        [TestInitialize]
        public void createTestContent()
        {
            
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
