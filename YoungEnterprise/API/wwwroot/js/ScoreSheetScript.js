$(document).ready(function () {

    $("#logoutButton").click(function () {
        window.location.href = "http://localhost:53112/HomePage.html";
    });

    $(function () {
        var userName = localStorage.getItem("userName");
        document.getElementById('userNameField').innerHTML = userName;
    });

    // Getting teamName from local storage and changes the header team name to include the teamname fr chosen team
    $(function () {
        var teamNameText = localStorage.getItem("teamName");
        document.getElementById('teamNameField').innerHTML = "Team Name: " + teamNameText;
    });

    // Getting teamName, subject, catagory and judgeusername from local storage
    var subjectText = localStorage.getItem("subject");
    var categoryText = localStorage.getItem("catagory");
    var teamNameText = localStorage.getItem("teamName");
    var userName = localStorage.getItem("userName");

    //Test User:
    //usr: mikkelljungberg@gmail.com
    //pw: 8YGPAQqC

    // Posting the four parameters to know which questions and votes for judgepair to vote for specific team
    $(function GetQuestionsAndVotes() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TblVoteAnswers',
            data: {
                TeamName: teamNameText,
                Subject: categoryText,
                Category: subjectText,
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
    });

    $('#table').on('click-row.bs.table', function (e, row, $element) {
        //var Questiontext = row["questiontext"];
        //var QuestionModifier = row["questionModifier"];

        //var QuestionText = "1234";
        //var QuestionModifier = 1.5;
        //alert(Questiontext, questionModifier);
        var points = prompt("Giv Point (1-10):");
        SavePoints(points, "Hvem var Jesus", 1.5);
        GetQuestionsAndVotes();
        
    });

});

function SavePoints(points, questionText, questionModifier) {
    alert("Hello");
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

            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });
};

