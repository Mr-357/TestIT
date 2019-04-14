﻿using System;
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
        public String Name { get; set; }
        public int numberOfQustionsPerTry { get; set; }
        public int time { get; set; } //time on quiz in minutes, if 0 then unlimited,
        [DefaultValue(quizVisibility.privateQuiz)]
        public quizVisibility Visibility { get; set; }


        public List<Question> Questions { get; set; }

        public Quiz()
        {
            this.Questions = new List<Question>();
        }   
        public Quiz(CreateQuizViewModel model)
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
                foreach (AnswerModel answer in questionModel.Answers)
                {
                    if(answer.type == "text")
                    {
                        tempQuestion.Answers.Add(new TextAnswer(answer.answerText, answer.isCorrect));
                    }
                    else if (answer.type=="range")
                    {
                        tempQuestion.Answers.Add(new RegionAnswer(answer.x1, answer.x2, answer.y1, answer.y1, answer.isCorrect));
                    }
                }
                this.Questions.Add(tempQuestion);
            }
        }
    }

    public enum quizVisibility
    {
        privateQuiz, PublicQuiz
    }
}
