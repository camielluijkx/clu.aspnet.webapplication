﻿using clu.aspnet.webapplication.mvc.net.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Text;
using clu.aspnet.webapplication.mvc.net.Repository;
using System.Web.UI;
using System.Linq;
using System;
using System.Web;
using clu.aspnet.webapplication.mvc.net.Attributes;

namespace clu.aspnet.webapplication.mvc.net.Controllers
{
    [HandleError(View = "Error")]
    [ValueReporter]
    public class PhotoController : BaseController
    {
        private IPhotoSharingContext context;

        public ViewResult Map()
        {
            return View("Map");
        }

        public PhotoController()
        {
            context = new PhotoSharingContext();
        }

        public PhotoController(IPhotoSharingContext Context)
        {
            context = Context;
        }

        // GET: Photo
        [OutputCache(Duration = 600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Photo> photos;
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (from p in context.Photos orderby p.CreatedDate descending select p).Take(number).ToList();
            }

            return PartialView("_PhotoGallery", photos);
        }

        public ActionResult Display(int id)
        {
            Photo photo = context.FindPhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }

            return View("Display", photo);
        }

        public ActionResult DisplayByTitle(string title)
        {
            Photo photo = context.FindPhotoByTitle(title);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Display", photo);
        }

        [Authorize]
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();
            newPhoto.CreatedDate = DateTime.Today;

            return View("Create", newPhoto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;

            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }

                context.Add<Photo>(photo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Photo photo = context.FindPhotoById(id);

            if (photo == null)
            {
                return HttpNotFound();
            }

            return View("Delete", photo);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = context.FindPhotoById(id);

            context.Delete<Photo>(photo);

            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [OutputCache(Duration = 600, Location = OutputCacheLocation.Server, VaryByParam = "id")]
        public FileContentResult GetImage(int id)
        {
            Photo photo = context.FindPhotoById(id);

            if (photo != null)
            {
                return File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult SlideShow()
        {
            return View("SlideShow", context.Photos.ToList());
        }

        public ActionResult FavoritesSlideShow()
        {
            List<Photo> favPhotos = new List<Photo>();
            List<int> favoriteIds = Session["Favorites"] as List<int>;

            if (favoriteIds == null)
            {
                favoriteIds = new List<int>();
            }

            Photo currentPhoto;

            foreach (int currentId in favoriteIds)
            {
                currentPhoto = context.FindPhotoById(currentId);

                if (currentPhoto != null)
                {
                    favPhotos.Add(currentPhoto);
                }
            }

            return View("SlideShow", favPhotos);
        }

        public ContentResult AddFavorite(int PhotoId)
        {
            List<int> favoriteIds = Session["Favorites"] as List<int>;

            if (favoriteIds == null)
            {
                favoriteIds = new List<int>();
            }

            favoriteIds.Add(PhotoId);
            Session["Favorites"] = favoriteIds;

            return Content("The picture has been added to your favorites", "text/plain", Encoding.Default);
        }

        [Authorize]
        public ActionResult Chat(int id)
        {
            Photo photo = context.FindPhotoById(id);

            if (photo == null)
            {
                return HttpNotFound();
            }

            return View("Chat", photo);
        }
    }
}