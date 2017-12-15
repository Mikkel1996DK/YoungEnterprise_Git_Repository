using System.Collections.Generic;

namespace Service.Models
{
    public partial class TblTeam
    {
        public TblTeam()
        {
            TblVote = new HashSet<TblVote>();
        }

        public string FldTeamName { get; set; }
        public int FldSchoolId { get; set; }
        public string FldSubjectCategory { get; set; }
        public byte[] FldReport { get; set; }

        public TblSchool FldSchool { get; set; }
        public ICollection<TblVote> TblVote { get; set; }
    }
}
