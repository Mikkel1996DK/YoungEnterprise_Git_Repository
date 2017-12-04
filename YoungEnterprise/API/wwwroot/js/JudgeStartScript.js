$(document).ready(function () {

    $(function () {
        var userName = localStorage.getItem("userName")

        alert(userName);

        document.getElementById('userNameField').innerHTML = userName;
    });

    $(function () {
        $.ajax({
            method: "GET",
            url: "http://localhost:53112/api/TblTeams",
            dataType: "json",
            contentType: "application/json"
        }).then(function (data) {

            $('#table').bootstrapTable({
                data: data
            });
        });

    });

        $('#table').on('click-row.bs.table', function (e, row, $element) {
         
            var element = document.getElementById("categorySelection");
            var selectedItem = element.options[element.selectedIndex].value;
            localStorage.setItem("catagory", selectedItem);


            // Get Info of TeamName and SubjectCatagory and send to local storage
            
            var TeamName = row["fldTeamName"];
            var SubjectCatagory = row["SubjectCatagory"];
            localStorage.setItem("TeamName", TeamName);
            localStorage.setItem("SubjectCatagory", SubjectCatagory);

            // Change HTML page accordling
            window.location.href = "http://localhost:53112/ReportTradeSkillPage.html";
        });
});
