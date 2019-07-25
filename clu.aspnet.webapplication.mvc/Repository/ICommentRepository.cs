using clu.aspnet.webapplication.mvc.Models;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.Repository
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments(int PhotoID);
    }
}