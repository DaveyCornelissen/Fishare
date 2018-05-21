using System.Collections.Generic;
using Fishare.Model;
using Fishare.Repository.Interface;

namespace Fishare.Logic
{
    public class FriendMemoryContext : IFriendsRepository
    {
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
            throw new System.NotImplementedException();
        }

        public List<Friend> GetPendingFriends(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<Friend> GetBlockedFriends(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetSearchResult(int userId, string searchObject)
        {
            throw new System.NotImplementedException();
        }

        public bool AcceptFriendRequest(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public bool SendFriendRequest(int userOneId, int userTwoId, int actionId)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveFriend(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeclineFriendsRequest(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public bool BlockFriend(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public bool UnblockFriend(int userId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        public List<Friend> GetSearchResult(string searchObject)
        {
            throw new System.NotImplementedException();
        }
    }
}