using System;
using System.Collections.Generic;
using System.Linq;
namespace TestIT.Models.ViewModels
{
    public class AnswersViewModel
    {
        public List<Answer> answers { get; set; }
        public int quizID { get; set; }
        public AnswersViewModel()
        {
        }
    }
}
