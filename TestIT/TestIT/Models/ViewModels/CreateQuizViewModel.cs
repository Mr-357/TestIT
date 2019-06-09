using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class QuizViewModel : BaseQuizViewModel
    {
        public List<QuestionModel> Questions { get; set; }
        public QuizViewModel()
        {
            this.Questions = new List<QuestionModel>();
        }
        public void normalizeDouble()
        {

        }
    }

    public class QuestionModel : BaseQuestionModel
    {

        public List<BaseAnswerModel> Answers{ get; set; }
        public QuestionModel()
        {
            this.Answers = new List<BaseAnswerModel>();     
        }
    }

}
