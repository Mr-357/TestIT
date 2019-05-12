import { Quiz } from "./Quiz.js";
import { Answer } from "./Answer.js";
import { Question } from "./Question.js";

console.log("Attempt Quiz Hello");
let quiz = null;

window.jsonToQzit = function jsonToQzit(json) { //ova fja moze da se renameuje u crtajkviz ili tako nesto
    quiz = json;
    console.log(quiz);
    let test = document.createElement("label");
    test.innerHTML = quiz.Name;
    document.getElementsByClassName("display-1")[0].appendChild(test);
}
