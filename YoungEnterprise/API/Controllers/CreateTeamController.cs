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
        public String CreateTeam (TeamWithFile team)
        {
            long size;

            IFormFile file = team.FldReports.FirstOrDefault();
            var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            



            return "Team Created!";
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