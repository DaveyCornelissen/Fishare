using System.Collections.Generic;
using Fishare.Model;
using Fishare.Repository;
using Fishare.Repository.Interface;

namespace Fishare.Logic
{
    public class FriendRepository : Repository<Friend>, IFriendsRepository
    {
        private IFriendsRepository _context;

        public FriendRepository(IFriendsRepository context) : base(context)
        {
            _context = context;
        }

        public bool Create(Friend entity)
        {
            throw new System.NotImplementedException();
        }

        public Friend Read(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Friend entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete()
        {
            throw new System.NotImplementedException();
        }


        public List<Friend> GetAcceptedFriends(int userId)
        {
            return _context.GetAcceptedFriends(userId);
        }

        public List<Friend> GetPendingFriends(int userId)
        {
            return _context.GetPendingFriends(userId);
        }

        public List<Friend> GetBlockedFriends(int userId)
        {
            return _context.GetBlockedFriends(userId);
        }

        public List<User> GetSearchResult(int userId, string searchObject)
        {
            return _context.GetSearchResult(userId, searchObject);
        }

        public List<int> GetAllFriendsId(int userId)
        {
            return _context.GetAllFriendsId(userId);
        }

        public bool AcceptFriendRequest(int userId, int friendId)
        {
            return _context.AcceptFriendRequest(userId, friendId);
        }

        public bool SendFriendRequest(int userOneId, int userTwoId, int actionId)
        {
            return _context.SendFriendRequest(userOneId, userTwoId, actionId);
        }

        public bool RemoveFriend(int userId, int friendId)
        {
            return _context.RemoveFriend(userId, friendId);
        }

        public bool DeclineFriendsRequest(int userId, int friendId)
        {
            return _context.DeclineFriendsRequest(userId, friendId);
        }

        public bool BlockFriend(int userId, int friendId)
        {
            return _context.BlockFriend(userId, friendId);
        }

        public bool UnblockFriend(int userId, int friendId)
        {
            return _context.UnblockFriend(userId, friendId);
        }
    }
}