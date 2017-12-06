using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models
{
    public class QuestionAndVotesModel
    {
        public string TeamName { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public string JudgeUsername { get; set; }
    }
}
