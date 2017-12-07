using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using Microsoft.AspNetCore.Cors;
using YoungEnterprise_API.Models;
using Service.Models;

namespace YoungEnterprise_API.Controllers
{
    [Produces("application/json")]
    [Route("api/TblVoteAnswers")]
    public class TblVoteAnswersController : Controller
    {
        private readonly Models.DB_YoungEnterpriseContext _context;

        public TblVoteAnswersController(Models.DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblVoteAnswers
        [HttpGet]
        public IEnumerable<Models.TblVoteAnswer> GetTblVoteAnswer()
        {
            return _context.TblVoteAnswer;
        }

        // GET: api/TblVoteAnswers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblVoteAnswer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblVoteAnswer = await _context.TblVoteAnswer.SingleOrDefaultAsync(m => m.FldVoteAnswerId == id);

            if (tblVoteAnswer == null)
            {
                return NotFound();
            }

            return Ok(tblVoteAnswer);
        }

        // PUT: api/TblVoteAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblVoteAnswer([FromRoute] int id, [FromBody] Models.TblVoteAnswer tblVoteAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblVoteAnswer.FldVoteAnswerId)
            {
                return BadRequest();
            }

            _context.Entry(tblVoteAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblVoteAnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /*
        // POST: api/TblVoteAnswers
        [HttpPost]
        public async Task<IActionResult> PostTblVoteAnswer([FromBody] Models.TblVoteAnswer tblVoteAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblVoteAnswer.Add(tblVoteAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblVoteAnswer", new { id = tblVoteAnswer.FldVoteAnswerId }, tblVoteAnswer);
        }
        */

        // POST: api/TblVoteAnswers
        [HttpPost]
        //[Route("QuestionsAndVotes")]
        public async Task<IActionResult> PostQuestionAndVotes(QuestionAndVotesModel questionAndVotesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserService userService = new UserService();
            int judgePairID = userService.GetJudgePairID(questionAndVotesModel.JudgeUsername);
            DatabaseService dbService = new DatabaseService();
            return CreatedAtAction("GetQuestionsAndVotes", dbService.FindQuestionsAndVotes(questionAndVotesModel.Category, questionAndVotesModel.Subject, judgePairID, questionAndVotesModel.TeamName));
        }

        // DELETE: api/TblVoteAnswers/5s
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblVoteAnswer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblVoteAnswer = await _context.TblVoteAnswer.SingleOrDefaultAsync(m => m.FldVoteAnswerId == id);
            if (tblVoteAnswer == null)
            {
                return NotFound();
            }

            _context.TblVoteAnswer.Remove(tblVoteAnswer);
            await _context.SaveChangesAsync();

            return Ok(tblVoteAnswer);
        }

        private bool TblVoteAnswerExists(int id)
        {
            return _context.TblVoteAnswer.Any(e => e.FldVoteAnswerId == id);
        }
    }
}