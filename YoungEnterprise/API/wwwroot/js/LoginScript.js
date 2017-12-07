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
                    if (JSON.stringify(data.isSchool) === 'true') {
                        // school login
                        alert("School logged in!");
                        // School Test User (in Mikkels DB):
                        // user: SchoolTest@gmail.com
                        // pass: OM0KLjdn
                        window.location.href = "http://localhost:53112/SchoolStartpage.html"
                    } else {
                        // judge login
                        alert("Judge logged in!");
                        // Judge Test User (in Mikkels DB):
                        // user: JudgeTest@gmail.com
                        // pass: TZuZzlCh
                        window.location.href = "http://localhost:53112/JudgeStartPage.html"
                    }


                    localStorage.setItem("userName", usernameText);
                    alert('Logged in!! :D');

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
});

   