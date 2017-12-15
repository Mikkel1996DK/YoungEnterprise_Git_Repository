namespace Service.Models
{
    public class CreateVoteModel
    {
        public string FldTeamName { get; set; }
        public int FldPoints { get; set; }
        public string FldQuestiontext { get; set; }
        public double FldQuestionModifier { get; set; }
        public string FldJudgeUsername { get; set; }
    }
}
