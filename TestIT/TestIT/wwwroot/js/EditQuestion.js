console.log("Hello from edit question");
let question;
let img = document.getElementById("imageQ");
let cnvs = document.getElementById("myCanvas");
window.startUp = function startUp(data) {
    console.log(data);
    question = data;
    draw();
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
        drawText(a.RightX1 * img.width, a.RightY1 * img.width, "T" + (i + 1), ctx);
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