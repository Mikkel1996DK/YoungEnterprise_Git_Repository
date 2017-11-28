function getProducts() {
    $.getJSON("http://localhost:53112/api/TblTeams",
        function (data) {
            $('#teams').empty(); // Clear the table body.

            // Loop through the list of teams.
            $.each(data, function (key, value) {
                // Add a table row for each team.
                var row = '<td>' + value.fld_TeamName + '</td><td>' + value.fld_SubjectCategory + '</td><td>' + <button Give Grade /> + '</td>';
                $('<tr/>', { text: row })  // Append the name.
                    .appendTo($('#teams'));
            });
        });
}

$(document).ready(getProducts);