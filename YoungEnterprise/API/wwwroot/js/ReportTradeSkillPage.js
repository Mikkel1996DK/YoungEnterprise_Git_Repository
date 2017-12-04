$(document).ready(function () {

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });

    //window.prompt("Giv Point (1 - 10):", "");

});