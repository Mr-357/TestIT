using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class ResultsViewModel : BaseQuizViewModel
    {
        public float NumberOfRightAnswers { get; set; }
        public List<ResultQuestion> questions { get; set; }

        public ResultsViewModel()
        {
            this.questions = new List<ResultQuestion>();
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
            foreach (ResultQuestion question in this.questions)
            {
                count += (question.AchievedPoints==0)?0:question.Points / question.AchievedPoints;
            }
            this.NumberOfRightAnswers = count;
        }
    }

    public class ResultQuestion :BaseQuestionModel
    {
        public List<ResultAnswer> Answers { get; set; }
        public float AchievedPoints { get; set; }
        public ResultQuestion(Question question, QuestionModel attemptQuestion)
        {
            this.Answers = new List<ResultAnswer>();
            this.Points = question.Points;
            this.QuestionText = question.QuestionText;

            ResultAnswer tempAnswer;
            if (question.Answers.Count == 1)
            {
                tempAnswer = new ResultAnswer(attemptQuestion.Answers[0]);
                tempAnswer.RightAnswerText = ((TextAnswer)question.Answers[0]).text;
                tempAnswer.isCorrect = compareAnswers(tempAnswer.RightAnswerText, attemptQuestion.Answers[0].answerText);
                this.Answers.Add(tempAnswer);
            }
            else if(question.Answers.Count > 1)
            {
                for (int j = 0; j < question.Answers.Count; j++)
                {
                    tempAnswer = new ResultAnswer(question.Answers[j]);
                    tempAnswer.isUserPick = (tempAnswer.answerText.Equals(attemptQuestion.Answers[0].answerText)) ? true : false;
                    this.Answers.Add(tempAnswer);
                }
            }
            this.calculatePoint();
        }

        private Boolean compareAnswers(String rightAnswer,String attemptAnswer)
        {
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
            }
            else if(answer.GetType() == typeof(RegionAnswer))
            {
                this.x1 = ((RegionAnswer)answer).x1;
                this.x2 = ((RegionAnswer)answer).x2;
                this.y1 = ((RegionAnswer)answer).y1;
                this.y2 = ((RegionAnswer)answer).y2;
            }
        }
        public ResultAnswer() { }


        public bool isUserPick { get; set; }
        public String RightAnswerText { get; set; }
    }
}
