using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;

namespace Fishare.Repository.Interface
{
    public interface IFriendsRepository : IRepository<Friend>
    {
        bool Block(int FriendId);

        List<Friend> GetAcceptedFriends(int userId);

        List<Friend> GetPendingFriends(int userId);

        List<User> GetSearchResult(int userId, string searchObject);

        bool AcceptFriend(int userId, int friendId);
    }
}
