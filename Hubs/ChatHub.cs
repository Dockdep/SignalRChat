using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToGroup(string user, string message)
        {
            if(user == "User1" || user == "User2"){
                await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            }
    
            await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
        }
    }
}