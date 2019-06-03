using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class ResultsViewModel
    {
        public string Name { get; set; }
        public int NumberOfQuestionsPerTry { get; set; }
        public int NumberOfRightAnswers { get; set; }
        public List<ResultQuestion> questions { get; set; }

        public ResultsViewModel()
        {
            this.questions = new List<ResultQuestion>();
        }
    }

    public class ResultQuestion
    {
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public List<ResultAnswers> answers { get; set; }
    }

    public class ResultAnswers : BaseAnswerModel
    {
        public bool isUserPick { get; set; }
        public String RightAnswer { get; set; }
    }
}
