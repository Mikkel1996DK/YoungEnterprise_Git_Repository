using System;
using System.Collections.Generic;

namespace YoungEnterprise_API.Models
{
    public partial class TblJudge
    {
        public TblJudge()
        {
            TblJudgePairFldJudgeIdaNavigation = new HashSet<TblJudgePair>();
            TblJudgePairFldJudgeIdbNavigation = new HashSet<TblJudgePair>();
        }

        public int FldJudgeId { get; set; }
        public int FldEventId { get; set; }
        public string FldJudgeUsername { get; set; }
        public string FldJudgePassword { get; set; }
        public string FldJudgeName { get; set; }

        public TblEvent FldEvent { get; set; }
        public ICollection<TblJudgePair> TblJudgePairFldJudgeIdaNavigation { get; set; }
        public ICollection<TblJudgePair> TblJudgePairFldJudgeIdbNavigation { get; set; }
    }
}
