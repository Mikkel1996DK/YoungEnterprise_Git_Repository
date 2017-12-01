$(document).ready(function () {

    $(function() {
        $.ajax({
            method: "GET",
            url: "http://localhost:53112/api/TblTeams",
            dataType: "json",
            contentType: "application/json"
        }).then(function (data) {
            
            $('#table').bootstrapTable({
                data: data
            });

            //alert("Test: " + data[0].fldTeamName + data[0].fldSubjectCategory);
            //    // Loop through the list of teams.
            //for (i = 0; i < data.length; i++) {
            //    // Add a table row for each team.
                
            //    var row = JSON.stringify(data[i].fldTeamName) + JSON.stringify(data[i].fldSubjectCategory);
            //    $('<tr/>','<td/>', { text: row })  
            //        .appendTo($('#teams'));
            //}                  
        });
    });

    $('#table').on('click-row.bs.table', function (e, row, $element) {
        //alert($("#elementId :selected").text());

        // Change HTML page accordling
        window.location.href = "http://localhost:53112/ReportTradeSkillPage.html";

        alert("Hello");
    });
})


