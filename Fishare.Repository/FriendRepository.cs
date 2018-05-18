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

        public bool Block(int FriendId)
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

        public List<User> GetSearchResult(int userId, string searchObject)
        {
            return _context.GetSearchResult(userId, searchObject);
        }

        public bool AcceptFriend(int userId, int friendId)
        {
            return _context.AcceptFriend(userId, friendId);
        }
    }
}