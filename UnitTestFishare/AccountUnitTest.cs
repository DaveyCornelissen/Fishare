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
                Password = "12345",
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

        /// Tests if the password is valid if passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CreatePasswordValidation()
        {
            User _testUserPassword = new User
            {
                UserId = 1,
                UserEmail = "Test.Password@gmail.com",
                Password = "Test",
                FirstName = "Davey",
                LastName = "Cornelissen",
                BirthDay = DateTime.Now,
                PhoneNumber = "0628433115",
                PpPath = "/Test/Profile.PNG"
            };

            _accountLogic.CreateUser(_testUserPassword);
        }

        /// Tests if the Email already exist if passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CreateEmailValidation()
        {
            _accountLogic.CreateUser(TestUsers[0]);
        }

        /// Tests if the Email already exist if passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void UpdateEmailValidation()
        {
            _accountLogic.UpdateUser(TestUsers[0]);
        }

        /// Tests if the Email already exist if passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void UpdatePasswordValidation()
        {
            User _testUserPassword = new User
            {
                UserId = 1,
                UserEmail = "d.cornelissen8@gmail.com",
                Password = "Test",
                FirstName = "Davey",
                LastName = "Cornelissen",
                BirthDay = DateTime.Now,
                PhoneNumber = "0628433115",
                PpPath = "/Test/Profile.PNG"
            };

            _accountLogic.UpdateUser(_testUserPassword);
        }

        /// Tests if the Email and the password matches to an existing user account if passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void CheckLogin()
        {
            User _testNotExistingUser = new User
            {
                UserId = 1,
                UserEmail = "f.FakeUser@gmail.com",
                Password = "FakepassWord12",
                FirstName = "Davey",
                LastName = "Cornelissen",
                BirthDay = DateTime.Now,
                PhoneNumber = "0628433115",
                PpPath = "/Test/Profile.PNG"
            };

            _accountLogic.CheckLogin(_testNotExistingUser.UserEmail, _testNotExistingUser.Password);
        }

        /// Tests if all the required parameters ar not null if so it passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void EmptyParametersCreateUser()
        {
            User _testUserEmpty = new User();

            _accountLogic.CreateUser(_testUserEmpty);
        }

        /// Tests if all the required parameters ar not null if so it passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void EmptyParametersGetUser()
        {
            int UserId = 0;

            _accountLogic.GetUserProfile(UserId);
        }

        /// Tests if all the required parameters ar not null if so it passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void EmptyParametersUpdateUser()
        {
            User _testUserEmpty = new User
            {
                UserId = 1,
                UserEmail = "d.cornelissen8@gmail.com",
                Password = "Testpassword1",
                FirstName = "",
                LastName = "Cornelissen",
                BirthDay = DateTime.Now,
                PhoneNumber = "0628433115",
                PpPath = "/Test/Profile.PNG"
            };

            _accountLogic.UpdateUser(_testUserEmpty);
        }

        /// Tests if all the required parameters ar not null if so it passes then an exception is throwed
        [TestMethod]
        [ExpectedException(typeof(ExceptionHandler))]
        public void EmptyParametersCheckLogin()
        {
            User _testUserEmpty = new User
            {
                UserId = 1,
                UserEmail = "",
                Password = "Testpassword1",
                FirstName = "",
                LastName = "Cornelissen",
                BirthDay = DateTime.Now,
                PhoneNumber = "0628433115",
                PpPath = "/Test/Profile.PNG"
            };

            _accountLogic.CheckLogin(_testUserEmpty.UserEmail, _testUserEmpty.Password);
        }
        #endregion

        /// Get the cookieinfo and check if the return value is not null
        [TestMethod]
        public void CheckCookieInfo()
        {
           User _testUser = _accountLogic.GetCookieInfo(TestUsers[0].UserEmail);

           Assert.IsNotNull(_testUser);
        }

        /// Get the User profile and check if the return value is not null
        [TestMethod]
        public void GetUserProfile()
        {
            User _testUser = _accountLogic.GetUserProfile(TestUsers[0].UserId);

            Assert.IsNotNull(_testUser);
        }
    }
}
