using clu.aspnet.webapplication.mvc.net.Models;
using System.Collections.Generic;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.net.Repository
{
    /*
    
    By using the ICommentRepository interface, the code makes it easy to replace CommentRespository with another 
    implementation if you need to. However, the CommentController code still creates a CommentRespository object. You 
    have to modify the object to make the replacement.

    In an even better architecture, you can replace CommentRepository with a different implementation of 
    ICommentRepository without any changes to the CommentController class. This is an extremely flexible and adaptable 
    approach and is called a loosely coupled architecture.

    Loosely coupled architectures are also essential for unit testing. 

    */
    public class CommentRepository : ICommentRepository
    {
        public ICollection<Comment> GetComments(int PhotoID)
        {
            //Implement entity framework calls here.
            PhotoSharingContext dbContext = new PhotoSharingContext();

            return dbContext.Comments.ToList();
        }
    }
}