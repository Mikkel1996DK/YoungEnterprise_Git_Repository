using YoungEnterprise_API.Models;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service
{
    public class VoteService
    {

        private readonly DB_YoungEnterpriseContext _context;

        public VoteService(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        public DbSet<TblTeam> TeamsMissingVote(TblJudgePair judgePair)
        {
            // TODO
            return _context.TblTeam;
        }
        public DbSet<TblTeam> AllTeams(TblEvent evt)
        {
            return _context.TblTeam;
        }

    }
}
