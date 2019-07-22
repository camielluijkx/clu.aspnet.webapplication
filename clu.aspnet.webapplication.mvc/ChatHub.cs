using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc
{
    public class ChatHub : Hub
    {
        public Task Join(int photoId)
        {
            return Groups.Add(Context.ConnectionId, "Photo" + photoId);
        }

        public Task Send(string username, int photoId, string message)
        {
            string groupName = "Photo" + photoId;

            return Clients.Group(groupName).addMessage(username, message);
        }
    }
}