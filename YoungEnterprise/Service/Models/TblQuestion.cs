using System.Collections.Generic;

namespace Service.Models
{
    public partial class TblQuestion
    {
        public TblQuestion()
        {
            TblVoteAnswer = new HashSet<TblVoteAnswer>();
        }

        public int FldQuestionId { get; set; }
        public string FldQuestionText { get; set; }
        public string FldQuestionCategori { get; set; }
        public string FldQuestionSubject { get; set; }
        public double FldQuestionModifier { get; set; }

        public ICollection<TblVoteAnswer> TblVoteAnswer { get; set; }
    }
}
