using clu.aspnet.webapplication.mvc.net.Models;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.net.Repository
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments(int PhotoID);
    }
}