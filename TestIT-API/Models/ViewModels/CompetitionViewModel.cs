using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class CompetitionViewModel : Competition
    {
        public int CourseID { get; set; }
        public int QuizID{get; set; }
    }
}
