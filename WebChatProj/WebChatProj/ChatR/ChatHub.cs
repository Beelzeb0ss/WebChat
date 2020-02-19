using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebChatProj.ChatR
{
    public class ChatHub : Hub
    {
        public async Task SendToGroup(int groupID, string senderName, string message)
        {
            await Clients.Group(groupID.ToString()).addChatMessage(senderName, message);
        }

        public async Task JoinRoom(int roomID, string name)
        {
            await Groups.Add(Context.ConnectionId, roomID.ToString());
            Clients.Group(roomID.ToString()).addChatMessage("System", name + " joined.");
        }

        public async Task LeaveRoom(int roomID, string name)
        {
            await Groups.Remove(Context.ConnectionId, roomID.ToString());
            Clients.Group(roomID.ToString()).addChatMessage("System", name + Context.User.Identity.Name + " left.");
        }
    }
}