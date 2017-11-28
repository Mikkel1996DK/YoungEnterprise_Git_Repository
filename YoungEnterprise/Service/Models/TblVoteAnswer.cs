using System;
using System.Collections.Generic;

namespace YoungEnterprise_API.Models
{
    public partial class TblVoteAnswer
    {
        public int FldVoteAnswerId { get; set; }
        public int FldQuestionId { get; set; }
        public int FldVoteId { get; set; }

        public TblQuestion FldQuestion { get; set; }
        public TblVote FldVote { get; set; }
    }
}
