using System;
using System.Collections.Generic;

namespace YoungEnterprise_API.Models
{
    public partial class TblJudgePair
    {
        public TblJudgePair()
        {
            TblVote = new HashSet<TblVote>();
        }

        public int FldJudgePairId { get; set; }
        public int FldJudgeIda { get; set; }
        public int FldJudgeIdb { get; set; }

        public TblJudge FldJudgeIdaNavigation { get; set; }
        public TblJudge FldJudgeIdbNavigation { get; set; }
        public ICollection<TblVote> TblVote { get; set; }
    }
}
