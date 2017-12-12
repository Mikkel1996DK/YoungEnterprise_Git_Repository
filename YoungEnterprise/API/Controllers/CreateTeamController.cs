using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/CreateTeam")]
    public class CreateTeamController : Controller
    {
        [HttpPost]
        public IActionResult CreateTeam ()
        {
            IFormFileCollection files = Request.Form.Files;

            foreach(IFormFile file in files)
            {
                Console.WriteLine("_A FILE HERE____________________________________________________________________________________________________");
            }

            return Json("Team Created!");
        }

    }

    public class TeamWithFile
    {
        public string FldTeamName { get; set; }
        public int FldSchoolId { get; set; }
        public string FldSubjectCategory { get; set; }
        public List<IFormFile> FldReports { get; set; }
    }
}