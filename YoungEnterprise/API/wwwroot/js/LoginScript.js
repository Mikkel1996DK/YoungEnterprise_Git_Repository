$(document).ready(function () {

    $('#homeMenu').click(function () {
            window.location.href = "http://localhost:53112/HomePage.html";
    });

    $('#programMenu').click(function () {
        window.location.href = "http://localhost:53112/ProgramPage.html";
    });

    $('#aboutMenu').click(function () {
        window.location.href = "http://localhost:53112/AboutPage.html";
    });

    $('#contactMenu').click(function () {
        window.location.href = "http://localhost:53112/ContactPage.html";
    });

    $('#loginButton').click(function () {
        
        // Username and password text variables.
        var usernameText = document.getElementById('emailInput').value;
        var passwordText = document.getElementById('passwordInput').value;

        $.ajax({
            type: 'POST',
            url: 'http://localhost:53112/api/Login',
            data: { Username: usernameText, Password: passwordText },
            success: function (data) {
                if (JSON.stringify(data.authenticated) === 'true') {
                    if (JSON.stringify(data.isSchool) === 'true') {
                        window.location.href = "http://localhost:53112/SchoolStartpage.html"
                    } else {
                        window.location.href = "http://localhost:53112/JudgeStartPage.html"
                    }

                    localStorage.setItem("userName", usernameText);
                } else {
                    alert('Could not login!');
                }
            },
            error: function (data) {
                window.location.href = "ErrorPage.html";
            }
        });

        return false;
    });
});

   