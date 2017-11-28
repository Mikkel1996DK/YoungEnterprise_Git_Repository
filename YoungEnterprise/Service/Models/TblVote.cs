using System;
using System.Collections.Generic;

namespace YoungEnterprise_API.Models
{
    public partial class TblVote
    {
        public TblVote()
        {
            TblVoteAnswer = new HashSet<TblVoteAnswer>();
        }

        public int FldVoteId { get; set; }
        public int FldJudgePairId { get; set; }
        public string FldTeamName { get; set; }
        public int FldPoints { get; set; }

        public TblJudgePair FldJudgePair { get; set; }
        public TblTeam FldTeamNameNavigation { get; set; }
        public ICollection<TblVoteAnswer> TblVoteAnswer { get; set; }
    }
}
