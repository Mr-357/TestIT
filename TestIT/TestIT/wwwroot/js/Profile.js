var done = false;
window.getmodules = function getmodules(modul) {
 
    let select = document.getElementById("moduli");
    fetch("/Home/GetModules")
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
            if (modul == "") {
                opcija.innerHTML = "Modul nije izabran";
                select.add(opcija);
            }
            else { done = true;}
            data.forEach(x => {
                opcija = document.createElement("option");
                opcija.innerHTML = x;
                select.add(opcija);
            });
        })
        .catch(error => console.log(error));
    select = document.getElementById("moduli");

    setTimeout(set, 150,modul);
   
}

window.set = function set(modul) {
 
    let select = document.getElementById("moduli");

    for (let i = 0; i < select.length; i++)
    {
        console.log(select.options[i]);
            if (select.options[i].value == modul)
                select.selectedIndex = i;
        }

}
window.deleteNema = function deleteNema() {

    if (!done) {
        let select = document.getElementById("moduli");

        select.remove(0);
        done = true;
    }
   

}