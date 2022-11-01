using AutoMapper;
using MediatR;
using MicroServiceTask.Feature.TaskFeature.Commands;
using MicroServiceTask.Feature.TaskFeature.Queries;
using MicroServiceTask.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Controller
{
    /// <summary>
    /// 
    /// </summary>
   // [Authorize]
    [ApiController]
    [Route("projectmgmt/api/v1/")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices .GetService<IMediator>();
        public TaskController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("manager/assigntask")]
        public async Task<IActionResult> Create([FromBody] AssignTaskCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("member/list")]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> GetAll([FromQuery] string memberId, [FromBody] AssignTaskCommand command)
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            try
            {
                string Deliverables = command.Deliverables;
                string TaskName = command.TaskName;
                string TaskstartDate = command.TaskstartDate;
                string TaskendDate = command.TaskendDate;
                var result = await _mediator.Send(new GetAssignTaskQuery { memberId = Convert.ToInt64(memberId), TaskName = TaskName, Deliverables = Deliverables, TaskstartDate = TaskstartDate, TaskendDate = TaskendDate });
                serviceResponse.Data = _mapper.Map<List<GetTaskDto>>(result);
                serviceResponse.Success = true;

            }

            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }

            return serviceResponse;
            // return Ok(await _mediator.Send(new GetAssignTaskQuery { memberId = Convert.ToInt64(memberId), TaskName= TaskName, Deliverables= Deliverables, TaskstartDate= TaskstartDate, TaskendDate = TaskendDate }));
        }
       
    }
}
