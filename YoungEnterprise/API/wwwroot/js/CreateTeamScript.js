$(document).ready(function () {

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

    $(function GetSchoolsCreateTeam() {
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

                }
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    });

    function CreateTeam() {
        $.ajax({
            type: 'POST',
            url: '',
            contentType: 'application/json',
            data: { FldTeamName: , FldSchoolId: , FldSubjectCategory: ,  },
            success: function (data) {
                alert('Team created!')


            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    }
});