using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using YoungEnterprise_API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/TeamsForSchool")]
    public class TeamsForSchoolController : Controller
    {
        // POST: api/TeamsForSchool
        [HttpPost]
        public List<TblTeam> GetTeamsForSchool([FromBody] TeamsForSchoolModel model)
        {
            UserService userService = new UserService();
            DatabaseService dbService = new DatabaseService();

            int schoolID = userService.GetSchoolID(model.SchoolUsername);

            return dbService.GetTeamsForSchool(schoolID);
        }
    }
}