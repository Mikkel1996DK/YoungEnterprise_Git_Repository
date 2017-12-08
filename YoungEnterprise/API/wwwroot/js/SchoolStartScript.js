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


    $(function GetSchoolsCreateTeam() {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:53112/api/TblSchools',
            contentType: 'application/json',
            success: function (data) {
                for (i = 0; i < data.length; i++) {
                    console.log(JSON.stringify(data[i]))

                    if (data[i].fldSchoolUsername == 'administrator@bcs.dk')/*localStorage.getItem('userName'))*/ {
                        var identifier = data[i].fldSchoolId;
                        GetTeams(identifier);

                    } else {
                        alert('Could not find current user! Please login again.');
                    }
                }
            }
        });

        function GetTeams(schoolID) {
            $.ajax({
                method: "GET",
                url: "http://localhost:53112/api/TblTeams",
                contentType: "application/json"
            }).then(function (data) {
                for (i = 0; i < data.length; i++) {
                    if (!data[i].fldSchoolId == schoolID) {
                        data.splice(i, 1)
                    }
                }

                $('#table').bootstrapTable({
                    data: data
                });
            });
        };
    });
});