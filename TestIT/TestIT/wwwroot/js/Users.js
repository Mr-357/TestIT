window.ShowQuizzes = function ShowQuizzes(course) {
    let td = document.getElementsByClassName("courses");
    switch (course) {
        case "SI":
            td[0].style = "background-color:#5190b6; color:white";
            break;
    }
    Draw();
}
function Draw(){
    let div = document.getElementsByClassName("right-container");

    let table = document.createElement("table");
    table.className="table custom-table";

    let thead = document.createElement("thead")
    let tr = document.createElement("tr")
    let p = document.createElement("p")
    p.innerHTML = "Kvizovi za izabrani predmet"
    p.style="text-align:center"
    tr.appendChild(p);
    thead.appendChild(tr)
    table.appendChild(thead);

    let tbody = document.createElement("tbody")
    tr = document.createElement("tr")
    let td = document.createElement("td")
    td.innerHTML = "Agilna metodologija"
    tr.appendChild(td);
    tbody.appendChild(tr)

    tr = document.createElement("tr")
    td = document.createElement("td")
    td.innerHTML = "Scrum proces"
    tr.appendChild(td);
    tbody.appendChild(tr)

    tr = document.createElement("tr")
    td = document.createElement("td")
    td.innerHTML = "Waterfall model"
    tr.appendChild(td);
    tbody.appendChild(tr)

    table.appendChild(tbody);
    div[0].appendChild(table);
}