using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{

    public class Quiz
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public int numberOfQustionsPerTry { get; set; }
        public int time { get; set; } //time on quiz in minutes, if 0 then unlimited,
        [DefaultValue(quizVisibility.privateQuiz)]
        public quizVisibility Visibility { get; set; }


        public List<Question> Questions { get; set; }

    }
    public enum quizVisibility
    {
        privateQuiz, PublicQuiz
    }
}
