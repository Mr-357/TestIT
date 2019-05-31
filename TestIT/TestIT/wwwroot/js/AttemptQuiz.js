import { Quiz } from "./Quiz.js";
import { Answer } from "./Answer.js";
import { Question } from "./Question.js";

console.log("Attempt Quiz Hello");
let quiz = null;

window.jsonToQzit = function jsonToQzit(json) { //ova fja moze da se renameuje u crtajkviz ili tako nesto
    quiz = json;
    console.log(quiz);
}

window.submitAnswers = function submitAnswers() {
    let result = getherAnswers();
    console.log(result);
    jsFetch(result);
}

function getherAnswers() {
    let result = new Quiz();
    result.ID = quiz.ID;
    let i = 0;
    quiz.Questions.forEach(question => {
        let tempQuestion = new Question();
        let tempAnswer;
        let answerInput = document.getElementsByName("Q" + i);
        i = i + 1;
        if (answerInput.length == 1) {
            tempAnswer = new Answer();
            tempAnswer.answerText = answerInput.item(0).value;
            tempAnswer.type = "singleText";
            tempQuestion.addAnswer(tempAnswer);
        }
        else if (answerInput.length > 1) {
            for (let j = 0; j < answerInput.length; j++) {
                console.log("I do ovde");
                if (answerInput[j].checked) {
                    tempAnswer = new Answer();
                    tempAnswer.answerText = answerInput[i].value;
                    tempQuestion.addAnswer(tempAnswer);
                }
            }
        }
        result.addQuestion(tempQuestion);
    })
    return result;
}

function jsFetch(result) {
    //console.log(result);
    const formData = new FormData();    
    buildFormData(formData, result);
    const fetchData =
    {
        method: "post",
        body: formData,
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    /*fetch("/Quizzes/Results", fetchData)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else
                window.location.replace("/Quizzes/Results"); //ovde sam hteo da me redirektuje nazad na index stranicu ali mora da se refreshuje index pre nego sto se pojavi novi kviz
            //mozda proradi ako se iskoristi neki tajmer ili tako nesto? u svakom slucaju mi cemo fetch koristiti za in-page a ovo pravljenje kviza moze preko submit-a
            return;
        })
        .catch(error => console.log(error));*/
    fetch("/Quizzes/Results",fetchData)
        .then(response => {
            console.log(response);
            return response.text();
        })
        .then(data => document.write(data))
        .catch(error => console.log(error));

}

//rekurzivno kreiranje formData iz kompleksnog objekta trebalo bi da radi za sve vrste objekata
function buildFormData(formData, data, parentKey) {
    if (data && typeof data === 'object' && !(data instanceof Date) && !(data instanceof File)) {
        Object.keys(data).forEach(key => {
            buildFormData(formData, data[key], parentKey ? `${parentKey}[${key}]` : key);
        });
    } else {
        const value = data == null ? '' : data;

        formData.append(parentKey, value);
    }
}