﻿$(document).ready(function () {

    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });



        /*
        $('#table').bootstrapTable({
             data: data
        });
        */

    /*
        $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });*/

    $('#CreateTeamButton').click(function () {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:53112/api/TblSchools',
            contentType: 'application/json',
            success: function (data) {
                var identifier;

                for (i = 0; i < data.length; i++) {
                    console.log(JSON.stringify(data[i]))
                    
                    if (data[i].fldSchoolUsername === localStorage.getItem('userName')) {
                        identifier = data[i].fldSchoolId;
                        
                    }
                }

                if (identifier != undefined) {
                    CreateTeam(identifier);
                }
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    });

    function CreateTeam(schoolID) {
        var element = document.getElementById("subjectSelection");
        var subject = element.options[element.selectedIndex].value;
        var name = document.getElementById('nameInput').value;

        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TblTeams',
            data: { FldTeamName: name, FldSchoolId: schoolID, FldSubjectCategory: subject },
            success: function (data) {
                alert('Team oprettet!');

            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    }
});