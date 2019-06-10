var done = false;
var quizzes;
window.get = function get() {

    let select = document.getElementById("predmet");
    fetch("/Competitions/GetCourses")
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
            let opcija = document.createElement("option");
     
                opcija.innerHTML = "Predmet nije izabran";
                select.add(opcija);
         
          
            data.forEach(x => {
                opcija = document.createElement("option");
                opcija.innerHTML = x;
                select.add(opcija);
            });
        })
        .catch(error => console.log(error));


}

window.deleteNema = function deleteNema() {

    if (!done) {
        let select = document.getElementById("moduli");

        select.remove(0);
        done = true;
    }


}

window.showData = function showData() {
    let selected = document.getElementById("kvizovi").selectedIndex;

    let container = document.getElementsByClassName("right")[0];
    let selectC = document.getElementById("predmet");
    container.innerHTML = "";
    document.getElementById("kurs").value = selectC.selectedIndex;
    document.getElementById("kviz").value = quizzes[selected].id;
    let label = document.createElement("label");
    label.innerHTML = "Naziv kviza:";
    container.appendChild(label);

    let inp = document.createElement("input");
    inp.value = quizzes[selected].name;
    inp.className = "form-control";
    inp.disabled = true;
    container.appendChild(inp);
}
window.loadQuizzes = function loadQuizzes() {
    let selected= document.getElementById("predmet");
    let select = document.getElementById("kvizovi");
    // Perfection
    fetch("/Competitions/GetQuizzes/?name=" + selected[selected.selectedIndex].value)
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
            let opcija = document.createElement("option");

            quizzes = data;
            data.forEach(x => {
                opcija = document.createElement("option");
                opcija.innerHTML = x.name;
                select.add(opcija);
            });
        })
        .catch(error => console.log(error));
}