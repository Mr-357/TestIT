using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Quiz> Quizzes { get; set; }
        public ApplicationUser() : base()
        {
            Quizzes = new List<Quiz>();
        }


        public void addQuiz(Quiz quiz)
        {
            this.Quizzes.Add(quiz);
        }

    }
}
