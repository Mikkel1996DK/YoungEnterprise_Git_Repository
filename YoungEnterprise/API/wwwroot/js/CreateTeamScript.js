$("#logoutButton").click(function () {
    window.location.href = "http://localhost:53112/HomePage.html";
});

$(function () {
    var userName = localStorage.getItem("userName");
    document.getElementById('userNameField').innerHTML = userName;
});


// Create new team
    $(function GetTeamsForSchool() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TblTeams/ForSchool',
            data: {
                FldSchoolUsername: localStorage.getItem("userName"),
                FldTeamName: ,
                FldEventId:  ,
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