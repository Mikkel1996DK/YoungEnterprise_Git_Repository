using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoungEnterprise_API.Models
{
    public partial class TblVoteAnswer
    {
        // Fields not mapped to database

        [NotMapped]
        public int Points { get; set; }
        [NotMapped]
        public double QuestionModifier { get; set; }
        [NotMapped]
        public string Questiontext { get; set; }


        // Fields mapped to database
        public int FldVoteAnswerId { get; set; }
        public int FldQuestionId { get; set; }
        public int FldVoteId { get; set; }

        public TblQuestion FldQuestion { get; set; }
        public TblVote FldVote { get; set; }
    }
}
