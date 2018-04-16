using System;
using System.Collections.Generic;
using System.Text;
using Fishare.DAL.Interface;
using Fishare.Model;
using Fishare.Repository;
using Fishare.ViewModels;


namespace Fishare.Logic
{

    public class AccountLogic 
    {
        //        private IAccountContext Repository;
        //
        //        public AccountLogic(IAccountContext repository)
        //        {
        //            Repository = repository;
        //        }
        //
        //        public bool UserExist(LoginViewModel Entity) => Repository.Exist(Entity);
        //
        //        public User GetInfoUser(LoginViewModel Entity) => Repository.GetUserInfo(Entity);



       private string Context;
       
       public AccountLogic(string _context)
       {
           _context = Context;
       }

        public bool UserExist(LoginViewModel Entity)
        {
            AccountRepository Account = new AccountRepository(Context);
            return Account.Context().Exist(Entity);
        } 
        
               // public User GetInfoUser(LoginViewModel Entity) => Repository.GetUserInfo(Entity);
    }
}
