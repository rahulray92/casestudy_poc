using MediatR;
using MicroServiceTask.Context;
using MicroServiceTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroServiceTask.Feature.TaskFeature.Queries
{
    public class GetAssignTaskByIdQuery : IRequest<PMTATask>
    {
        public Int64 Id { get; set; }
        public class GetAssignTaskByIdQueryHandler : IRequestHandler<GetAssignTaskByIdQuery, PMTATask>
        {
            private readonly IApplicationDbContext _context;
            public GetAssignTaskByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<PMTATask> Handle(GetAssignTaskByIdQuery query, CancellationToken cancellationToken)
            {
                var task = _context.Tasks.Where(a => a.MemberId == query.Id).FirstOrDefault();
                if (task == null) return null;
                return task;
            }
        }
    }
}
