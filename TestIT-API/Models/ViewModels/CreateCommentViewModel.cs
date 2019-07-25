using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class CreateCommentViewModel
    {
        public String CommentText { get; set; }
       // public int UserID { get; set; }
        public int CourseID { get; set; }
        public Comment Create()
        {
            Comment comment = new Comment();
            comment.Content = CommentText;
            return comment;
        }
    }
}
