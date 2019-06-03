using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class CreateQuizViewModel : BaseQuizViewModel
    {
        public List<QuestionModel> Questions { get; set; }
        public CreateQuizViewModel()
        {
            this.Questions = new List<QuestionModel>();
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
