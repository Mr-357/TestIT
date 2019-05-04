
export class Question {
    constructor(questionText, points, picture, ) {
        this.QuestionText = questionText;
        this.Picture = picture;
        this.Points = points;
        this.Answers = [];
    }
    addAnswer(answer) {
        this.Answers.push(answer);
    }
}
