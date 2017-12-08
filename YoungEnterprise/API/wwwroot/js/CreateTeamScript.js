$(document).ready(function () {

    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });

    $(function GetSchoolsCreateTeam() {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:53112/api/TblSchools',
            contentType: 'application/json',
            success: function (data) {
                for (i = 0; i < data.length; i++) {
                    console.log(JSON.stringify(data[i]))

                    if (data[i].fldSchoolUsername === localStorage.getItem('userName')) {
                        var identifier = data[i].fldSchoolId;



                    } else {
                        alert('Could not find current user! Please login again.');
                    }


                }



            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });

        /*
        $('#table').bootstrapTable({
             data: data
        });
        */

    });
});