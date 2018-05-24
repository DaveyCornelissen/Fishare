using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.DAL;
using Fishare.Repository.Interface;

namespace Fishare.DAL.Memory
{
    public class AccountMemoryContext : IAccountRepository
    {
        List<User> AllUsers = new List<User>();
        List<Post> AllPosts = new List<Post>();

        public AccountMemoryContext()
        {
            AllUsers.Add(new User
                {
                    UserId = 1,
                    UserEmail = "d.cornelissen8@gmail.com",
                    Password = "12345",
                    FirstName = "Davey",
                    LastName = "Cornelissen",
                    BirthDay = DateTime.Now,
                    PhoneNumber = "0628433115",
                    Posts = AllPosts,
                    PpPath = "/Test/Profile.PNG"
                });

            AllPosts.Add(new Post {UserId = 1, DateTime = DateTime.Now, Title = "Test"});
        }

        public User GetUserInfo(User entity)
        {
            User user = AllUsers.Find(u => u.UserEmail == entity.UserEmail && u.Password == entity.Password);

            return user;
        }

        public bool Update(User entity)
        {
            User user = AllUsers.Find(u => u.UserId == entity.UserId);

            if (user != null)
            {
                user.UserEmail = entity.UserEmail;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Password = entity.Password;
                user.BirthDay = entity.BirthDay;
                user.Bio = entity.Bio;
                user.PhoneNumber = entity.PhoneNumber;
                return true;
            }

            return false;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string email, string password)
        {
            User user = AllUsers.Find(u => u.UserEmail == email && u.Password == password);

            return user != null;
        }

        public bool Exist(string email)
        {
            User user = AllUsers.Find(u => u.UserEmail == email);

            return user != null;
        }

        public User GetCookieInfo(string email)
        {
            User user = AllUsers.Find(u => u.UserEmail == email);

            return user;
        }

        public User Read(int Id)
        {
            User user = AllUsers.Find(u => u.UserId == Id);

            return user;
        }

        public bool Create(User entity)
        {
            if (entity != null)
            {
                User _newUser = new User
                {
                    UserEmail = entity.UserEmail,
                    Password = entity.Password,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    BirthDay = entity.BirthDay,
                    PhoneNumber = entity.PhoneNumber,
                    PpPath = entity.PpPath
                };

                AllUsers.Add(_newUser);

                return true;
            }

            return false;
        }
    }
}
