$(document).ready(function () {

    $("#saveButton").click(function () {
        window.location.href = "http://localhost:53112/JudgeStartPage.html";
    });
    // Getting teamName, subject, catagory and judgeusername from local storage
    var subjectText = localStorage.getItem("subject");
    var categoryText = localStorage.getItem("category");
    var teamNameText = localStorage.getItem("teamName");
    var userName = localStorage.getItem("userName");

    $(function () {
        //var btn = document.getElementById('reportButton');
        if (localStorage.getItem("category") === 'Report') {
            document.getElementById("reportButton").style.display = "block";
        } else {
            document.getElementById("reportButton").style.display = "none";
        }
    });

    // Changes the header team name to include the teamname for chosen team
    $(function () {
        document.getElementById('teamNameField').innerHTML = "Team Name: " + teamNameText;
    });

    // Changes Header od scoresheet to match choosen catagory and team subject
    $(function () {
        document.getElementById('topicField').innerHTML = categoryText + " - " + subjectText;
        GetQuestionsAndVotes();
    });

    // Posting the four parameters to know which questions and votes for judgepair to vote for specific team
    function GetQuestionsAndVotes() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TblVoteAnswers',
            data: {
                TeamName: teamNameText,
                Subject: subjectText,
                Category: categoryText,
                JudgeUsername: userName

            },
            success: function (data) {
                $('#table').bootstrapTable({
                    data: data
                });
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    }

    $('#table').on('click-row.bs.table', function (e, row, $element) {
        var Questiontext = row["questiontext"];
        var QuestionModifier = row["questionModifier"];
        var points = prompt("Giv Point (1-10):");
        SavePoints(points, Questiontext, QuestionModifier);
    });

    $('#reportButton').click(function () {
        var name = localStorage.getItem("teamName");

            $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/DownloadReport',
            xhrFields: {
                responseType: 'blob'
            },
            data: { TeamName: name },
            success: function (blob) {

                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = name + '-rapport.pdf';
                link.click();
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });



    });

















});

function SavePoints(points, questionText, questionModifier) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/CreateVote',
            data: {

                FldTeamName: localStorage.getItem("teamName"),
                FldJudgeUsername: localStorage.getItem("userName"),
                FldPoints: points,
                FldQuestionText: questionText,
                FldQuestionModifier: questionModifier
            },
            success: function (data) {
                alert("Point Gemt!");
                    window.location.reload(true);
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
    };

