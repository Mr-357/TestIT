//AddSubjectsPerYear();

// Po defaultu su sakriveni a ovime i otkrivamo cim se loaduje stranica
window.unhide = function unhide() {
    let div;
    div = document.getElementsByClassName("year");
    for (let i = 0; i < div.length; i++)
        Hide(i);
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
    console.log(this.value); 
    
    window.location.href = '/Home/ConcreteSubject/';
}

function Hide(num){
    
    let div;
    div = document.getElementsByClassName("year");
    if(div!=null)
        div[num].hidden = !div[num].hidden;
}



window.HideSubjects = function HideSubjects(num){
    Hide(num);
}