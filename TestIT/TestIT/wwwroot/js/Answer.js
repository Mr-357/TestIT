
export class Answer {
    constructor(isCorrect) {
        this.isCorrect = isCorrect;
        this.x1 = null;
        this.x2 = null;
        this.y2 = null;
        this.y1 = null;
        this.answerText = null;
        this.type = null;
    }
    setAnswerText(text) {
        this.answerText = text;
        this.type = "text";
    }
    sePoints(x1, x2, y1, y2) {
        this.x1 = x1;
        this.x2 = x2;
        this.y2 = y2;
        this.y1 = y1;
        this.type = "region";
    }
    setType(type) {
        this.type = type;
    }
}

export class RegionAnswer extends Answer {
    constructor( pointA, pointB,isCorrect) {
        super(isCorrect);
        this.pointA = pointA;
        this.pointB = pointB;
    }
}

export class TextAnswer extends Answer {
    constructor(answerText, isCorrect) {
        super(isCorrect);
        this.answerText = answerText
    }
}
