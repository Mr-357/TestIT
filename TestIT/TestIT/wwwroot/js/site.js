// DIV koji sadrzi sve opcije za kreiranje odgovora
const answerOptions = document.getElementById("answer-options");


function jsFetch()
{
    //ovo je klasicno kao iz web prog
    const formData = new FormData();
    formData.append("ID", 15);
    formData.append("Name", "fetch test");

    const fetchData =
    {
        method: "POST",
        body: formData,
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Quizzes/FetchCreate", fetchData)
        .then(response => {
            if (!response.ok)
            {
                throw new Error(response.statusText);
            }
            else
               // window.location.href = url; ovde sam hteo da me redirektuje nazad na index stranicu ali mora da se refreshuje index pre nego sto se pojavi novi kviz
               //mozda proradi ako se iskoristi neki tajmer ili tako nesto? u svakom slucaju mi cemo fetch koristiti za in-page a ovo pravljenje kviza moze preko submit-a
               return;
        })
        .catch(error => console.log(error));  
}

function addQuestion()
{
    let questions = document.getElementById('questions');
    let p = document.createElement('p');
    p.className = "question"
    p.innerHTML = 'Hard coded treba baza i klasa za pitanja';
    questions.appendChild(p);
}

function showQuestions() {
    let questions = document.getElementById('questions');
    questions.hidden = !questions.hidden;
}


function createQuestion(elements) {
    const tmp = elements[0].hidden;
    for (let i = 0; i < elements.length; i++)
        elements[i].hidden = !tmp;
}

// Obican tekstualni tip odgovora
function createAnswerTextArea() {
    // Close previous selected options
    closeAnswerImageArea();
    closeAnswerSelectionArea();
    let textArea = document.createElement('textarea');
    textArea.style = "resize: both";
    textArea.id = "answerTextArea";
    answerOptions.appendChild(textArea);
}

// Odgovor koji moze da se selektuje od ponudjenih stavki
function createAnswerSelectionArea() {

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

    label = document.createElement('label');
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
    input.value = "Dodaj odgovor";
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
function createAnswerImageArea() {
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
function closeAnswerTextArea() {
    const answerTextArea = document.getElementById("answerTextArea");
    if (answerTextArea != null)
        answerOptions.removeChild(answerTextArea);
}

// Gasenje opcija za selekciju ukoliko se promeni izbor tipa odgovora
function closeAnswerSelectionArea(container) {
    // TODO: nije skroz implementirano
    let a = document.getElementsByClassName("AnswersDiv");
    a[0].hidden ="hidden";
    const selectAnswerDiv = document.getElementById("selectAnswerDiv");
    if (selectAnswerDiv != null)
        answerOptions.removeChild(selectAnswerDiv);
    console.log("TODO: closeAnswerSelectionArea()")
}

// Gasenje opcija za odgovor preko slike ukoliko se promeni izbor tipa odgovora
function closeAnswerImageArea(container) {
    const imageAnswer = document.getElementById("codeSnippet");
    if (imageAnswer != null)
        answerOptions.removeChild(imageAnswer);
    // TODO
    console.log("TODO: closeAnswerImageArea()")
}

function addAnswer()
{
    let p = document.createElement('p');
    p.innerHTML = "Dodat odgovor";
    p.className = "question"
    let answersDiv = document.getElementsByClassName('AnswersDiv');
    answersDiv[0].appendChild(p);
}