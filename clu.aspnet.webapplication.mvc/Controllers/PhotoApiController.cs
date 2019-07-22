using clu.aspnet.webapplication.mvc.Models;
using clu.aspnet.webapplication.mvc.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class PhotoApiController : ApiController
    {
        private IPhotoSharingContext context = new PhotoSharingContext();

        public List<Photo> GetAllPhotos()
        {
            return context.Photos.ToList();
        }

        public Photo GetPhotoById(int id)
        {
            Photo photo = context.FindPhotoById(id);

            if (photo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return photo;
        }

        public Photo GetPhotoByTitle(string title)
        {
            Photo photo = context.FindPhotoByTitle(title);

            if (photo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return photo;
        }
    }
}