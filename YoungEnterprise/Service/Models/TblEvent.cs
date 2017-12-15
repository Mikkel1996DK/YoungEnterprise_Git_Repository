using System;
using System.Collections.Generic;

namespace Service.Models
{
    public partial class TblEvent
    {
        public TblEvent()
        {
            TblJudge = new HashSet<TblJudge>();
        }

        public int FldEventId { get; set; }
        public DateTime FldEventDate { get; set; }

        public ICollection<TblJudge> TblJudge { get; set; }
    }
}
