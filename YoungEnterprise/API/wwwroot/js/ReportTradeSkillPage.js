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
            //dataType: "json",
            //contentType: "application/json",
            url: 'http://localhost:53112/api/TblVoteAnswers',
            data: {
                TeamName: teamNameText,
                Subject: categoryText,
                Category: subjectText,
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
});