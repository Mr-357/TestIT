import { Quiz } from "./Quiz.js";
import { Answer } from "./Answer.js";
import { Question } from "./Question.js";

console.log("Attempt Quiz Hello");
let quiz = null;
let visibleQuestion = 0;
let timeRemaining;
let displayTimer;
let timer;
let timerInterval;
let timeO;
window.startUp = function startUp(json) { //ova fja moze da se renameuje u crtajkviz ili tako nesto
    quiz = json;
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
    let i = 0;
    quiz.Questions.forEach(question => {
        let tempQuestion = new Question();
        let tempAnswer;
        let answerInput = document.getElementsByName("Q" + i);
        i++;
        if (answerInput.length == 1) {
            tempAnswer = new Answer();
            tempAnswer.answerText = answerInput.item(0).value;
            tempAnswer.type = "singleText";
            tempQuestion.addAnswer(tempAnswer);
        }
        else if (answerInput.length > 1) {
            for (let j = 0; j < answerInput.length; j++) {
                console.log("doslo je do ovde");
                if (answerInput[j].checked) {
                    tempAnswer = new Answer();
                    tempAnswer.answerText = answerInput[j].value;
                    tempAnswer.type = "multyText";
                    tempQuestion.addAnswer(tempAnswer);
                }
                console.log("Zavrsilo je do ovde");
            }
        }
        result.addQuestion(tempQuestion);
    })
    return result;
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

