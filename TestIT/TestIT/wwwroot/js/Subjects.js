//AddSubjectsPerYear();

// Po defaultu su sakriveni a ovime i otkrivamo cim se loaduje stranica
//Hide('1');
//Hide('2')
//Hide('3')
//Hide('4')


function AddSubjectsPerYear(){
    let div = document.getElementsByClassName("1st-year");
    AppendSubjects(div[0]);
    div = document.getElementsByClassName("2nd-year");
    AppendSubjects(div[0]);
    div = document.getElementsByClassName("3rd-year");
    AppendSubjects(div[0]);
    div = document.getElementsByClassName("4th-year");
    AppendSubjects(div[0]);
}

function AppendSubjects(container){
    let button;
    let div;
    for(let i = 0; i < 5;i++){
        div = document.createElement("div");
        button = document.createElement("button");
        button.innerHTML = "Predmet";
        // Ovo je za subject id kako bi kasnije moglo da se vidi ciji subject page da se prikaze
        // Naravno nece da se stavlja random broj nego kada se citaju predmeti iz baze dodeljivace se njihov id za value
        button.value = i; 
        button.onclick = GoToSubjectPage;
        div.appendChild(button);
        container.appendChild(div);
    }
}

function GoToSubjectPage(){
    console.log(this.value); // Stampa value dugmeta tj predmeta koji je kliknut i to bi se prosledjivalo pri prikazivanju stranice za taj konkretan kviz

    // window.location.href = '/Home/ConcreteSubject/' + this.value;
    
    window.location.href = '/Home/ConcreteSubject/';
}

function Hide(num){
    
    let div;
    div = document.getElementsByClassName("year");
    div[num].hidden = !div[num].hidden;
}



window.HideSubjects = function HideSubjects(num){
    Hide(num);
}