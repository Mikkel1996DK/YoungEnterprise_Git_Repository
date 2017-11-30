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
    [EnableCors("AllowSpecificOrigin")]
    public class LoginController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public LoginController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // POST: api/Login?
        [HttpPost]
        public bool ClientLogin ([FromBody] LoginModel loginModel)
        {
            UserService service = new UserService();
            //usr: mikkelljungberg@gmail.com
            //pw: Flou92tl
            return service.CheckJudgeLogin(loginModel.Username, service.HashPassword(loginModel.Username, loginModel.Password));
        }



    }
}
