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
        [Display(Name = "Godina")]
        public String SchoolYear { get; set; }
        [Display(Name = "Naziv predmeta")]
        public String Name { get; set; }
        [Display(Name = "Modul")]
        public String Module { get; set; }
        [Display(Name = "Opis")]
        public String Description { get; set; }
        [Display(Name = "Skracenica")]
        public String Short  { get; set; }
        public IList<Quiz> Quizzes { get; set; }
        public IList<onCours> Users { get; set; }
        public IList<Comment> Comments {get; set;}
        public IList<Competition> Competitions { get; set; }
        public Course()
        {
            this.Comments = new List<Comment>();
            this.Quizzes = new List<Quiz>();
            this.Users = new List<onCours>();
        }
    }
}
