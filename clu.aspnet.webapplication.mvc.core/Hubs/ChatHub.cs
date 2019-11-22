using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.SignalR
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> _connectedUsers = new Dictionary<string, string>();

        public async Task MessageAll(string sender, string message)
        {
            await Clients.All.SendAsync("NewMessage", sender, message);
        }

        public async Task MessageChatRoom(string message)
        {
            await Clients.Group("ChatRoom").SendAsync("NewMessage", _connectedUsers[Context.ConnectionId], message);
        }

        public async Task JoinChatRoom(string sender)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "ChatRoom");

            _connectedUsers.Add(Context.ConnectionId, sender);

            await Clients.Group("ChatRoom").SendAsync("UserListUpdate", _connectedUsers.Values);
        }

        public async Task LeaveChatRoom()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "ChatRoom");

            _connectedUsers.Remove(Context.ConnectionId);

            await Clients.Group("ChatRoom").SendAsync("UserListUpdate", _connectedUsers.Values);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connectedUsers.Remove(Context.ConnectionId);

            Clients.Group("ChatRoom").SendAsync("UserListUpdate", _connectedUsers.Values);

            return base.OnDisconnectedAsync(exception);
        }
    }
}