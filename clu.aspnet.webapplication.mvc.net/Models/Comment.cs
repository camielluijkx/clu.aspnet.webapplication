﻿using System.ComponentModel.DataAnnotations;

namespace clu.aspnet.webapplication.mvc.net.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int PhotoID { get; set; }

        public string UserName { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual Photo Photo { get; set; }
    }
}