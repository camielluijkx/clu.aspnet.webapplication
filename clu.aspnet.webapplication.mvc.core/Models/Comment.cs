namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        public string UserName { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public virtual Photo Photo { get; set; }
    }
}