using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class AttemptQuizViewModel : Quiz
    {

        public void fillFromQuiz(Quiz quiz)
        {
            this.ID = quiz.ID;
            this.Name = quiz.Name;
            this.numberOfQustionsPerTry = quiz.numberOfQustionsPerTry;
            this.time = quiz.time;
            this.Visibility = quiz.Visibility;
            this.Questions = quiz.Questions;
            this.eraseAnswers();
        }
        private void eraseAnswers()
        {
            foreach(Question question in Questions)
            {
                if(question.Answers.Count > 1)
                {
                    foreach (Answer answer in question.Answers)
                        answer.IsCorrect = false;
                }
                else
                {
                    if(question.Answers[0].GetType() == typeof(TextAnswer))
                    {
                        ((TextAnswer)question.Answers[0]).text = null;
                    }
                    else if(question.Answers[0].GetType() == typeof(RegionAnswer))
                    {
                        ((RegionAnswer)question.Answers[0]).x1 = 0;
                        ((RegionAnswer)question.Answers[0]).x2 = 0;
                        ((RegionAnswer)question.Answers[0]).y1 = 0;
                        ((RegionAnswer)question.Answers[0]).y2 = 0;
                    }
                    else if(question.Answers[0].GetType() == typeof(PictureAnswer))
                    {
                        //ovde ne znam sta al nije ni bitno za sad
                        //i sad kad razmisljam ne secam se bas sta smo hteli sa picture answer
                    }
                }
            }
        }
    }
}
