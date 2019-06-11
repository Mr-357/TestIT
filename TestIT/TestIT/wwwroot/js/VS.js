let q;
let vs;
window.start = function start(quiz, user) {
    q = quiz;
    vs = user;
    const formData = new FormData();
    formData.append("quizid", quiz);
    formData.append("userid", user);
    const fetchData =
    {
        method: "post",
        body: formData,
        redirect: 'follow',
        credentials: 'include' //ovo se dodaje da salje cookie odnosno podatke o korisniku, postoji sansa da vrati error 500 ako se ne posalje ovo
    }
    fetch("/Competitions/VS", fetchData)
        .then(response => {
            if (response.ok)
                return response.json();
            throw response;
        })
        .then(data => { console.log(data);competition(data); })
        .catch(error => console.log(error));
   
}
function competition(comp) {

    window.location.href = "/Quizzes/AttemptQuiz2/?id=" + q + "&comp=" + comp+"&vs="+vs;

}