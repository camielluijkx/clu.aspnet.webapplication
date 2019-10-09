using System;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }

        public string Title { get; set; }

        public byte[] PhotoFile { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Owner { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}