using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YoungEnterprise_API.Models;
using Microsoft.AspNetCore.Cors;

namespace YoungEnterprise_API.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class HomeController : Controller
    {
        public IActionResult HomePage()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
