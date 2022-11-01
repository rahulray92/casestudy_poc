using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTUC.Model.Request
{
    public class AllocationRequest
    {
        public string allocationPercentage { get; set; }
        public int memberId { get; set; }
    }
}
