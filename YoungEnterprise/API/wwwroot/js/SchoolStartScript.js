$(document).ready(function () {

    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });

    $("#createTeamButton").click(function () {
        window.location.href = "http://localhost:53112/CreateTeamPage.html";
    });

    /*
    $(function () {
        $.ajax({
            method: "GET",
            url: "http://localhost:53112/api/TblTeams",
            dataType: "json",
            contentType: "application/json"
        }).then(function (data) {

            $('#table').bootstrapTable({
                data: data
            });
        });
    });
    */

});

