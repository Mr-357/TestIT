using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class BaseQuizViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOdQuestionsPerTry { get; set; }
        public int Time { get; set; }

    }
    public class BaseQuestionModel
    {
        public string QuestionText { get; set; }
        public int Points { get; set; }
    }

    public class BaseAnswerModel
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
