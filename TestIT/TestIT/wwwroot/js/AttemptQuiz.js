import { Quiz } from "./Quiz.js";
import { Answer } from "./Answer.js";
import { Question } from "./Question.js";

console.log("Attempt Quiz Hello");
let quiz = null;

window.jsonToQzit = function jsonToQzit(json) {
    console.log(json);
    let newQuiz = new Quiz();
    newQuiz.Name = json.Name;
    newQuiz.numberOfQustionsPerTry = json.numberOfQustionsPerTry;
    newQuiz.time = json.time;
    for (var i = 0; i < json.Questions.length; i++) {
        let tempQuestion = new Question(json.Questions[i].QuestionText, json.Questions[i].Points, json.Questions[i].Picture);
        for (var j = 0; j < json.Questions[i].Answers.length; j++) {
            let tempAnswer = new Answer(json.Questions[i].Answers[j].IsCorrect);
            if (json.Questions[i].Answers[j].text) {
                tempAnswer.answerText = json.Questions[i].Answers[j].text;
                tempAnswer.type = "text";
            }
            else {
                tempAnswer.type = "region";
                tempAnswer.x1 = json.Questions[i].Answers[j].x1;
                tempAnswer.x2 = json.Questions[i].Answers[j].x2;
                tempAnswer.y1 = json.Questions[i].Answers[j].y1;
                tempAnswer.y2 = json.Questions[i].Answers[j].y2;
            }
            tempQuestion.addAnswer(tempAnswer);
        }
        newQuiz.addQuestion(tempQuestion);
    }
    quiz = newQuiz;
    console.log(quiz);
}