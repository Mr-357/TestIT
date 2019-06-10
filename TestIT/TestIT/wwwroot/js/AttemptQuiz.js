import { JSQuiz } from "./Quiz.js";
import { JSAnswer } from "./Answer.js";
import { JSQuestion } from "./Question.js";

console.log("Attempt Quiz Hello");
let quiz = null;
let visibleQuestion = 0;
let tempQuestions = [];
let timeRemaining;
let displayTimer;
let timer;
let timerInterval;
let timeO;
let isResultPage = false;
window.startUp = function startUp(json) { 
    quiz = json;
    tempQuestions = bestCopyEver(quiz.Questions);
    tempQuestions.forEach(x => x.Answers = []);
    let questionDiv = document.getElementById("question" + visibleQuestion);
    questionDiv.hidden = "";
    if (quiz.time > 0) {

        timeRemaining = quiz.time * 60;
        timerInterval = setInterval(displayTimer, 1000);
        let h = document.getElementById("time");
        h.style.display = "initial";
        timeO = setTimeout(timer, timeRemaining * 1000);
    }

}

function bestCopyEver(src) {
    return JSON.parse(JSON.stringify(src));
}
displayTimer = function displayTime() {
    let str = document.getElementById("timer");
    let min = 0;
    let sec = 0;
    timeRemaining--;
    min = Math.floor(timeRemaining / 60);
    sec = timeRemaining % 60;
    str.innerHTML = min + ":" + sec;
    if (timeRemaining == 0) {
        clearInterval(timerInterval);
    }
}
timer = function timeOut() {
    submitAnswers();
}
window.submitAnswers = function submitAnswers() {
    clearInterval(timerInterval);
    clearTimeout(timeO);
    let result = getherAnswers();
    jsFetch(result);
}
window.showQuestion = function showQuestion(index) {
    let questionDiv = document.getElementById("question" + visibleQuestion);
    questionDiv.hidden = "hidden";
    questionDiv = document.getElementById("question" + index);
    questionDiv.hidden = "";
    visibleQuestion = index;
}

window.resultShowQuestion = function resultShowQuestion(input, index) {
    showQuestion(index);
    onImageLoad(input, index);
}

function getherAnswers() {
    let result = new JSQuiz();
    result.ID = quiz.ID;   
    for (let i = 0; i < quiz.Questions.length; i++) {
        if (document.getElementById("regionLabel" + i) == null) {
            let tempQuestion = new JSQuestion();
            let tempAnswer;
            let answerInput = document.getElementsByName("Q" + i);

            if (answerInput.length == 1) {
                tempAnswer = new JSAnswer();
                tempAnswer.answerText = answerInput.item(0).value;
                tempAnswer.type = "singleText";
                tempQuestion.addAnswer(tempAnswer);
            }
            else if (answerInput.length > 1) {
                for (let j = 0; j < answerInput.length; j++) {
                    if (answerInput[j].checked) {
                        tempAnswer = new JSAnswer();
                        tempAnswer.answerText = answerInput[j].value;
                        tempAnswer.type = "multyText";
                        tempQuestion.addAnswer(tempAnswer);
                    }
                }
            }
            result.questions[i] = tempQuestion;
        } else {
            result.addQuestion(tempQuestions[i]);
        }  
    }
    quiz.Questions.forEach(question => {
        
    })
    return result;
}

window.imageClick = function imageClick(questionIndex) {
    let img = document.getElementById("imageQ"+questionIndex);
    let x = event.pageX;
    let y = event.pageY;
    x = (x - img.offsetLeft) / img.width;
    y = (y - img.offsetTop) / img.height;
    let answer = new JSAnswer();
    answer.x1 = x;
    answer.y1 = y;
    answer.x2 = x;
    answer.y2 = y;
    //console.log(quiz);
    if (quiz.Questions[questionIndex].Answers.length == 1) {
        answer.type = "singleRegion";
        tempQuestions[questionIndex].Answers[0] = answer;
    }
    else if (tempQuestions[questionIndex].Answers.length < quiz.Questions[questionIndex].Answers.length) {
        answer.type = "multyRegion";
        tempQuestions[questionIndex].Answers.push(answer);
    }
    showAnswers(questionIndex);
}

function showAnswers(questionIndex) {
    drowPoints(questionIndex);
    let tBody = document.getElementById("tableBody" + questionIndex);
    tBody.innerHTML = "";
    for (let i = 0; i < tempQuestions[questionIndex].Answers.length; i++) {
        let answer = tempQuestions[questionIndex].Answers[i];
        let tr = document.createElement("tr");
        let pointTD = document.createElement("td");
        let buttonTD = document.createElement("td");
        pointTD.innerHTML = "T" + (i+1);
        let button = document.createElement("input");
        button.type = "button";
        button.className = "btn btn-danger";
        button.value = "X";
        button.onclick = function () { removeAnswer(questionIndex, i) };
        buttonTD.appendChild(button);
        tr.append(pointTD);
        tr.append(buttonTD);
        tBody.appendChild(tr);
    }
}


function removeAnswer(questionIndex, answerIndex) {
    console.log("ratatui");
    tempQuestions[questionIndex].Answers.splice(answerIndex, 1);
    showAnswers(questionIndex);
}

window.onresize = function() {
    if (isResultPage == false)
        showAnswers(visibleQuestion);
};

window.reDraw = function reDraw(input) {
    onImageLoad(input, visibleQuestion);
}

function drowPoints(questionIndex) {
    let img = document.getElementById("imageQ" + questionIndex);
    let cnvs = document.getElementById("myCanvas" + questionIndex);
    cnvs.style.position = "absolute";
    cnvs.style.left = img.offsetLeft + "px";
    cnvs.style.top = img.offsetTop + "px";
    cnvs.widht = img.widht;
    cnvs.height = img.height;
    cnvs.hidden = "";
    let ctx = cnvs.getContext("2d");
    ctx.beginPath();
    ctx.lineWidth = 3;
    ctx.strokeStyle = '#00ff00';
    let i = 0;
    tempQuestions[questionIndex].Answers.forEach(a => {
        let x = a.x1  * img.width;
        let y = a.y1 * img.height;
        drawText(x, y, "T" + (i+1),ctx);
        ctx.rect(x, y, 10, 10);
        //ctx.arc(x, y, 5, 0, 2 * Math.PI, false); //ovo se ponasa retardirano
        ctx.fill();
        i++;
    })
    ctx.stroke();
}

function drawText(x, y, text, ctx) {
    let tempSytyle = ctx.fillStyle;
    ctx.fillStyle = "red";
    ctx.font = "13px Arial";
    ctx.fillText(text, x - 4, y - 4);
    ctx.fillStyle = tempSytyle;
}

window.onImageLoad = function onImageLoad(input, index) {
    isResultPage = true;
    console.log(input);
    let img = document.getElementById("imageQ" + index);
    let cnvs = document.getElementById("myCanvas" + index);
    cnvs.style.position = "absolute";
    cnvs.style.left = img.offsetLeft + "px";
    cnvs.style.top = img.offsetTop + "px";
    cnvs.widht = img.widht;;
    cnvs.height = img.height;
    cnvs.hidden = "";
    let ctx = cnvs.getContext("2d");
    ctx.beginPath();
    ctx.lineWidth = 3;
    ctx.strokeStyle = '#00ff00';
    let i = 0;
    input[index].Answers.forEach(a => {
        ctx.beginPath();
        //drawText(a.RightX1 * img.width, a.RightY1 * img.width, "T" + (i + 1), ctx);
        if (a.isUserPick == true || (a.isCorrect == true && input[index].Answers.length == 1))
            ctx.strokeStyle = '#00ff00';
        else
            ctx.strokeStyle = '#ff0000';
        ctx.rect(a.RightX1 * img.width, a.RightY1 * img.height, (a.RightX2 * img.width) - (a.RightX1 * img.width), (a.RightY2 * img.height) - (a.RightY1*img.height));
        i++;
        ctx.stroke();
    })
    //ctx.stroke();
}


function jsFetch(result) {
    const formData = new FormData();
    buildFormData(formData, result);
    const fetchData =
    {
        method: "post",
        body: formData,
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    /*fetch("/Quizzes/Results", fetchData)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else
                window.location.replace("/Quizzes/Results"); //ovde sam hteo da me redirektuje nazad na index stranicu ali mora da se refreshuje index pre nego sto se pojavi novi kviz
            //mozda proradi ako se iskoristi neki tajmer ili tako nesto? u svakom slucaju mi cemo fetch koristiti za in-page a ovo pravljenje kviza moze preko submit-a
            return;
        })
        .catch(error => console.log(error));*/
    fetch("/Quizzes/Results", fetchData)
        .then(response => {
            return response.text();
        })
        .then(data => document.write(data))
        .catch(error => console.log(error));
}

//rekurzivno kreiranje formData iz kompleksnog objekta trebalo bi da radi za sve vrste objekata
function buildFormData(formData, data, parentKey) {
    if (data && typeof data === 'object' && !(data instanceof Date) && !(data instanceof File)) {
        Object.keys(data).forEach(key => {
            buildFormData(formData, data[key], parentKey ? `${parentKey}[${key}]` : key);
        });
    } else {
        const value = data == null ? '' : data;

        formData.append(parentKey, value);
    }
}

