using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class QuizViewModel : BaseQuizViewModel
    {
        public List<QuestionModel> Questions { get; set; }
        public String Course { get; set; }
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

    public class editAnswer : BaseAnswerModel
    {
        public int ID { get; set; }
    }

    public class EditQuestionModel : BaseQuestionModel
    {
        public int ID { get; set; }
        public String Picture { get; set; }
        public List<editAnswer> Answers { get; set; }
        public Question toQuestio()
        {
            Question retQuestion = new Question();
            retQuestion.ID = this.ID;
            retQuestion.Picture = this.Picture;
            retQuestion.Points = this.Points;
            retQuestion.QuestionText = this.QuestionText;
            foreach(editAnswer answerModel in this.Answers)
            {
                Answer tempAnswer = null;
                if (answerModel.type.ToLower().Contains("region"))
                {
                    tempAnswer = new RegionAnswer(answerModel.x1, answerModel.x2, answerModel.y1, answerModel.y2, answerModel.IsCorrect);
                }
                else if (answerModel.type.ToLower().Contains("text"))
                {
                    tempAnswer = new TextAnswer(answerModel.text, answerModel.IsCorrect);
                }
                //tempAnswer.ID = answerModel.ID;
                retQuestion.Answers.Add(tempAnswer);
            }
            return retQuestion;
        }
    }

}
