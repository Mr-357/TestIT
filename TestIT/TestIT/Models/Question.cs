using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public String QuestionText { get; set; }
        public float Points { get; set; }
        public byte[] Picture { get; set; }
        public IList<Answer> Answers { get; set; }
        public Quiz Quiz { get; set; }

        public Question()
        {
            this.Answers = new List<Answer>();
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

        public float x1 { get; set; }
        public float x2 { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }
        public RegionAnswer() { }
        public RegionAnswer(float x1,float x2,float y1,float y2,bool isCorrect)
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
        public TextAnswer(string text,bool isCorect)
        {
            this.IsCorrect = IsCorrect;
            this.text = text;
        }
    }

    public class PictureAnswer : Answer
    {
        
        public byte[] Picture  { get; set; }
    }
}
