using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IGroupRequestRepository
    {
        IEnumerable<RequestGG> GetGroupRequests();

        //Проверяем, отправила ли группа1 группе2 приглашение 
        bool RequestIsSent(int groupFromId, int groupToId);

        void AddGroupRequest(RequestGG groupRequest);
        void DeleteGroupRequest(RequestGG groupRequest);
    }
}
