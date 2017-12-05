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
    var catagoryText = localStorage.getItem("catagory");
    var teamNameText = localStorage.getItem("teamName");
    var userName = localStorage.getItem("userName");


    // Getting judgepairID
    $(function getJudgePairID() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/TblJudgePairsID',
            data: {
                "FldJudgeID": 0,
                "FldEventID": 0,
                "FldJudgeUsername": userName,
                "FldJudgePassword": "",
                "FldJudgeName": ""
            },
            success: function (data) {
                var judgepairID = data;
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });

    });

    var judgepairID = getJudgePairID();


    // Posting the four parameters to know which questions and votes for judgepair to vote for specific team
    $(function getJudgePairID() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/',
            data: {
                TeamName: teamNameText,
                Subject: subjectText,
                Catagory: catagoryText,
                JudgepairID =  judgepairID
            },
            success: function (data) {


            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });

        //window.prompt("Giv Point (1 - 10):", "");
    });
});