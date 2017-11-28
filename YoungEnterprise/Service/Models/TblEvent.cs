using System;
using System.Collections.Generic;

namespace YoungEnterprise_API.Models
{
    public partial class TblEvent
    {
        public TblEvent()
        {
            TblJudge = new HashSet<TblJudge>();
            TblTeam = new HashSet<TblTeam>();
        }

        public int FldEventId { get; set; }
        public DateTime FldEventDate { get; set; }

        public ICollection<TblJudge> TblJudge { get; set; }
        public ICollection<TblTeam> TblTeam { get; set; }
    }
}
