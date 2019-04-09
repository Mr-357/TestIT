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
        public List<Answer> Answers { get; set; }
    }

    public class Answer
    {
        [Key]
        public int ID { get; set; }
        public bool IsCorrect { get; set; }

    }
}
