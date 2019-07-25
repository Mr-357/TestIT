var shownPrivateQuizzes = false;
var shownPublicQuizzes = false;

window.showPrivateQuizzes = function showPrivateQuizzes() {
    removeQuizzes();
    if(shownPublicQuizzes){
        removePublicQuizzes();
    }
    if (!shownPrivateQuizzes) {
        const container = document.getElementById('RightSideDoQuiz');
        let privateQuizzes = document.createElement('div');
        privateQuizzes.id = "PrivateQuizzes";
        let p;
        // foreach quiz in private quizzes
        for (let i = 0; i < 10; i++) {
            p = document.createElement('p');
            p.className = "quiz";
            p.innerHTML = "Moj kviz" + i.toString();
            privateQuizzes.appendChild(p);
        }
        shownPrivateQuizzes = true;
        container.appendChild(privateQuizzes);
    }
    else {
        removePrivateQuizzes();
    }
}

function removePrivateQuizzes(){
    let quizzes = document.getElementById('RightSideDoQuiz');
    let privateQuizzes = document.getElementById('PrivateQuizzes');
    quizzes.removeChild(privateQuizzes);
    shownPrivateQuizzes = false;
}

window.showPublicQuizzes = function showPublicQuizzes(){
    removeQuizzes();
    if(shownPrivateQuizzes){
        removePrivateQuizzes();
    }

    if(!shownPublicQuizzes){
        const container = document.getElementById('MiddleDoQuiz');
        let subjects = document.createElement('div');
        subjects.id = "Subjects";
        let button;
        let div;
        for (let i = 0; i < 10; i++) {
            div = document.createElement('div');
            button = document.createElement('button');
            button.className = "btn btn-primary";
            button.innerHTML = "Predmet" + i.toString();
            button.value = i.toString();
            button.onclick = showQuizzes;
            div.appendChild(button);
            subjects.appendChild(div);
        }
        container.appendChild(subjects);
        shownPublicQuizzes = true;
    }
    else{
        removePublicQuizzes();
    }
}

function removePublicQuizzes(){
    let quizzes = document.getElementById('MiddleDoQuiz');
    let subjects = document.getElementById('Subjects');
    quizzes.removeChild(subjects);
    shownPublicQuizzes = false;
}

window.showQuizzes = function showQuizzes(i){
    removeQuizzes();
    let container = document.getElementById('RightSideDoQuiz');
    let label = document.createElement('label');
    label.id = "SubjectQuizzes";
    label.innerHTML = "Prikazani kvizovi za predmet: " + this.value;
    container.appendChild(label);


    let div = document.createElement('div');
    div.id = "Quizzes";
    let p;
    for (let i = 0; i < 10; i++) {
        p = document.createElement('p');
        p.className = "quiz";
        p.innerHTML = "Javni kviz" + i.toString();
        div.appendChild(p);
    }
    container.appendChild(div);
}

function removeQuizzes(){
    let quizzes = document.getElementById('RightSideDoQuiz');
    let label = document.getElementById('SubjectQuizzes');
    let div = document.getElementById('Quizzes');
    if(label!=null){
        quizzes.removeChild(label);
        quizzes.removeChild(div);
    }
}