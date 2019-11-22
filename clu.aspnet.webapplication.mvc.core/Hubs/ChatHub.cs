using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.SignalR
{
    public class ChatHub : Hub
    {
        public async Task MessageAll(string sender, string message)
        {
            await Clients.All.SendAsync("NewMessage", sender, message);
        }
    }
}