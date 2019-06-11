import { JSQuiz } from "./Quiz.js";
import { JSAnswer } from "./Answer.js";
import { RegionAnswer } from "./Answer.js";
import { TextAnswer } from "./Answer.js";
import { JSQuestion } from "./Question.js";


let QuizTemplate = new JSQuiz();  // pokusao sam da nazovem samo quiz al ne da mi jer postoji klasa koja se zove Quiz, pokusao sam i malo slovo na pocetku nece ni to
let QuestionTemplate = new JSQuestion();
let answerQuantity = "single";
let answerType = "text";
let AnswerTextArea = document.getElementById("AnswerTextArea");
let textAnserDiv = document.getElementsByClassName("textAnserDiv")[0];
let multyAnswerArea = document.getElementById("multyAnswerArea");
let addAnswerButton = document.getElementById("addAnswerButton");
let tableBody = document.getElementById("tableBody");
let predmeti = document.getElementById("predmeti");
window.addQuestion = function addQuestion() {
    QuestionTemplate.QuestionText = document.getElementById("questionText").value.trim();
    QuestionTemplate.Points = document.getElementById("questionPoints").value;
    QuestionTemplate.Picture = document.querySelector('[type=file]').files[0];
    if (answerQuantity == "single") {
        if (answerType == "text" && AnswerTextArea.value.trim() != "") {
            let tempAnswer = new JSAnswer(true);
            tempAnswer.text = AnswerTextArea.value.trim();
            tempAnswer.type = answerQuantity + "-" + answerType;
            QuestionTemplate.addAnswer(tempAnswer);
        }
    }
    if (!validateQuestion()) {
        alert("niste lepo popunili pitanje");
    }
    else {
        QuizTemplate.addQuestion(QuestionTemplate);
        showQuestionsInTabel();
        QuestionTemplate = new JSQuestion();
        let fileInput = document.querySelector('[type=file]');
        fileInput.value = "";
        previewFile();
    }  
}

function validateQuestion() {
    if (QuestionTemplate.QuestionText == null || QuestionTemplate.QuestionText == "")
        return false;
    if (QuestionTemplate.Points == null || QuestionTemplate.Points == "" || QuestionTemplate.Points < 1)
        return false;
    if (QuestionTemplate.Answers.length == 0)
        return false
    return true;
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
        }
    }

}
window.pointsChange = function pointsChange() {
    let input = document.getElementById("questionPoints");
    if (input.value < 1)
        input.value = 1;
}
window.timeChange = function timeChange() {
    let input = document.getElementById("timeForQuiz");
    if (input.value < 1)
        input.value = 1;
}

function showQuestion(question,index) {
    let tbody = document.getElementById('questionTableBody');
    let tr = document.createElement('tr');
    let td = document.createElement("td");
    let label = document.createElement("label");
    label.innerHTML = question.QuestionText;
    td.appendChild(label);
    tr.appendChild(td);
    let button = document.createElement("input");
    button.type = "button";
    button.className = "btn btn-danger"
    button.value = "X";
    button.onclick = function () { deleteQuestion(index); }
    td = document.createElement("td");
    td.appendChild(button);
    tr.appendChild(td);
    tbody.appendChild(tr);
}

function deleteQuestion(index) {
    QuizTemplate.questions.splice(index, 1);
    showQuestionsInTabel();
}

window.showQuestions = function showQuestions() {
    let questions = document.getElementById('questions');
    questions.hidden = !questions.hidden;
}

function showQuestionsInTabel() {
    let tbody = document.getElementById('questionTableBody');
    tbody.innerHTML = "";
    for (let i = 0; i < QuizTemplate.questions.length; i++) {
        showQuestion(QuizTemplate.questions[i], i);
    }
}

window.createQuestion = function createQuestion(elements) {
    const tmp = elements[0].hidden;
    for (let i = 0; i < elements.length; i++)
        elements[i].hidden = !tmp;
}

window.addAnswer = function addAnswer() {
    if (AnswerTextArea.value.trim() != "") {
        let tempAnswer = new JSAnswer(false);
        tempAnswer.text = AnswerTextArea.value.trim();
        tempAnswer.type = answerQuantity + "-" + answerType;
        QuestionTemplate.addAnswer(tempAnswer);
        showAnswers();
    }
}

function addRegionAnswer(x1, y1, x2, y2) {
    let tempAnswer = new JSAnswer(false);
    tempAnswer.x1 = x1;
    tempAnswer.x2 = x2;
    tempAnswer.y1 = y1;
    tempAnswer.y2 = y2;
    tempAnswer.type = answerQuantity + "-" + answerType;
    if (answerQuantity == "single")
        QuestionTemplate.Answers = [];
    QuestionTemplate.addAnswer(tempAnswer);
    showAnswers();
}

window.imageClick = function imageClick() {
    if (answerType == "region") {
        let img = document.getElementById("questionImageArea");
        let x = event.pageX;
        let y = event.pageY;
        x = (x - img.offsetLeft) / img.width;
        y = (y - img.offsetTop) / img.height;
        let recWidth = 100;
        let recdepth = 50;
        addRegionAnswer(x, y, x + (recWidth / img.width), y + (recdepth / img.height ));
        drowOnImage();
    }
}

//Display stuff
window.onresize = drowOnImage;


function drowOnImage() {
    let img = document.getElementById("questionImageArea");
    let cnvs = document.getElementById("myCanvas");
    cnvs.style.position = "absolute";
    cnvs.style.left = img.offsetLeft + "px";
    cnvs.style.top = img.offsetTop + "px";
    cnvs.width = img.width;;
    cnvs.height = img.height;
    cnvs.hidden = "";
    let ctx = cnvs.getContext("2d");
    ctx.beginPath();
    ctx.lineWidth = 3;
    ctx.strokeStyle = '#00ff00';
    let i = 0;
    QuestionTemplate.Answers.forEach(a => {
        let x = a.x1 * img.width;
        let y = a.y1 * img.height;
        let width = (a.x2 * img.width) - x;
        let depth = (a.y2 * img.height) - y;
        drowText(x, y, "T" + (i + 1), ctx);
        ctx.rect(x, y, width, depth);
        i++;
    })
    ctx.stroke();
}
function drowText(x, y, text, ctx) {
    let tempSytyle = ctx.fillStyle;
    ctx.fillStyle = "red";
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
    answerType = "text";
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
    let img = document.getElementById("questionImageArea");
    let tr = document.createElement("tr");
    let infoDiv = document.createElement("div");
    let tempLabel = document.createElement("label");
    let checkBox = null;
    if (answer.type.includes("text")) {
        tempLabel.innerHTML = answer.text;
        infoDiv.appendChild(tempLabel);
        let tacanTD = document.getElementById("tacanTD");
        if (answerQuantity == "multy") {
            
            tacanTD.hidden = "";
            checkBox = document.createElement("input");
            checkBox.type = "checkbox"
            checkBox.onclick = function () { togleCorrect(index); };
        }
        else if (answerQuantity == "single") {
            tacanTD.hidden = "hidden";
        }
    }
    else if (answer.type.includes("region")) {
        let tacanTD = document.getElementById("tacanTD");
        tacanTD.hidden = "hidden";
        tempLabel.innerHTML = "T" + (index + 1);//+ ": (" + answer.x1 + ", " + answer.y1 + ") (" + answer.x2 + ", " + answer.y2 + ")";
        let widthEditBox = document.createElement("input");
        widthEditBox.type = "number";
        widthEditBox.min = "0";
        let value = parseFloat((answer.x2 - answer.x1) * img.width).toFixed(2);
        widthEditBox.value = value;
        //widthEditBox.value = (answer.x2 - answer.x1) * img.width;
        widthEditBox.onchange = function () { areaChange(widthEditBox.value, index, true) }
        let heightEditBox = document.createElement("input");
        heightEditBox.type = "number";
        heightEditBox.min = "0";
        value = parseFloat((answer.y2 - answer.y1) * img.height).toFixed(2);
        heightEditBox.value = value;
        //heightEditBox.value = (answer.x2 - answer.x1) * img.height;
        heightEditBox.onchange = function () { areaChange(heightEditBox.value, index, false) }
        tempLabel.innerHTML = "T" + (index + 1);
        infoDiv.appendChild(tempLabel);
        infoDiv.appendChild(widthEditBox);
        infoDiv.appendChild(heightEditBox);
    }
    let button = document.createElement("input");
    button.type = "button";
    button.value = "x";
    button.className = "btn btn-danger"
    button.onclick = function () { removeAnswer(index); };

    let td;
    td = document.createElement("td");
    td.appendChild(infoDiv);
    tr.appendChild(td);
    if (checkBox != null) {
        td = document.createElement("td");
        td.appendChild(checkBox);
        tr.appendChild(td);
    }
    td = document.createElement("td");
    td.appendChild(button);
    tr.appendChild(td);
    tableBody.appendChild(tr);
}

function areaChange(size, index, isWidthEdit) {
    let answer = QuestionTemplate.Answers[index];
    let img = document.getElementById("questionImageArea");
    if (isWidthEdit) {
        size = size / img.width;
        answer.x2 = answer.x1 + size;
    } else if (!isWidthEdit) {
        size = size / img.height;
        answer.y2 = answer.y1 + size;
    }
    drowOnImage();
}
function togleCorrect(index) {
    QuestionTemplate.Answers[index].isCorrect = !QuestionTemplate.Answers[index].isCorrect
}

function removeAnswer(index) {
    QuestionTemplate.Answers.splice(index, 1);
    showAnswers();
}
window.previewFile = function previewFile() {

    let preview = document.getElementById("questionImageArea"); //selects the query named img
    preview.hidden = "";
    let file = document.querySelector('input[type=file]').files[0]; //sames as here
    let reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file); //reads the data as a URL
    } else {
        preview.src = "";
        preview.hidden = "hidden";
        document.getElementById("myCanvas").hidden = "hidden";
    }
}
//previewFile();

//fetch stuff

window.createQuez = function createQuez() {
    if (!validateQuiz()) {
        alert("niste lepo popunili kviz");
    } else {
        let files = [];
        for (let i = 0; i < QuizTemplate.questions.length; i++) {
            if (QuizTemplate.questions[i].Picture) {
                files.push(QuizTemplate.questions[i].Picture);
            }
        }
        saveImagesFetch(files); //ovde se i salje kviz 
    }
} 
function validateQuiz() {
    let name = document.getElementById("quizName").value;
    //let numberOfQustionsPerTry = document.getElementById("questionPerTry").value;
    let time = document.getElementById("timeForQuiz").value;
    if (QuizTemplate.questions.length == 0)
        return false;
    if (name.trim() == "")
        return false;
    if (time < 1)
        return false;
    if (QuizTemplate.Course == null || QuizTemplate.Course == "")
        return false;
    return true;
}
function createFetch() {
    const formData = new FormData();
    QuizTemplate.Name = document.getElementById("quizName").value.trim();
    //QuizTemplate.numberOfQustionsPerTry = document.getElementById("questionPerTry").value;
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
   
    const formData = new FormData();
    QuizTemplate.Name = document.getElementById("quizName").value;
    QuizTemplate.numberOfQustionsPerTry = document.getElementById("questionPerTry").value;
    QuizTemplate.time = document.getElementById("timeForQuiz").value;
    buildFormData(formData, QuizTemplate);
    formData = JSON.stringify(formData);
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
            let lista = document.getElementById("predmeti");
            data.forEach(x => {
                let opcija = document.createElement("option");
                opcija.innerHTML = x;
                lista.add(opcija);
                courseChange();
            });
        })
        .catch(error => console.log(error));

}

window.courseChange = function courseChange(){
    QuizTemplate.Course = predmeti.options[predmeti.selectedIndex].value;
    console.log(QuizTemplate);
}

window.fetchYears = function fetchYears() {
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
            let lista = document.getElementById("godina");
            data.forEach(x => {
                let opcija = document.createElement("option");
                opcija.innerHTML = x;
                lista.add(opcija);
            });
        })
        .catch(error => console.log(error));

}
