console.log("Hello from edit question");
let question;
let answerQuantity = "";
let answerType = "";
let answerCount;
let img = document.getElementById("imageQ");
let cnvs = document.getElementById("myCanvas");
let tableBody = document.getElementById("tableBody");
window.startUp = function startUp(data) {
    console.log(data);
    question = data;
    answerQuantity = question.Answers.length == 1 ? "single": "multy";
    answerType = question.Answers[0].x1 == null ? "Text" : "Region";
    answerCount = question.Answers.length;
    draw();
    showAnswers();
}

function draw() {
    cnvs.style.position = "absolute";
    cnvs.style.left = img.offsetLeft + "px";
    cnvs.style.top = img.offsetTop + "px";
    cnvs.widht = img.widht;
    cnvs.height = img.height;
    cnvs.hidden = "";
    let ctx = cnvs.getContext("2d");
    ctx.beginPath();
    ctx.lineWidth = 3;
    ctx.strokeStyle = '#00ff00';
    let i = 0;
    question.Answers.forEach(a => {
        ctx.beginPath();
        drawText(a.x1 * img.width, a.y1 * img.height, "T" + (i + 1), ctx);
        ctx.rect(a.x1 * img.width, a.y1 * img.height, (a.x2 * img.width) - (a.x1 * img.width), (a.y2 * img.height) - (a.y1 * img.height));
        i++;
        ctx.stroke();
    })
}

function drawText(x, y, text, ctx) {
    let tempSytyle = ctx.fillStyle;
    ctx.fillStyle = "red";
    ctx.font = "13px Arial";
    ctx.fillText(text, x - 4, y - 4);
    ctx.fillStyle = tempSytyle;
}

window.onImageClick = function onImageClick() {
    let x = event.pageX;
    let y = event.pageY;
    x = (x - img.offsetLeft) / img.width;
    y = (y - img.offsetTop) / img.height;
    let recWidth = 100;
    let recdepth = 50;
    addRegionAnswer(x, y, x + (recWidth / img.width), y + (recdepth / img.height));
    draw();
}


function addRegionAnswer(x1, y1, x2, y2) {
    let tempAnswer = {};
    tempAnswer.x1 = x1;
    tempAnswer.x2 = x2;
    tempAnswer.y1 = y1;
    tempAnswer.y2 = y2;
    tempAnswer.type = answerQuantity + "-" + answerType;
    if (answerQuantity == "single")
        question.Answers = [];
    question.Answers.push(tempAnswer);
    showAnswers();
}

function showAnswers() {
    multyAnswerArea.hidden = "";
    tableBody.innerHTML = "";
    let i = 0;
    for (let i = 0; i < question.Answers.length; i++) {
        showAnswer(question.Answers[i], i );
    }
    draw();
}

function showAnswer(answer, index) {
    let tr = document.createElement("tr");
    let tempLabel = document.createElement("label");
    let td = document.createElement("td");
    let infoDiv = document.createElement("div");
    td.appendChild(infoDiv);
    tr.appendChild(td);
    if (answerType.includes("Text")) {
        tempLabel.innerHTML = answer.answerText;
        if (answerQuantity == "multy") {
            let checkBox = document.createElement("input");
            checkBox.type = "checkbox"
            checkBox.onclick = function () { togleCorrect(index); };
            td = document.createElement("td");
            td.appendChild(checkBox);
            tr.appendChild(td);
        }
    }
    else if (answerType.includes("Region")) {
        let widthEditBox = document.createElement("input");
        widthEditBox.value = (answer.x2 - answer.x1) * img.width;
        widthEditBox.onchange = function () { areaChange(widthEditBox.value, index, true) }
        let heightEditBox = document.createElement("input");
        heightEditBox.value = (answer.x2 - answer.x1) * img.height;
        heightEditBox.onchange = function () { areaChange(heightEditBox.value, index,false) }
        tempLabel.innerHTML = "T" + (index + 1); 
        infoDiv.appendChild(tempLabel);
        infoDiv.appendChild(widthEditBox);
        infoDiv.appendChild(heightEditBox);
    }
    if (answerQuantity == "multy") {
        let button = document.createElement("input");
        button.type = "button";
        button.value = "x";
        button.className = "btn btn-danger"
        button.onclick = function () { removeAnswer(index); };
        td = document.createElement("td");
        td.appendChild(button);
        tr.appendChild(td);
    }
    tableBody.appendChild(tr);
}
function togleCorrect(index) {
    question.Answers[index].isCorrect = !QuestionTemplate.Answers[index].isCorrect
    console.log(QuestionTemplate.Answers[index]);
}

function removeAnswer(index) {
    question.Answers.splice(index, 1);
    showAnswers();
}

function areaChange(size,index, isWidthEdit) {
    let answer = question.Answers[index];

    if (isWidthEdit) {
        size = size / img.width;
        answer.x2 = question.Answers[index].x1 + size;
    } else if (!isWidthEdit) {
        size = size / img.height;
        answer.y2 = question.Answers[index].y1 + size;
    }
    draw();
}