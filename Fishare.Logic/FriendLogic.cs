using System;
using System.Collections.Generic;
using System.Text;
using Fishare.DAL;
using Fishare.DAL.Memory;
using Fishare.DAL.SQL;
using Fishare.Model;
using Fishare.Repository;
using Fishare.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace Fishare.Logic
{
    public class FriendLogic
    {
        private IFriendsRepository _repository;

        private IFriendsRepository _context;

        public FriendLogic(IConfiguration config)
        {
            ContextReader contextReader = new ContextReader(config);

            switch (contextReader.Context)
            {
                case "MSSQL":
                    _context = new FriendSQLContext(contextReader.ConnectionString);
                    break;
                case "MEMORY":
                    _context = new FriendMemoryContext();
                    break;
                default: throw new NotImplementedException();
            }

            _repository = new FriendRepository(_context);
        }

        public List<Friend> GetAcceptedFriends(int UserId) => _repository.GetAcceptedFriends(UserId);

        public List<Friend> GetPendingFriends(int UserId) => _repository.GetPendingFriends(UserId);

        public List<Friend> GetSearchResult(string SearchObject)
        {
            string DatabaseValue = "";
            if (String.IsNullOrEmpty(SearchObject))
                DatabaseValue = SearchObject + "%";

            return _repository.GetSearchResult(DatabaseValue);
        }
    }
}
