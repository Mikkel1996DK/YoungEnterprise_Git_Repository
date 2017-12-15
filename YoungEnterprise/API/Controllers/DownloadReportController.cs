using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;

namespace API.Controllers
{
    [Produces("application/pdf")]
    [Route("api/DownloadReport")]
    public class DownloadReportController : Controller
    {
        DatabaseService dbService = new DatabaseService();

        [HttpPost]
        public async Task<IActionResult> DownloadReport (DownloadReportTeamName name)
        {
            TblTeam team = dbService.GetSpecificTeam(name.TeamName);
            return File(team.FldReport, "application/pdf");
        }
    }
}