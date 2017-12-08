$(document).ready(function () {

    var selectedTeamName;
    var selectedTeamObj;

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

    $('#table').on('click-row.bs.table', function (e, row, $element) {
        selectedTeamName = row["fldTeamName"];
    });


    $("#deleteButton").click(function GetAndDeleteTeam() {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:53112/api/TblTeams',
            contentType: 'application/json',
            success: function (data) {
                for (i = 0; i < data.length; i++) {
                    if (data[i].fldTeamName === selectedTeamName) {
                        selectedTeamObj = data[i];
                    }
                }

                if (selectedTeamObj == undefined) {
                    alert('Could not find team!');
                } else {
                    alert(selectedTeamObj.fldTeamName);
                    DeleteTeam(selectedTeamObj);
                }
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    });

    function DeleteTeam(team) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:53112/api/TblTeams/' + team.fldTeamName,
            success: function (data) {
                location.reload();
            },
            error: function(data) {
                console.log(data.statusCode);
            }
        });
    };





    $(function GetSchoolID() {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:53112/api/TblSchools',
            contentType: 'application/json',
            success: function (data) {
                for (i = 0; i < data.length; i++) {
                    console.log(JSON.stringify(data[i]))

                    if (data[i].fldSchoolUsername == localStorage.getItem('userName'))/*'administrator@bcs.dk'*/ {
                        var identifier = data[i].fldSchoolId;
                        alert(identifier);
                        GetTeams(identifier);

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
                var jsonData = [];

                for (i = 0; i < data.length; i++) {
                    if (data[i].fldSchoolId === schoolID) {
                        jsonData.push({
                            "fldTeamName": data[i].fldTeamName,
                            "fldSchoolId": data[i].fldSchoolId,
                            "fldSubjectCategory": data[i].fldSubjectCategory,
                            "fldReport": data[i].fldReport
                        });
                    }
                }

                if (jsonData.length === 0) {

                } else {
                    $('#table').bootstrapTable({
                        data: jsonData
                    });
                }
            });
        };
    });
});