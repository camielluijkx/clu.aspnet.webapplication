using clu.aspnet.webapplication.mvc.Models;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.Repository
{
    public interface IPhotoSharingContext
    {
        IQueryable<Photo> Photos { get; }

        IQueryable<Comment> Comments { get; }

        int SaveChanges();

        T Add<T>(T entity) where T : class;

        Photo FindPhotoById(int ID);

        Photo FindPhotoByTitle(string Title);

        Comment FindCommentById(int ID);

        T Delete<T>(T entity) where T : class;
    }
}