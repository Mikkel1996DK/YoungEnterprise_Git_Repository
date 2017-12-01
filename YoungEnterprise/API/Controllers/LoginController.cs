using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using Microsoft.AspNetCore.Cors;
using YoungEnterprise_API.Models;
using Service.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private DB_YoungEnterpriseContext _context;

        public LoginController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> ClientLogin ([FromBody] UserPassModel loginModel)
        {
            Console.WriteLine("Hello test Hello________________________________________________________");

            _context = new YoungEnterprise_API.Models.DB_YoungEnterpriseContext();

            UserService service = new UserService();

            Console.WriteLine("USERNAME: " + loginModel.Username + "        PASSWORD: " + loginModel.Password);



            var loggedIn = await _context.TblJudge.SingleOrDefaultAsync(n => n.FldJudgeUsername == loginModel.Username 
                                 && n.FldJudgePassword == service.HashPassword(loginModel.Username, loginModel.Password));

            if (loggedIn == null)
            {
                return NotFound();
            }

            Console.WriteLine("USER PASS ________________________________________________________" + service.CheckJudgeLogin(loginModel.Username, service.HashPassword(loginModel.Username, loginModel.Password)));

            //Test User:
            //usr: mikkelljungberg@gmail.com
            //pw: Flou92tl

            

            AuthenticationModel authModel = new AuthenticationModel();
            authModel.Authenticated = service.CheckJudgeLogin(loginModel.Username, service.HashPassword(loginModel.Username, loginModel.Password));

            return Json(new { authenticated = authModel.Authenticated });
        }



    }
}
