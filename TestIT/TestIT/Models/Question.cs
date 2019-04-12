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
        public List<Answer> Answers { get; set; }
    }

    public abstract class Answer
    {
        [Key]
        public int ID { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class RegionAnswer: Answer
    {
        public float x1 { get; set; }
        public float x2 { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }
    }
    public class TextAnswer : Answer
    {
        public String text { get; set; }
    }

    public class PictureAnswer : Answer
    {
        public byte[] Picture  { get; set; }
    }
}
