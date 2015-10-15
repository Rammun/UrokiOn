using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IFriendRequestRepository
    {
        IEnumerable<FriendRequest> GetFriendRequests();

        //Проверяем, отправил ли пользователь1 пользователю2 запрос на дружбу
        bool RequestIsSent(string userFromId, string userToId);

        void AddFriendRequest(FriendRequest friendRequest);
        void DeleteFriendRequest(FriendRequest friendRequest);
    }
}
