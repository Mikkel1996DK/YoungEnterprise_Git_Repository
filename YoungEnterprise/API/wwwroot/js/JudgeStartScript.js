$(document).ready(function () {

    $('#teamButton').click(function () {
        $.ajax({
            type: "GET",
            url: "http://localhost:53112/api/TblTeams",
            contentType: "application/json"
        }).then(function (data) {
            alert("Hello");
                $('#teams').empty(); // Clear the table body.

                // Loop through the list of teams.
                $.each(data, function (key, value) {
                    // Add a table row for each team.
                    var row = '<td>' + value.fld_TeamName + '</td><td>' + value.fld_SubjectCategory + '</td><td>' + <button Give Grade /> + '</td>';
                    $('<tr/>', { text: row })  // Append the name.
                        .appendTo($('#teams'));
                });
            });
    })
});

