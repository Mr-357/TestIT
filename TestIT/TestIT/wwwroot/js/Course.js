import {Comment} from "./Comment.js"
window.SubmitComment = function SubmitComment(ID) {
    let textArea = document.getElementsByClassName("comment-content");
    let comment = new Comment(textArea[0].value, ID);
    const formData = new FormData();
    buildFormData(formData, comment);
    const fetchData =
    {
        method: "POST",
        body: formData,
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Courses/Comment", fetchData)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
            else
                window.location.reload(); 
            return;
        })
        .catch(error => console.log(error));
}
function buildFormData(formData, data, parentKey) {
    if (data && typeof data === 'object' && !(data instanceof Date) && !(data instanceof File)) {
        Object.keys(data).forEach(key => {
            buildFormData(formData, data[key], parentKey ? `${parentKey}[${key}]` : key);
        });
    } else {
        if (data instanceof File) {
            console.log("uraido sam ovo za File");
            console.log(data);
        }

        const value = data == null ? '' : data;

        formData.append(parentKey, value);
    }
}