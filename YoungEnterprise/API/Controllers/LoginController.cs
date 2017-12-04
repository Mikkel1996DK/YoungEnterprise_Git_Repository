using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            Console.WriteLine("Hello test Hello________________________________________________________");

            UserService service = new UserService();

            Console.WriteLine("USERNAME: " + loginModel.Username + "        PASSWORD: " + loginModel.Password);

            //Test User:
            //usr: mikkelljungberg@gmail.com
            //pw: ls99cTO9
            AuthenticationModel authModel = new AuthenticationModel();
            authModel.Authenticated = service.CheckJudgeLogin(loginModel.Username, service.HashPassword(loginModel.Username, loginModel.Password));

            return authModel;
        }
    }
}