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

        /// <summary>
        /// The friend constructor with a config parameter who checks which context is used.
        /// </summary>
        /// <param name="config"></param>
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

        /// <summary>
        /// Get a list of all accepted friends by the userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Friend> GetAcceptedFriends(int userId) => _repository.GetAcceptedFriends(userId);

        /// <summary>
        /// Get a list of all Pending friends by the userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Friend> GetRequestingFriends(int userId) => _repository.GetPendingFriends(userId);

        /// <summary>
        /// Get a list of all Blocked friends by the userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Friend> GetBlockedFriends(int userId) => _repository.GetBlockedFriends(userId);

        /// <summary>
        /// Get a list of all the users who has a charactar thats equal to the searchObject
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<User> GetSearchResult(int userId, string searchObject)
        {
            string databaseValue = "";
            if (!String.IsNullOrEmpty(searchObject))
                databaseValue = searchObject + "%";

            return _repository.GetSearchResult(userId, databaseValue);
        }

        /// <summary>
        /// Get all the id's from the users friend
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetFriendIds(int userId) => _repository.GetAllFriendsId(userId);

        /// <summary>
        /// Accept the friend request
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        public bool AcceptFriendRequest(int userId, int friendId) => _repository.AcceptFriendRequest(userId, friendId);

        /// <summary>
        /// Send a friend request
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public bool SendFriendRequest(int userId, int friendId, int actionId = 0)
        {
            int _userOneId = (userId < friendId) ? userId : friendId;
            int _UserTwoId = (userId > friendId) ? userId : friendId;

            actionId = (actionId != 0) ? actionId : userId;

            return _repository.SendFriendRequest(_userOneId, _UserTwoId, actionId);
        }

        /// <summary>
        /// Remove a friend
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        public bool RemoveFriend(int userId, int friendId) => _repository.RemoveFriend(userId, friendId);

        /// <summary>
        /// Decline a friend request
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        public bool DeclineFriendRequest(int userId, int friendId) =>
            _repository.DeclineFriendsRequest(userId, friendId);

        /// <summary>
        /// Block a friend
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        public bool BlockFriend(int userId, int friendId) => _repository.BlockFriend(userId, friendId);

        /// <summary>
        /// Unblock a friend
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        public bool UnblockFriend(int userId, int friendId) => _repository.UnblockFriend(userId, friendId);
    }
}
