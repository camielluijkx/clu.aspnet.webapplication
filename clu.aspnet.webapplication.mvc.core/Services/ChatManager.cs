using System.Collections.Generic;
using clu.aspnet.webapplication.mvc.core.Models;

namespace clu.aspnet.webapplication.mvc.core.Services
{
    public class ChatManager : IChatManager
    {
        public List<ChatUser> GetUsers()
        {
            return new List<ChatUser>
            {
                new ChatUser
                {
                    NickName = "Camiel"
                }
            };
        }
    }
}