using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTUC.Model
{
    public class MemberModel
    {
      
        public string TeamMemberName { get; set; }

        public Int64 MemberId { get; set; }
        public int YearOfExp { get; set; }
        public string SkillSet { get; set; }
        public string Description { get; set; }
        public string ProjectstartDate { get; set; }
        public string ProjectendDate { get; set; }

        public string AllocationPercentage {get;set;}

    }
}
