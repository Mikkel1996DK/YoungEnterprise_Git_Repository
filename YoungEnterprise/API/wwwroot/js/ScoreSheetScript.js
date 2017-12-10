$(document).ready(function () {

    $("#saveButton").click(function () {
        window.location.href = "http://localhost:53112/JudgeStartPage.html";
    });
    // Getting teamName, subject, catagory and judgeusername from local storage
    var subjectText = localStorage.getItem("subject");
    var categoryText = localStorage.getItem("category");
    var teamNameText = localStorage.getItem("teamName");
    var userName = localStorage.getItem("userName");

    // Changes the header team name to include the teamname for chosen team
    $(function () {
        document.getElementById('teamNameField').innerHTML = "Team Name: " + teamNameText;
    });

    // Changes Header od scoresheet to match choosen catagory and team subject
    $(function () {
        document.getElementById('topicField').innerHTML = categoryText + " - " + subjectText;
    });

    

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
                Subject: subjectText,
                Category: categoryText,
                JudgeUsername: userName

            },
            success: function (data) {
                alert(JSON.stringify(data));
              
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

