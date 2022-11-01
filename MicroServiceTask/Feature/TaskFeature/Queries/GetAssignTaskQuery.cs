using MediatR;
using MicroServiceTask.Context;
using MicroServiceTask.Model;
using MicroServiceTask.Model.CommonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroServiceTask.Feature.TaskFeature.Queries
{
    public class GetAssignTaskQuery : IRequest<IEnumerable<TaskModel>>
    {
        public Int64 memberId { get; set; }
        public string TaskName { get; set; }
        public string Deliverables { get; set; }
        public string TaskstartDate { get; set; }
        public string TaskendDate { get; set; }
        
        public class GetAssignTaskQueryHandler : IRequestHandler<GetAssignTaskQuery, IEnumerable<TaskModel>>
        {
            private readonly IApplicationDbContext _context;
            public GetAssignTaskQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TaskModel>> Handle(GetAssignTaskQuery query, CancellationToken cancellationToken)
            {
                
                var taskList = await (from m in _context.Members
                            join t in _context.Tasks
                            on m.MemberId equals t.MemberId
                            where t.MemberId == query.memberId || t.TaskName.ToLower().Trim() == (query.TaskName == null ? string.Empty : query.TaskName.ToLower().Trim())
                || t.Deliverables.ToLower().Trim() == (query.Deliverables == null ? string.Empty : query.Deliverables.ToLower().Trim())|| t.TaskstartDate.ToLower().Trim() == (query.TaskstartDate == null ? string.Empty : query.TaskstartDate.ToLower().Trim())|| t.TaskendDate.ToLower().Trim() == (query.TaskendDate == null ? string.Empty : query.TaskendDate.ToLower().Trim())
                            select new TaskModel
                            {
                                MemberId = t.MemberId,
                                MemberName = t.MemberName,
                                TaskName = t.TaskName,
                                Deliverables = t.Deliverables,
                                TaskendDate = t.TaskendDate,
                                TaskstartDate = t.TaskstartDate,
                                ProjectstartDate = m.ProjectstartDate,
                                ProjectendDate = m.ProjectendDate,
                                AllocationPercentage = m.AllocationPercentage
                            }).ToListAsync();

                //var taskList = await _context.Tasks.Where(x=>x.MemberId==query.memberId ||x.TaskName.ToLower().Trim()==(query.TaskName==null?string.Empty:query.TaskName.ToLower().Trim())
                //|| x.Deliverables.ToLower().Trim() == (query.Deliverables == null ? string.Empty : query.Deliverables.ToLower().Trim())|| x.TaskstartDate.ToLower().Trim() == (query.TaskstartDate == null ? string.Empty : query.TaskstartDate.ToLower().Trim())|| x.TaskendDate.ToLower().Trim() == (query.TaskendDate == null ? string.Empty : query.TaskendDate.ToLower().Trim())).ToListAsync();
                if (taskList.Count==0)
                {
                    var taskLis1t = await (from m in _context.Members
                                          join t in _context.Tasks
                                          on m.MemberId equals t.MemberId
                                          where t.MemberId != 0
                             
                                          select new TaskModel
                                          {
                                              MemberId = t.MemberId,
                                              MemberName = t.MemberName,
                                              TaskName = t.TaskName,
                                              Deliverables = t.Deliverables,
                                              TaskendDate = t.TaskendDate,
                                              TaskstartDate = t.TaskstartDate,
                                              ProjectstartDate = m.ProjectstartDate,
                                              ProjectendDate = m.ProjectendDate,
                                              AllocationPercentage = m.AllocationPercentage
                                          }).ToListAsync();
                    return taskLis1t.AsReadOnly(); ;
                }
                return taskList.AsReadOnly();
            }
        }
    }
   
}
