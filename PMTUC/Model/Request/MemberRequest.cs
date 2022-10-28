using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTUC.Model.Request
{
    /// <summary>
    /// MemberRequest
    /// </summary>
    public class MemberRequest
    {
        public string TeamMemberName { get; set; }
        public Int64 MemberId { get; set; }
        public string ProjectstartDate { get; set; }
        public string ProjectendDate { get; set; }
    }
}
