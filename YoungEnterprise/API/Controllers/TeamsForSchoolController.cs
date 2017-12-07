using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using YoungEnterprise_API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/TeamsForSchool")]
    public class TeamsForSchoolController : Controller
    {
        // POST: api/TeamsForSchool
        [HttpPost]
        public List<TblTeam> GetTeamsForSchool(String schoolUsername)
        {
            UserService userService = new UserService();
            DatabaseService dbService = new DatabaseService();

            int schoolID = userService.GetSchoolID(schoolUsername);

            return dbService.GetTeamsForSchool(schoolID);
        }
    }
}