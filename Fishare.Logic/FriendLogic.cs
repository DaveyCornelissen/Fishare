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
                default:
                    _context = new FriendMemoryContext();
                    break;
            }

            _repository = new FriendRepository(_context);
        }

        public List<Friend> GetAcceptedFriends(int userId) => _repository.GetAcceptedFriends(userId);

        public List<Friend> GetRequestingFriends(int userId) => _repository.GetPendingFriends(userId);

        public List<Friend> GetBlockedFriends(int userId) => _repository.GetBlockedFriends(userId);

        public List<User> GetSearchResult(int userId, string searchObject)
        {
            string databaseValue = "";
            if (!String.IsNullOrEmpty(searchObject))
                databaseValue = searchObject + "%";

            return _repository.GetSearchResult(userId, databaseValue);
        }

        public List<int> GetFriendIds(int userId) => _repository.GetAllFriendsId(userId);

        public bool AcceptFriendRequest(int userId, int friendId) => _repository.AcceptFriendRequest(userId, friendId);

        public bool SendFriendRequest(int userId, int friendId, int actionId = 0)
        {
            int _userOneId = (userId < friendId) ? userId : friendId;
            int _UserTwoId = (userId > friendId) ? userId : friendId;

            actionId = (actionId != 0) ? actionId : userId;

            return _repository.SendFriendRequest(_userOneId, _UserTwoId, actionId);
        }

        public bool RemoveFriend(int userId, int friendId) => _repository.RemoveFriend(userId, friendId);

        public bool DeclineFriendRequest(int userId, int friendId) =>
            _repository.DeclineFriendsRequest(userId, friendId);

        public bool BlockFriend(int userId, int friendId) => _repository.BlockFriend(userId, friendId);

        public bool UnblockFriend(int userId, int friendId) => _repository.UnblockFriend(userId, friendId);
    }
}
