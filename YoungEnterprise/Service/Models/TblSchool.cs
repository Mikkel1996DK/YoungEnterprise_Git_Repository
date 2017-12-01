using System;
using System.Collections.Generic;

namespace YoungEnterprise_API.Models
{
    public partial class TblSchool
    {
        public TblSchool()
        {
            TblTeam = new HashSet<TblTeam>();
        }

        public int FldEventId { get; set; }
        public int FldSchoolId { get; set; }
        public string FldSchoolUsername { get; set; }
        public string FldSchoolPassword { get; set; }
        public string FldSchoolName { get; set; }

        public TblEvent FldEvent { get; set; }
        public ICollection<TblTeam> TblTeam { get; set; }
    }
}
