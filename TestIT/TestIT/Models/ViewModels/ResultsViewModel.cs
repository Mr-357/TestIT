﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class ResultsViewModel : BaseQuizViewModel
    {
        public float NumberOfRightAnswers { get; set; }
        public List<ResultQuestion> Questions { get; set; }
        public Dictionary<int, byte[]> Images { get; set; }
        public ResultsViewModel()
        {
            this.Questions = new List<ResultQuestion>();
            this.Images = new Dictionary<int, byte[]>();
        }

        public void copyInfo(Quiz quiz)
        {
            this.ID = quiz.ID;
            this.Name = quiz.Name;
            this.Time = quiz.time;
            this.NumberOdQuestionsPerTry = quiz.numberOfQustionsPerTry;
        }

        public void countRightAnswers()
        {
            float count = 0;
            foreach (ResultQuestion question in this.Questions)
            {
                count += (question.AchievedPoints==0)?0:question.Points / question.AchievedPoints;
            }
            this.NumberOfRightAnswers = count;
        }
    }

    public class ResultQuestion : BaseQuestionModel
    {
        public List<ResultAnswer> Answers { get; set; }
        public float AchievedPoints { get; set; }
        public ResultQuestion(Question question, QuestionModel attemptQuestion)
        {
            this.Answers = new List<ResultAnswer>();
            this.Points = question.Points;
            this.QuestionText = question.QuestionText;
            this.PicturePath = question.Picture;
            ResultAnswer tempAnswer;
            if (question.Answers.Count == 1)
            {
                tempAnswer = (attemptQuestion.Answers.Count>0)? new ResultAnswer(attemptQuestion.Answers[0]) : new ResultAnswer() ;
                if(question.Answers[0].GetType() == typeof(TextAnswer))
                {
                    tempAnswer.RightAnswerText = ((TextAnswer)question.Answers[0]).text;
                    //tempAnswer.isCorrect = compareAnswers(tempAnswer.RightAnswerText, attemptQuestion.Answers[0].answerText);
                }else if(question.Answers[0].GetType() == typeof(RegionAnswer))
                {
                    tempAnswer.RightX1 = ((RegionAnswer)question.Answers[0]).x1;
                    tempAnswer.RightY1 = ((RegionAnswer)question.Answers[0]).y1;
                    tempAnswer.RightX2 = ((RegionAnswer)question.Answers[0]).x2;
                    tempAnswer.RightY2 = ((RegionAnswer)question.Answers[0]).y2;
                    tempAnswer.type = "singleRegion";
                }
                tempAnswer.validateSingleAnswer();
                
                this.Answers.Add(tempAnswer);
            }
            else if(question.Answers.Count > 1)
            {
                for (int j = 0; j < question.Answers.Count; j++)
                {
                    tempAnswer =  new ResultAnswer(question.Answers[j]);
                    if (question.Answers[j].GetType() == typeof(TextAnswer))
                    {
                        if (attemptQuestion.Answers.Count > 0 && attemptQuestion.Answers[0].answerText != null)
                            tempAnswer.isUserPick = (tempAnswer.answerText.Equals(attemptQuestion.Answers[0].answerText)) ? true : false;
                        else tempAnswer.isUserPick = false;
                    }
                    else if(question.Answers[j].GetType() == typeof(RegionAnswer))
                    {
                        tempAnswer.isUserPick = tempAnswer.hasPoint(attemptQuestion.Answers);
                        tempAnswer.type = "multyRegion";
                        //if (attemptQuestion.Answers[j].x1 == 0 || attemptQuestion.Answers[j].y1 == 0)
                        //    tempAnswer.isUserPick = false;
                        //else
                        //{
                        //    Boolean temp = (attemptQuestion.Answers[j].x1 >= tempAnswer.x1 && attemptQuestion.Answers[j] <= RightX2) && (attemptQuestion.Answers[j].y1 >= RightY1 && y1 <= RightY2);
                        //    tempAnswer.isUserPick = temp;
                        //}
                    }
                    this.Answers.Add(tempAnswer);
                }
            }
            this.calculatePoint();
        }
        private Boolean compareAnswers(String rightAnswer,String attemptAnswer)
        {
            if (attemptAnswer == null || rightAnswer == null)
                return false;
            return rightAnswer.ToLower().Equals(attemptAnswer.ToLower());
        }
        private void calculatePoint()
        {
            if(this.Answers.Count == 1)
            {
                this.AchievedPoints = (this.Answers[0].isCorrect) ? this.Points : 0;
            }
            else if(this.Answers.Count > 1)
            {
                int numCorrect = 0;
                int numUserGotRigt = 0;
                foreach (ResultAnswer answer in this.Answers)
                {
                    if (answer.isCorrect)
                    {
                        numCorrect++;
                        if (answer.isUserPick)
                            numUserGotRigt++;
                    }
                }
                this.AchievedPoints = (numUserGotRigt == 0)?0:this.Points * (numCorrect / numUserGotRigt);
            }
        }
    }

    public class ResultAnswer : BaseAnswerModel
    {
        public bool isUserPick { get; set; }
        public String RightAnswerText { get; set; }
        public double RightX1 { get; set; }
        public double RightY1 { get; set; }
        public double RightX2 { get; set; }
        public double RightY2 { get; set; }
        public ResultAnswer(BaseAnswerModel baseAnswerModel)
        {
            this.answerText = baseAnswerModel.answerText;
            this.type = baseAnswerModel.type;
            this.x1 = baseAnswerModel.x1;
            this.x2 = baseAnswerModel.x2;
            this.y1 = baseAnswerModel.y1;
            this.y2 = baseAnswerModel.y2;
        }
        public ResultAnswer(Answer answer)
        {
            this.isCorrect = answer.IsCorrect;
            if(typeof(TextAnswer) == answer.GetType())
            {
                this.answerText = ((TextAnswer)answer).text;
                this.type = "Text";
            }
            else if(answer.GetType() == typeof(RegionAnswer))
            {
                this.RightX1 = ((RegionAnswer)answer).x1;
                this.RightX2 = ((RegionAnswer)answer).x2;
                this.RightY1 = ((RegionAnswer)answer).y1;
                this.RightY2 = ((RegionAnswer)answer).y2;
                this.type = "Region";
            }
        }
        public ResultAnswer() { }

        public void validateSingleAnswer()
        {
            if (this.type != null && this.type.ToLower().Contains("text"))
            {
                if (this.answerText == null || this.RightAnswerText== null)
                    this.isCorrect = false;
                else
                    this.isCorrect = this.RightAnswerText.ToLower().Equals(this.answerText.ToLower());
            }
            else if (this.type != null && this.type.ToLower().Contains("region"))
            {
                if (x1 == 0 || RightX1 == 0 || RightX2 == 0 || y1 == 0 || RightY1 == 0 || RightY2 == 0)
                    this.isCorrect = false;
                else if ((x1 >= RightX1 && x1 <= RightX2) && (y1 >= RightY1 && y1 <=RightY2))
                    this.isCorrect = true;
                else
                    this.isCorrect = false;
            }else if(this.type == null)
            {
                this.isCorrect = false;
            }
        }
        public Boolean hasPoint(List<BaseAnswerModel> answers)
        {
            if (answers == null)
                return false;
            foreach (BaseAnswerModel answer in answers)
            {
                this.x1 = this.x2 = answer.x1;
                this.y1 = this.y2 = answer.y1;
                if ((answer.x1 >= this.RightX1 && answer.x1 <= this.RightX2) && ((answer.y1 >= this.RightY1 && answer.y1 <= this.RightY2)))
                {
                    answers.Remove(answer);
                    return true;
                }
            }
            return false;
        }

    }
}
