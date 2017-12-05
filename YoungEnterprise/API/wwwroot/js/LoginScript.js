//Test User:
//usr: mikkelljungberg@gmail.com
//pw: 8YGPAQqC
//dawdawdwa

$(document).ready(function () {
  
    $('#loginButton').click(function () {
        
        // Username and password text variables.
        var usernameText = document.getElementById('emailInput').value;
        var passwordText = document.getElementById('passwordInput').value;

        alert(JSON.stringify({ username: usernameText, password: passwordText } ));

        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/Login',
            data: { Username: usernameText, Password: passwordText },
            success: function (data) {
                alert(JSON.stringify(data));
                if (JSON.stringify(data.authenticated) === 'true') {
                    localStorage.setItem("userName", usernameText);
                    alert('Logged in!! :D');
                    window.location.href = "http://localhost:53112/JudgeStartPage.html"

                } else {
                    alert('Could not login!! :D');
                }
            },
            error: function (data) {
                console.log(data.statusCode);
            }
        });


        return false;
    });

    // Make regular post, then use .then to get the true/false.
});

   