using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace TestIT.Models.ViewModels
{
    public class AttemptQuizViewModel : Quiz
    {
        public int Comp { get; set; }
        public Dictionary<int,byte[]> Images { get; set; }
        public List<int> IndexOfCheckBox { get; set; }
        public void fillFromQuiz(Quiz quiz)
        {
            this.ID = quiz.ID;
            this.Name = quiz.Name;
            this.numberOfQustionsPerTry = quiz.numberOfQustionsPerTry;
            this.time = quiz.time;
            this.Visibility = quiz.Visibility;
            this.Questions = quiz.Questions;
            this.Images = new Dictionary<int, byte[]>();
            this.IndexOfCheckBox = new List<int>();
            this.eraseAnswers();
        }
        private void eraseAnswers()
        {
            foreach(Question question in Questions)
            {
                if(question.Picture != null)
                {
                    int index = Questions.IndexOf(question);
                    byte[] image = FileToByteArray(question.Picture);
                    Images.Add(index, image);
                }
                if(question.Answers.Count > 1)
                {
                    if (question.Answers[0].GetType() == typeof(TextAnswer))
                    {
                        int index = Questions.IndexOf(question);
                        if (numOfCorrectAnswers(index) > 1)
                            this.IndexOfCheckBox.Add(index);
                    }
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
                }
            }
        }
        public int numOfCorrectAnswers(int index)
        {
            int sum = 0;
            foreach (Answer answer in Questions[index].Answers)
            {
                if (answer.IsCorrect)
                    sum++;
            }
            return sum;
        }
        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
    }
}
