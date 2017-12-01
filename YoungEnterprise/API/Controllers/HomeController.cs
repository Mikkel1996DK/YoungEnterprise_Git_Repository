using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.AspNetCore.Cors;

namespace YoungEnterprise_API.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class HomeController : Controller
    {
        public IActionResult APIStartPage()
        {
            return View();
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult JudgeStartPage()
        {
            ViewData["Message"] = "Your judge page.";
        
            return View();
        }

        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
