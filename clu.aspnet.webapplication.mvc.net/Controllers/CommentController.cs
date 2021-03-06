﻿using clu.aspnet.webapplication.mvc.net.Models;
using clu.aspnet.webapplication.mvc.net.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.net.Controllers
{
    public class CommentController : BaseController
    {
        private IPhotoSharingContext context;

        //Constructors
        public CommentController()
        {
            context = new PhotoSharingContext();
        }

        public CommentController(IPhotoSharingContext Context)
        {
            context = Context;
        }

        public ActionResult Display(int id)
        {
            //Use the repository to get the comments
            ICommentRepository commentRepository = new CommentRepository();
            ICollection<Comment> comments = commentRepository.GetComments(id);
            return View("Display", comments);
        }

        [ChildActionOnly]
        public PartialViewResult _CommentsForPhoto(int PhotoId)
        {
            var comments = from c in context.Comments
                           where c.PhotoID == PhotoId
                           select c;

            ViewBag.PhotoId = PhotoId;
            return PartialView("_CommentsForPhoto", comments.ToList());
        }

        //
        // GET: /Comment/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Comment comment = context.FindCommentById(id);
            ViewBag.PhotoID = comment.PhotoID;
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = context.FindCommentById(id);
            context.Delete<Comment>(comment);
            context.SaveChanges();
            return RedirectToAction("Display", "Photo", new { id = comment.PhotoID });
        }

        [Authorize]
        public PartialViewResult _Create(int PhotoId)
        {
            Comment newComment = new Comment();
            newComment.PhotoID = PhotoId;

            ViewBag.PhotoID = PhotoId;

            return PartialView("_CreateAComment");
        }

        [HttpPost]
        public PartialViewResult _CommentsForPhoto(Comment comment, int PhotoId)
        {
            context.Add<Comment>(comment);
            context.SaveChanges();

            var comments = from c in context.Comments
                           where c.PhotoID == PhotoId
                           select c;

            ViewBag.PhotoId = PhotoId;

            return PartialView("_CommentsForPhoto", comments.ToList());
        }
    }
}