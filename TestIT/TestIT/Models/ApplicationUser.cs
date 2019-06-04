using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Modul { get; set; }
        public IList<onCours> OnCours { get; set; }
        public IList<Quiz> Quizzes { get; set; }
        public ApplicationUser() : base()
        {
            Quizzes = new List<Quiz>();
            this.OnCours = new List<onCours>();
        }


        public void addQuiz(Quiz quiz)
        {
            this.Quizzes.Add(quiz);
        }
        public void addCours(onCours course)
        {
            this.OnCours.Add(course);
        }

    }
}
