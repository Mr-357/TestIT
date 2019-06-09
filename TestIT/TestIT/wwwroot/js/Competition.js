var done = false;
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