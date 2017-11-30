﻿$(document).ready(function () {

    $(function() {
        $.ajax({
            method: "GET",
            url: "http://localhost:53112/api/TblTeams",
            dataType: "json",
            contentType: "application/json"
        }).then(function (data) {
                $('#teams').empty(); // Clear the table body.

                // Loop through the list of teams.
                $.each(data, function (key, value) {
                    // Add a table row for each team.
                    var row = '<td>' + value.fld_TeamName + '</td><td>' + value.fld_SubjectCategory + '</td>'
                    $('<tr/>', { text: row })  // Append the name.
                        .appendTo($('#teams'));
                });
        });
    })
});

