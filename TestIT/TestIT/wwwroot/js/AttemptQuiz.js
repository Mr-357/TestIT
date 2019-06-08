import { Quiz } from "./Quiz.js";
import { Answer } from "./Answer.js";
import { Question } from "./Question.js";

console.log("Attempt Quiz Hello");
let quiz = null;
let visibleQuestion = 0;
let tempQuestions = [];
let timeRemaining;
let displayTimer;
let timer;
let timerInterval;
let timeO;
window.startUp = function startUp(json) { //ova fja moze da se renameuje u crtajkviz ili tako nesto
    quiz = json;
    tempQuestions = quiz.Questions;
    tempQuestions.forEach(x => x.Answers = [new Answer()]);
    console.log(quiz);
    let questionDiv = document.getElementById("question" + visibleQuestion);
    questionDiv.hidden = "";
    console.log(quiz.time);
    if (quiz.time > 0) {

        timeRemaining = quiz.time * 60;
        timerInterval = setInterval(displayTimer, 1000);
        let h = document.getElementById("time");
        h.style.display = "initial";
        timeO = setTimeout(timer, timeRemaining * 1000);
    }

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
    console.log(result);
    jsFetch(result);
}
window.showQuestion = function showQuestion(index) {
    let questionDiv = document.getElementById("question" + visibleQuestion);
    questionDiv.hidden = "hidden";
    questionDiv = document.getElementById("question" + index);
    questionDiv.hidden = "";
    visibleQuestion = index;
}
function getherAnswers() {
    let result = new Quiz();
    result.ID = quiz.ID;
    //let i = 0;
    console.log(quiz.Questions);
    for (var i = 0; i < quiz.Questions.length; i++) {
        //console.log("se desava ovo uopste ??");
        if (document.getElementById("regionLabel" + i) == null) {
            let tempQuestion = new Question();
            let tempAnswer;
            let answerInput = document.getElementsByName("Q" + i);

            if (answerInput.length == 1) {
                tempAnswer = new Answer();
                tempAnswer.answerText = answerInput.item(0).value;
                tempAnswer.type = "singleText";
                tempQuestion.addAnswer(tempAnswer);
            }
            else if (answerInput.length > 1) {
                for (let j = 0; j < answerInput.length; j++) {
                    if (answerInput[j].checked) {
                        tempAnswer = new Answer();
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
    var img = document.getElementById("imageQ"+questionIndex);
    var x = event.pageX;
    var y = event.pageY;
    x = x - img.offsetLeft;
    y = y - img.offsetTop
    let answer = new Answer();
    answer.x1 = x;
    answer.y1 = y;
    answer.x2 = x;
    answer.y2 = y;

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

function showAnswers(index) {
    drowPoints(index);
    let tBody = document.getElementById("tableBody" + index);
    tBody.innerHTML = "";
    for (var i = 0; i < tempQuestions[index].Answers.length; i++) {
        let answer = tempQuestions[index].Answers[i];
        let tr = document.createElement("tr");
        let pointTD = document.createElement("td");
        let buttonTD = document.createElement("td");
        pointTD.innerHTML = "(" + answer.x1 + "," + answer.y1 + ")";
        let button = document.createElement("input");
        button.type = "button";
        button.className = "btn btn-danger";
        button.innerHTML = "X";
        buttonTD.appendChild(button);
        tr.append(pointTD);
        tr.append(buttonTD);
        tBody.appendChild(tr);
    }
}

function drowPoints(questionIndex) {
    var img = document.getElementById("imageQ" + questionIndex);
    var cnvs = document.getElementById("myCanvas" + questionIndex);
    cnvs.style.position = "absolute";
    cnvs.style.left = img.offsetLeft + "px";
    cnvs.style.top = img.offsetTop + "px";
    cnvs.widht = img.widht;;
    cnvs.height = img.height;
    cnvs.hidden = "";
    var ctx = cnvs.getContext("2d");
    ctx.beginPath();
    ctx.lineWidth = 3;
    ctx.strokeStyle = '#00ff00';
    tempQuestions[questionIndex].Answers.forEach(a => {
        var x = a.x1;
        var y = a.y1;
        ctx.arc(x, y, 5, 0, 2 * Math.PI, true);
        ctx.fill();
    })
    ctx.stroke();
}


function jsFetch(result) {
    //console.log(result);
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
            console.log(response);
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

