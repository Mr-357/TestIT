using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public String SchoolYear { get; set; }
        public String Name { get; set; }
        public String Module { get; set; }
        public String Description { get; set; }
        public String Short  { get; set; }
        public IList<Quiz> Quizzes { get; set; }
        public IList<onCours> Users { get; set; }
        public IList<Comment> Comments {get; set;}
        public Course()
        {
            this.Comments = new List<Comment>();
            this.Quizzes = new List<Quiz>();
            this.Users = new List<onCours>();
        }
    }
}
