using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using YoungEnterprise_API.Models;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/DownloadReport")]
    public class DownloadReportController : Controller
    {
        DatabaseService dbService = new DatabaseService();

        //schooltest2@gmail.com
        //JGU8oR8u

        //judge@gmail.com
        //QJFquuXn

        [HttpPost]
        public async Task<IActionResult> DownloadReport (DownloadReportTeamName name)
        {
            Console.WriteLine("______________________________TEAM NAME: " + name.TeamName);
            TblTeam team = dbService.GetSpecificTeam(name.TeamName);



            return File(team.FldReport, "application/pdf");
        }
    }

    public class DownloadReportTeamName
    {
        public string TeamName { get; set; }
    }
}