using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using YoungEnterprise_API.Models;

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
            UserService service = new UserService();
            DatabaseService dbService = new DatabaseService();

            // Get Question ID
            int questionID = service.GetQuestionID(createVoteModel.FldQuestiontext, createVoteModel.FldQuestionModifier);

            // get JudgePairID
            int judgePairID = service.GetJudgePairID(createVoteModel.FldJudgeUsername);

            // TODO check if vote alreafy exists!
            // New Vote and get voteID returned
            int voteID = dbService.CreateVote(judgePairID, createVoteModel.FldTeamName, createVoteModel.FldPoints);

            // New VoteAnswer
            dbService.CreateVoteAnswer(questionID, voteID);
            return "Point Gemt!";

        }
    }
}