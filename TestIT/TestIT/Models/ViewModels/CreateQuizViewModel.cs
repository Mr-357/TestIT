using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class QuizviewModel
    {
        public string Name { get; set; }
        public int NumberOdQuestionsPerTry { get; set; }
        public int Time { get; set; }
        public List<QuestionModel> Questions { get; set; }


        public QuizviewModel()
        {
            this.Questions = new List<QuestionModel>();
        }
    }
    public class CreateQuizViewModel : QuizviewModel
    {
       
    }
    public class resultsViewModel : QuizviewModel
    {
        public int ID { get; set; }
    }

    public class QuestionModel
    {
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public List<AnswerModel> Answers{ get; set; }

        public QuestionModel()
        {
            this.Answers = new List<AnswerModel>();     
        }
    }
    public class AnswerModel
    {
        public bool isCorrect { get; set; }
        public float x1 { get; set; }
        public float x2 { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }
        public string answerText { get; set; }
        public string type { get; set; }
    }
}
