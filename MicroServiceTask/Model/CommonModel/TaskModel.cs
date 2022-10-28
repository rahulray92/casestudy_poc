using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Model.CommonModel
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string MemberName { get; set; }

        public Int64 MemberId { get; set; }

        public string TaskName { get; set; }

        public string Deliverables { get; set; }


        public string TaskstartDate { get; set; }

        public string TaskendDate { get; set; }
        public string ProjectstartDate { get; set; }

        public string ProjectendDate { get; set; }
        public string AllocationPercentage { get; set; }
    }
}
