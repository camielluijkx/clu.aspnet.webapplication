using clu.aspnet.webapplication.mvc.core.Models;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Services
{
    public interface IChatManager
    {
        List<ChatUser> GetUsers();
    }
}