
function Hide(num) {

    let div;
    switch (num) {
        case '1':
            div = document.getElementsByClassName("1st-year");
            div[0].hidden = !div[0].hidden;
            break;
        case '2':
            div = document.getElementsByClassName("2nd-year");
            div[0].hidden = !div[0].hidden;
            break;
        case '3':
            div = document.getElementsByClassName("3rd-year");
            div[0].hidden = !div[0].hidden;
            break;
        case '4':
            div = document.getElementsByClassName("4th-year");
            div[0].hidden = !div[0].hidden;
            break;
    }
}

window.HideSubjects = function HideSubjects(num) {
    Hide(num);
}