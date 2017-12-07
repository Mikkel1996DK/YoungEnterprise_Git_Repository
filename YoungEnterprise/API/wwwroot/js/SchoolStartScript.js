﻿$(document).ready(function () {

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

    // Gets teams based on school ID found by schoolusername
    $(function GetTeamsForSchool() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TeamsForSchool',
            data: {
                FldSchoolUsername: localStorage.getItem("userName")
            },
            success: function (data) {

                $('#table').bootstrapTable({
                    data: data
                });
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    });
});

