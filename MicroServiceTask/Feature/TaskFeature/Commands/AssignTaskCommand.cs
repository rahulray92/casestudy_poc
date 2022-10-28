using MediatR;
using MicroServiceTask.Context;
using MicroServiceTask.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroServiceTask.Feature.TaskFeature.Commands
{
    public class AssignTaskCommand : IRequest<int>
    {
        //public int MemberId { get; set; }
        //public string MemberName { get; set; }
        public string Deliverables { get; set; }
        public string TaskName { get; set; }
        public string TaskstartDate { get; set; }
        public string TaskendDate { get; set; }
        public class AssignTaskCommandHandler : IRequestHandler<AssignTaskCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AssignTaskCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AssignTaskCommand command, CancellationToken cancellationToken)
            {
                var memberDetails = await _context.Members.ToListAsync();
                int data = 0;
                if (memberDetails != null)
                {
                    DateTime d1, d2, d3;
                    d1 = DateTime.Parse(command.TaskstartDate, new CultureInfo("en-US", true));
                    d2 = DateTime.Parse(command.TaskendDate, new CultureInfo("en-US", true));
                    if (d2.Date < d1.Date)
                        throw new Exception("Task end date should be greater than task start date");
                    else
                    {
                        foreach (var item in memberDetails)
                        {
                            d3 = DateTime.Parse(item.ProjectendDate, new CultureInfo("en-US", true));
                            if (d2.Date > d3.Date)
                                throw new Exception("Task end date should not  be greater thean project end date");
                            else
                            {
                                var task = new PMTATask();
                                task.MemberId = item.MemberId;
                                task.MemberName = item.TeamMemberName;
                                task.Deliverables = command.Deliverables;
                                task.TaskName = command.TaskName;
                                task.TaskstartDate = command.TaskstartDate;
                                task.TaskendDate = command.TaskendDate;
                                _context.Tasks.Add(task);
                                data =await _context.SaveChanges();
                                //tasks.MemberName = item.TeamMemberName;
                                //tasks.MemberId = item.MemberId;
                                //data = await _task.AddNewTask(tasks);
                            }

                        }
                    }

                }
               return data;

               
               // return task.TaskId;
            }
        }
    }
    
}
