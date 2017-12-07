using System;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {

        // POST: api/Login
        [HttpPost]
        public AuthenticationModel ClientLogin(UserPassModel loginModel)
        {
            UserService service = new UserService();

            //Test User:
            //usr: mikkelljungberg@gmail.com
            //pw: ls99cTO9
            AuthenticationModel authModel = new AuthenticationModel();

            authModel.IsSchool = false;
            authModel.Authenticated = service.CheckJudgeLogin(loginModel.Username, service.HashPassword(loginModel.Username, loginModel.Password));
            if (authModel.Authenticated)
            {
                return authModel;
            }

            authModel.IsSchool = true;
            authModel.Authenticated = service.CheckSchoolLogin(loginModel.Username, service.HashPassword(loginModel.Username, loginModel.Password));
            if (authModel.Authenticated)
            {
                return authModel;
            }

            return authModel;
        }
    }
}