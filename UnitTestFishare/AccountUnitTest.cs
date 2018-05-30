using System;
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
            User TestUser = new User
            {
                UserId = 1,
                UserEmail = "d.cornelissen8@gmail.com",
                Password = "Testpassword1",
                FirstName = "Davey",
                LastName = "Cornelissen",
                BirthDay = DateTime.Now,
                PhoneNumber = "0628433115",
                PpPath = "/Test/Profile.PNG"
            };

            TestUsers.Add(TestUser);
        }

        /// <summary>
        /// If it passes the test then an exception is throwed so the check works
        /// </summary>
        #region Exception Tests
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CreatePasswordValidation()
        {
           _accountLogic.CreateUser(TestUsers[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CreateEmailValidation()
        {
            _accountLogic.CreateUser(TestUsers[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void UpdateEmailValidation()
        {
            _accountLogic.UpdateUser(TestUsers[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void UpdatePasswordValidation()
        {
            _accountLogic.UpdateUser(TestUsers[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CheckLogin()
        {
            _accountLogic.CheckLogin(TestUsers[0].UserEmail, TestUsers[0].Password);
        }
        #endregion

        [TestMethod]
        public void CheckCookieInfo()
        {
           User _testUser = _accountLogic.GetCookieInfo(TestUsers[0].UserEmail);

           Assert.IsNotNull(_testUser);
        }

        [TestMethod]
        public void GetUserProfile()
        {
            User _testUser = _accountLogic.GetUserProfile(TestUsers[0].UserId);

            Assert.IsNotNull(_testUser);
        }
    }
}
