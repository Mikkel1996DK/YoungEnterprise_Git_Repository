$(document).ready(function () {

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });

    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $('#homeMenu').click(function () {
        alert(localStorage.getItem("isSchool"));
        if (localStorage.getItem("isSchool") === 'true') {
            window.location.href = "http://localhost:53112/SchoolStartPage.html";
        }
        else {
            window.location.href = "http://localhost:53112/JudgeStartPage.html";
        }
    });

    $('#programMenu').click(function () {
        window.location.href = "http://localhost:53112/ProgramPageLoggedIn.html";
    });

    $('#aboutMenu').click(function () {
        window.location.href = "http://localhost:53112/AboutPageLoggedIn.html";
    });

    $('#contactMenu').click(function () {
        window.location.href = "http://localhost:53112/ContactPageLoggedIn.html";
    });
});
