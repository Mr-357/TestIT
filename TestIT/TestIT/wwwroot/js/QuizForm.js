import { Quiz } from "./Quiz.js";
import { Answer } from "./Answer.js";
import { RegionAnswer } from "./Answer.js";
import { TextAnswer } from "./Answer.js";
import { Question } from "./Question.js";


let QuizTemplate = new Quiz();  // pokusao sam da nazovem samo quiz al ne da mi jer postoji klasa koja se zove Quiz, pokusao sam i malo slovo na pocetku nece ni to
let QuestionTemplate = new Question();
let answerQuantity = "single";
let answerType = "text";
let AnswerTextArea = document.getElementById("AnswerTextArea");
let textAnserDiv = document.getElementsByClassName("textAnserDiv")[0];
let multyAnswerArea = document.getElementById("multyAnswerArea");
let addAnswerButton = document.getElementById("addAnswerButton");
let tableBody = document.getElementById("tableBody");

window.addQuestion = function addQuestion() {

    QuestionTemplate.QuestionText = document.getElementById("questionText").value;
    QuestionTemplate.Points = document.getElementById("questionPoints").value;
    QuestionTemplate.Picture = document.querySelector('[type=file]').files[0];
    if (answerQuantity == "single") {
        if (answerType == "text") {
            let tempAnswer = new Answer(true);
            tempAnswer.answerText = AnswerTextArea.value;
            tempAnswer.type = answerQuantity + "-" + answerType;
            QuestionTemplate.addAnswer(tempAnswer);
        }
    }
    else if (answerQuantity == "multy") {

    }
    QuizTemplate.addQuestion(QuestionTemplate);
    addQuestionToLeftSide(QuestionTemplate);
    QuestionTemplate = new Question();
    let fileInput = document.querySelector('[type=file]');
    fileInput.value = "";
    previewFile();
}
function fillPictureFilePaths() {
    let files = [];
    for (let i = 0; i < QuizTemplate.questions.length; i++) {
        if (QuizTemplate.questions[i].Picture) {
            files.push(QuizTemplate.questions[i].Picture);
        }
    }
    saveImagesFetch(files); 
}

function saveImagesFetch(files) {
    const formData = new FormData();

    for (let i = 0; i < files.length; i++) {
        let file = files[i];
        formData.append('images', file);
    }
    formData.append('images', files);
    let ret;
    fetch("/Quizzes/FetchImagePost", {
        method: 'POST',
        body: formData
    }).then(response => {
        return response.json();
        }).then(r => {
            replaceImageWithPath(r.value.filePaths);
            createFetch();
        });
}

function replaceImageWithPath(paths) {
    let j = 0;
    for (let i = 0; i < QuizTemplate.questions.length; i++) {
        if (QuizTemplate.questions[i].Picture) {
            QuizTemplate.questions[i].Picture = null;
            QuizTemplate.questions[i].PicturePath = paths[j];
            j++;
            console.log("promenejna slika");
            console.log(QuizTemplate);
        }
    }

}

function saveImageFetch() {
    let file = document.querySelector('[type=file]').files[0];
    const formData = new FormData();
    formData.append('image', file);

    fetch("/Quizzes/FetchImagePost", {
        method: 'POST',
        body: formData
    }).then(response => {
        console.log(response)
    });
}

function addQuestionToLeftSide(question) {

    let questions = document.getElementById('questions');

    let p = document.createElement('p');
    p.className = "question"
    p.innerHTML = question.QuestionText;
    questions.appendChild(p);
}

window.showQuestions = function showQuestions() {
    let questions = document.getElementById('questions');
    questions.hidden = !questions.hidden;
}


window.createQuestion = function createQuestion(elements) {
    const tmp = elements[0].hidden;
    for (let i = 0; i < elements.length; i++)
        elements[i].hidden = !tmp;
}

window.addAnswer = function addAnswer() {
    let tempAnswer = new Answer(false);
    tempAnswer.answerText = AnswerTextArea.value;
    tempAnswer.type = answerQuantity + "-" + answerType;
    QuestionTemplate.addAnswer(tempAnswer);
    showAnswers();
}

function addRegionAnswer(x1, y1, x2, y2) {
    let tempAnswer = new Answer(false);
    tempAnswer.x1 = x1;
    tempAnswer.x2 = x2;
    tempAnswer.y1 = y1;
    tempAnswer.y2 = y2;
    tempAnswer.type = answerQuantity + "-" + answerType;
    if (answerQuantity == "single")
        QuestionTemplate.Answers = [];
    QuestionTemplate.addAnswer(tempAnswer);
    console.log(tempAnswer);
    showAnswers();
}

window.imageClick = function imageClick() {
    if (answerType == "region") {
        console.log("does this");
        var img = document.getElementById("questionImageArea");
        var x = event.pageX;
        var y = event.pageY;
        x = x - img.offsetLeft;
        y = y - img.offsetTop
        var recWidth = 100;
        var recdepth = 50;
        addRegionAnswer(x, y, x + recWidth, y + recdepth);
        drowOnImage();
    }
}

//Display stuff
function drowOnImage() {
    var img = document.getElementById("questionImageArea");
    var cnvs = document.getElementById("myCanvas");
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
    let i = 0;
    QuestionTemplate.Answers.forEach(a => {
        var x = a.x1;
        var y = a.y1;
        var widht = a.x2 - a.x1;
        var depth = a.y2 - a.y1;
        drowText(x, y, "T" + (i + 1), ctx);
        ctx.rect(x, y, widht, depth);
        i++;
    })
    ctx.stroke();
}
function drowText(x, y, text, ctx) {
    let tempSytyle = ctx.fillStyle;
    ctx.fillStyle = "red";
    console.log("crta se text");
    ctx.font = "15px Arial";
    ctx.fillText(text, x - 4, y - 4);
    ctx.fillStyle = tempSytyle;
}
window.setAnswerCuantity = function setAnswerCuantity(quantity) {
    answerQuantity = quantity;
    QuestionTemplate.Answers = [];
    toggleButton();
    toggleMultyAnserArea()
}
window.createTextAnswerArea = function createTextAnswerArea() {
    textAnserDiv.hidden = "";
    answerType = "single";
    QuestionTemplate.Answers = [];
    showAnswers();
    toggleButton();
}
window.createRegionAnswerArea = function createRegionAnswerArea() {
    textAnserDiv.hidden = "hidden";
    QuestionTemplate.Answers = [];
    answerType = "region";
    showAnswers();
}

function toggleButton() {
    if (answerQuantity == "single") {
        addAnswerButton.hidden = "hidden";
    }
    else
        addAnswerButton.hidden = "";
}
function toggleMultyAnserArea() {
    showAnswers();
    if (answerQuantity == "single")
        multyAnswerArea.hidden = "hidden";
}
function showAnswers() {
    multyAnswerArea.hidden = "";
    tableBody.innerHTML = "";
    let i = 0;
    QuestionTemplate.Answers.forEach(a => {
        showAnswer(a, i++);
    })
    drowOnImage();
}

function showAnswer(answer, index) {
    let tr = document.createElement("tr");
    let tempLabel = document.createElement("label");
    if (answer.type.includes("text")) {
        tempLabel.innerHTML = answer.answerText;
    }
    else if (answer.type.includes("region")) {
        tempLabel.innerHTML = "T"+(index+1) +": " + answer.x1 + " " + answer.y1 + " " + answer.x1 + " " + answer.y2;
    }
    let checkBox = document.createElement("input");
    checkBox.type = "checkbox"
    checkBox.onclick = function () { togleCorrect(index); };
    let button = document.createElement("input");
    button.type = "button";
    button.value = "x";
    button.className = "btn btn-danger"
    button.onclick = function () { removeAnswer(index); };

    let td;
    td = document.createElement("td");
    td.appendChild(tempLabel);
    tr.appendChild(td);

    td = document.createElement("td");
    td.appendChild(checkBox);
    tr.appendChild(td);

    td = document.createElement("td");
    td.appendChild(button);
    tr.appendChild(td);
    tableBody.appendChild(tr);
}
function togleCorrect(index) {
    QuestionTemplate.Answers[index].isCorrect = !QuestionTemplate.Answers[index].isCorrect
    console.log(QuestionTemplate.Answers[index]);
}

function removeAnswer(index) {
    QuestionTemplate.Answers.splice(index, 1);
    showAnswers();
}
window.previewFile = function previewFile() {

    var preview = document.getElementById("questionImageArea"); //selects the query named img
    preview.hidden = "";
    var file = document.querySelector('input[type=file]').files[0]; //sames as here
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file); //reads the data as a URL
    } else {
        preview.src = "";
    }
}
//previewFile();

//fetch stuff

window.createQuez = function createQuez() {
    let files = [];
    for (let i = 0; i < QuizTemplate.questions.length; i++) {
        if (QuizTemplate.questions[i].Picture) {
            files.push(QuizTemplate.questions[i].Picture);
        }
    }
    saveImagesFetch(files); //ovde se i salje kviz 
} 

function createFetch() {
    console.log(QuizTemplate);
    const formData = new FormData();
    QuizTemplate.Name = document.getElementById("quizName").value;
    QuizTemplate.numberOfQustionsPerTry = document.getElementById("questionPerTry").value;
    QuizTemplate.time = document.getElementById("timeForQuiz").value;
    buildFormData(formData, QuizTemplate);
    const fetchData =
    {
        method: "POST",
        body: formData,
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Quizzes/FetchCreate", fetchData)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else
                window.location.replace("/Quizzes/Index"); //ovde sam hteo da me redirektuje nazad na index stranicu ali mora da se refreshuje index pre nego sto se pojavi novi kviz
            //mozda proradi ako se iskoristi neki tajmer ili tako nesto? u svakom slucaju mi cemo fetch koristiti za in-page a ovo pravljenje kviza moze preko submit-a
            return;
        })
        .catch(error => console.log(error));
}

window.jsFetch = function jsFetch() {

     fillPictureFilePaths();
    console.log(QuizTemplate);
    const formData = new FormData();
    QuizTemplate.Name = document.getElementById("quizName").value;
    QuizTemplate.numberOfQustionsPerTry = document.getElementById("questionPerTry").value;
    QuizTemplate.time = document.getElementById("timeForQuiz").value;
    buildFormData(formData, QuizTemplate);
    const fetchData =
    {
        method: "POST",
        body: formData,
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Quizzes/FetchCreate", fetchData)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else
                window.location.replace("/Quizzes/Index"); //ovde sam hteo da me redirektuje nazad na index stranicu ali mora da se refreshuje index pre nego sto se pojavi novi kviz
            //mozda proradi ako se iskoristi neki tajmer ili tako nesto? u svakom slucaju mi cemo fetch koristiti za in-page a ovo pravljenje kviza moze preko submit-a
            return;
        })
        .catch(error => console.log(error));
}

//rekurzivno kreiranje formData iz kompleksnog objekta trebalo bi da radi za sve vrste objekata
function buildFormData(formData, data, parentKey) {
    if (data && typeof data === 'object' && !(data instanceof Date) && !(data instanceof File)) {
        Object.keys(data).forEach(key => {
            buildFormData(formData, data[key], parentKey ? `${parentKey}[${key}]` : key);
        });
    } else {
        if (data instanceof File) {
            console.log("uraido sam ovo za File");
            console.log(data);
        }
            
        const value = data == null ? '' : data;

        formData.append(parentKey, value);
    }
}
window.fetchCourses = function fetchCourses() {
    let godina = document.getElementById("godina")
    if (godina.options[0].value == "") {
        godina.remove(0);
    }
    const fetchData =
    {
        method: "GET",
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Courses/getCourses?year=" + godina.value)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else {
                let lista = document.getElementById("predmeti");
                for (let i = lista.options.length - 1; i >= 0; i--) {
                    lista.remove(i);
                }
                return response.json();
            }
            return;
        })
        .then(data => {
            console.log(data);
            let lista = document.getElementById("predmeti");
            data.forEach(x => {
                console.log(x);
                let opcija = document.createElement("option");
                opcija.innerHTML = x;
                lista.add(opcija);
            });
        })
        .catch(error => console.log(error));

}
window.fetchYears = function fetchYears() {
    console.log("uslo ovde");
    const fetchData =
    {
        method: "GET",
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Courses/getYears")
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else {

                return response.json();
            }
            return;
        })
        .then(data => {
            console.log(data);
            let lista = document.getElementById("godina");
            data.forEach(x => {
                console.log(x);
                let opcija = document.createElement("option");
                opcija.innerHTML = x;
                lista.add(opcija);
            });
        })
        .catch(error => console.log(error));

}
