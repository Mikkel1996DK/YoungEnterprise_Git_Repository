$(document).ready(function () {
    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });



    function () {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:53112/api/TblSchools',
            contentType: 'application/json',
            success: function (data) {
                for (i = 0; i < data) {

                }


            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    }



    // Create new team
    $(function CreateTeam() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TblTeam',
            data: {
                FldSchoolUsername: localStorage.getItem("userName"),
                FldTeamName: ,
                FldSubjectCategory: ,
                FldReport:
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