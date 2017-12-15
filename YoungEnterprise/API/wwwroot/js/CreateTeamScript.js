$(document).ready(function () {

    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });

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


        var fileUpload = $("#files").get(0);
        var files = fileUpload.files;
        var data = new FormData();

        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }

        data.append('TeamName', name)
        data.append('SubjectCategory', subject);
        data.append('SchoolID', schoolID)

        $.ajax({
            type: "POST",
            url: "api/UploadReport",
            contentType: false,
            processData: false,
            data: data,
            success: function (message) {
                alert(message);
            },
            error: function () {
                alert("There was error uploading files!");
            }
        });
    }
});