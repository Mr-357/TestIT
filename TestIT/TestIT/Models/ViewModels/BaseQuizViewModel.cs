﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class BaseQuizViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOdQuestionsPerTry { get; set; }
        public int Time { get; set; }
    }
    public class BaseQuestionModel
    {
        public string QuestionText { get; set; }
        public float Points { get; set; }
        public String PicturePath { get; set; }
    }

    public class BaseAnswerModel
    {
        public bool IsCorrect { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double y1 { get; set; }
        public double y2 { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }
}
