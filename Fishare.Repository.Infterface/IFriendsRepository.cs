using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;

namespace Fishare.Repository.Interface
{
    public interface IFriendsRepository : IRepository<Friend>
    {
        List<Friend> GetAcceptedFriends(int userId);

        List<Friend> GetPendingFriends(int userId);

        List<Friend> GetBlockedFriends(int userId);

        List<User> GetSearchResult(int userId, string searchObject);

        List<int> GetAllFriendsId(int userId);

        bool AcceptFriendRequest(int userId, int friendId);

        bool SendFriendRequest(int userOneId, int userTwoId, int actionId);

        bool RemoveFriend(int userId, int friendId);

        bool DeclineFriendsRequest(int userId, int friendId);

        bool BlockFriend(int userId, int friendId);

        bool UnblockFriend(int userId, int friendId);
        
    }
}
