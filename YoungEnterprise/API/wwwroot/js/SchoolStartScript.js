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

    $(function () {
        $.ajax({
            method: "GET",
            url: "http://localhost:53112/api/TblTeams",
            contentType: "application/json"
        }).then(function (data) {
            for (i = 0; i < data.length; i++) {
                if (!data[i].schoolID == schoolID) {
                    data.splice(i, 1)
                }
            }

            $('#table').bootstrapTable({
                data: data
            });
        });
    });

    /*
    // Gets teams based on school ID found by schoolusername
    $(function GetTeamsForSchool() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TeamsForSchool',
            data: {
                SchoolUsername: localStorage.getItem("userName")
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
    })
    */
});

