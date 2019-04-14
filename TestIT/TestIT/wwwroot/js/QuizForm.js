import { Quiz } from "./Quiz.js";
import { Answer }from "./Answer.js";
import { RegionAnswer } from "./Answer.js";
import { TextAnswer } from "./Answer.js";
import { Question } from "./Question.js";


let QuizTemplate = new Quiz();  // pokusao sam da nazovem samo quiz al ne da mi jer postoji klasa koja se zove Quiz, pokusao sam i malo slovo na pocetku nece ni to
let QuestionTemplate = new Question();
console.log("Ucitava se skripta za kreiranje kviza");

//DIV koji sadrzi sve opcije za kreiranje odgovora
const answerOptions = document.getElementById("answer-options");


window.jsFetch = function jsFetch() {
    //ovo je klasicno kao iz web prog
    const formData = new FormData();
    QuizTemplate.Name = document.getElementById("quizName").value;
    QuizTemplate.numberOfQustionsPerTry = document.getElementById("questionPerTry").value;
    QuizTemplate.time = document.getElementById("timeForQuiz").value;
    buildFormData(formData, QuizTemplate);
    console.log(formData);
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

//relurzivno kreiranje formData iz kompleksnog objekta trebalo bi da radi za sve vrste objekata
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


window.addQuestion = function addQuestion() {
    //kreiranj pitanja
    console.log("Radi ADD");
    let selectedValue = "notSelected";
    let radios = document.getElementsByName("AnswerType");
    radios.forEach(radio => {
        if (radio.checked)
            selectedValue = radio.value;
    })
    let questionText = document.getElementById("questionText").value;
    let points = document.getElementById("questionPoints").value;
    switch (selectedValue) {
        case "Text":
            QuestionTemplate.QuestionText = questionText;
            QuestionTemplate.Points = points;
            let tempAnswer = new Answer(true);
            tempAnswer.answerText = document.getElementById("answerTextArea").value;
            tempAnswer.type = "text";
            QuestionTemplate.addAnswer(tempAnswer);
            QuizTemplate.addQuestion(QuestionTemplate);
            addQuestionToLeftSide(QuestionTemplate);
            QuestionTemplate = new Question();
            console.log(QuizTemplate);
            break;
        case "Select":
            QuestionTemplate.QuestionText = questionText;
            QuestionTemplate.Points = points;
            QuizTemplate.addQuestion(QuestionTemplate);
            addQuestionToLeftSide(QuestionTemplate);
            QuestionTemplate = new Question();
            console.log(QuizTemplate);
            console.log("radi Sel");
            break;
        case "image":
            console.log("radi Img");
            break;
        default:
            console.log("niste izabrali nacin odgovora");
            break;
    }

    QuestionTemplate = new Question();
    let answersDiv = document.getElementsByClassName('AnswersDiv');
    answersDiv[0].innerDiv = "";
    //#################

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

// Obican tekstualni tip odgovora
window.createAnswerTextArea = function createAnswerTextArea() {
    // Close previous selected options
    closeAnswerImageArea();
    closeAnswerSelectionArea();
    let textArea = document.createElement('textarea');
    textArea.style = "resize: both";
    textArea.id = "answerTextArea";
    answerOptions.appendChild(textArea);
}

// Odgovor koji moze da se selektuje od ponudjenih stavki
window.createAnswerSelectionArea = function createAnswerSelectionArea() {

    let a = document.getElementsByClassName("AnswersDiv");
    a[0].hidden = !a[0].hidden;

    console.log("TODO: createAnswerSelectionArea()");
    // Close previous selected options
    closeAnswerTextArea();
    closeAnswerImageArea();

    let divMain = document.createElement('div');
    divMain.id = "selectAnswerDiv";

    let divUpper = document.createElement('div');
    let divLower = document.createElement('div');

    let label = document.createElement('label');
    label.innerHTML = "Broj tacnih odgovora: ";
    divLower.appendChild(label);
    let numberOfCorrectAnswers = document.createElement('input');
    divLower.appendChild(numberOfCorrectAnswers);

    let innerDiv = document.createElement('div');

    let textArea = document.createElement('textarea');
    textArea.id = "SelectAnswerTextArea";

    label = document.createElement('label');
    label.innerHTML = "Tekst odgovora: ";

    let input = document.createElement('input');
    input.type = "button";
    input.className = "btn btn-primary addAnswerButton";
    input.value = "govor";
    input.onclick = addAnswer;

    innerDiv.appendChild(label);
    innerDiv.appendChild(textArea);
    innerDiv.appendChild(input);

    divLower.appendChild(innerDiv);

    divMain.appendChild(divUpper);
    divMain.appendChild(divLower);

    answerOptions.appendChild(divMain);
    /* 
     * TODO:
     * Tekst boxevi za svaki od ponudjenih odgovora
    */
}

// Odgovor preko slike
window.createAnswerImageArea = function createAnswerImageArea() {
    console.log("TODO: createAnswerImageArea()");
    // Close previously selected options
    closeAnswerTextArea();
    closeAnswerSelectionArea();

    let image = document.createElement('img');
    image.id = "codeSnippet";
    image.src = "../java.jpeg";
    answerOptions.appendChild(image);
    /*
     * TODO:
     * Implement
    */
}

// Gasenje opcija za tekstualni odgovor ukoliko se promeni izbor tipa odgovora
window.closeAnswerTextArea = function closeAnswerTextArea() {
    const answerTextArea = document.getElementById("answerTextArea");
    if (answerTextArea != null)
        answerOptions.removeChild(answerTextArea);
}

// Gasenje opcija za selekciju ukoliko se promeni izbor tipa odgovora
window.closeAnswerSelectionArea =  function closeAnswerSelectionArea(container) {
    // TODO: nije skroz implementirano
    let a = document.getElementsByClassName("AnswersDiv");
    a[0].hidden = "hidden";
    const selectAnswerDiv = document.getElementById("selectAnswerDiv");
    if (selectAnswerDiv != null)
        answerOptions.removeChild(selectAnswerDiv);
    console.log("TODO: closeAnswerSelectionArea()")
}

// Gasenje opcija za odgovor preko slike ukoliko se promeni izbor tipa odgovora
window.closeAnswerImageArea = function closeAnswerImageArea(container) {
    const imageAnswer = document.getElementById("codeSnippet");
    if (imageAnswer != null)
        answerOptions.removeChild(imageAnswer);
    // TODO
    console.log("TODO: closeAnswerImageArea()")
}

window.addAnswer = function addAnswer() {
    let answerText = document.getElementById("SelectAnswerTextArea").value;
    let tempAnswer = new Answer(true);
    tempAnswer.setAnswerText(answerText);
    QuestionTemplate.addAnswer(tempAnswer);


    let p = document.createElement('p');
    p.innerHTML = tempAnswer.answerText;
    p.className = "question"
    let answersDiv = document.getElementsByClassName('AnswersDiv');
    answersDiv[0].appendChild(p);
}