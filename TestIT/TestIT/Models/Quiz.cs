using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestIT.Models.ViewModels;

namespace TestIT.Models
{

    public class Quiz
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Naziv")]
        public String Name { get; set; }
        [DisplayName("Broj pitanja po pokusaju")]
        public int numberOfQustionsPerTry { get; set; }
        [DisplayName("Vreme")]
        public int time { get; set; } //time on quiz in minutes, if 0 then unlimited,
        [DefaultValue(quizVisibility.Privatni)]
        [DisplayName("Tip")]
        public quizVisibility Visibility { get; set; }

        public IList<Question> Questions { get; set; }

        public Quiz()
        {
            this.Questions = new List<Question>();
        }
        
        //copy constructor
        public Quiz(QuizViewModel model)
        {
            this.Name = model.Name;
            this.numberOfQustionsPerTry = model.NumberOdQuestionsPerTry;
            this.time = model.Time;

            this.Questions = new List<Question>();
            foreach(QuestionModel questionModel in model.Questions)
            {
                Question tempQuestion = new Question();
                tempQuestion.QuestionText = questionModel.QuestionText;
                tempQuestion.Points = questionModel.Points;
                tempQuestion.Picture = questionModel.PicturePath;
                foreach (BaseAnswerModel answer in questionModel.Answers)
                {
                    if(answer.type.Contains("text"))
                    {
                        TextAnswer temp = new TextAnswer(answer.text, answer.IsCorrect);
                        tempQuestion.Answers.Add(temp);
                    }
                    else if (answer.type.Contains("region"))
                    {
                        tempQuestion.Answers.Add(new RegionAnswer(answer.x1, answer.x2, answer.y1, answer.y2, answer.IsCorrect));
                    }
                }
                this.Questions.Add(tempQuestion);
            }
        }
    }

    public enum quizVisibility
    {
        Privatni, Javni, Ceka
    }
}
