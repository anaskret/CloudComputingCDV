using ChatApp.Dto;
using ChatApp.Dto.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(UserChatMessage message)
        {
            message.TimeStamp = DateTime.Now;
            await Clients.All.SendAsync(Consts.RECEIVE_MESSAGE, message);
        }
    }
}
