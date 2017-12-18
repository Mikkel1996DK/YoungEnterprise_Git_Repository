using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/CreateVote")]
    public class CreateVoteController : Controller
    {
        // POST: api/CreateVote
        [HttpPost]
        public String CreateVote(CreateVoteModel createVoteModel)
        {
            DatabaseService dbService = new DatabaseService();

            dbService.Vote(createVoteModel);
            return "Point Gemt!";
        }
    }
}