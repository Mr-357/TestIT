using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestIT.Models.ViewModels;

namespace TestIT.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public String QuestionText { get; set; }
        public float Points { get; set; }
        public String Picture { get; set; }
        public IList<Answer> Answers { get; set; }
        public Quiz Quiz { get; set; }

        public Question()
        {
            this.Answers = new List<Answer>();
        }

        public void update(EditQuestionModel model)
        {

            this.Points = Points;
            this.QuestionText = model.QuestionText;
            foreach(editAnswer answerModel in model.Answers)
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
                this.Answers.Add(tempAnswer);
            }
        }
    }

    public abstract class Answer
    {
        [Key]
        public int ID { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }

    }

    public class RegionAnswer: Answer
    {

        public double x1 { get; set; }
        public double x2 { get; set; }
        public double y1 { get; set; }
        public double y2 { get; set; }
        public RegionAnswer() { }
        public RegionAnswer(double x1, double x2, double y1, double y2, bool isCorrect)
        {
            this.IsCorrect = isCorrect;
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

    }
    public class TextAnswer : Answer
    {
        public string text { get; set; }
        public TextAnswer() { }
        public TextAnswer(string text,bool isCorrect)
        {
            this.IsCorrect = isCorrect;
            this.text = text;
        }
    }

    public class PictureAnswer : Answer
    { 
        public byte[] Picture  { get; set; }
    }
}
