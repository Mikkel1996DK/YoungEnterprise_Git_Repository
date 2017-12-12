using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/UploadReport")]
    public class UploadReportController : Controller
    {
        [HttpPost]
        public IActionResult UploadFilesAjax()
        {
            DatabaseService dbService = new DatabaseService();

            IFormCollection formCollection = Request.Form;
            

            string teamName = null;
            string teamSubjectCategory = null;
            string schoolID = null;

            foreach (string key in formCollection.Keys)
            {
                string value = formCollection[key.ToString()];

                switch (key)
                {
                    case "TeamName":
                        teamName = value;
                        break;
                    case "SubjectCategory":
                        teamSubjectCategory = value;
                        break;
                    case "SchoolID":
                        schoolID = value;
                        break;
                }
            }
            if (schoolID != null && teamName != null && teamSubjectCategory != null)
            {
                int teamSchoolID = int.Parse(schoolID);
                IFormFile file = formCollection.Files.FirstOrDefault();
                byte[] bytes = null;

                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        bytes = ms.ToArray();
                    }
                }

                dbService.CreateTeam(teamName, teamSchoolID, teamSubjectCategory, bytes);

                return Json("Team " + "'" + teamName + "'"  + " oprettet!");
            } else
            {
                return Json("Team Creation Failed! Contact Administrator");
            }
        }






    }
}