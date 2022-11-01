using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PMT_BAL.Service;
using PMT_DAL.Interface;
using PMT_DAL.Models;
using PMTUC.Model;
using PMTUC.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTUC.Controller
{
    /// <summary>
    /// ManagerController
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("projectmgmts/api/v1/")]   
   
    public class ManagerController : ControllerBase
    {
        private readonly MemberService _memberService;
        private readonly IRepository<Member> _member;
       // private readonly TaskService _taskService;
       // private readonly IRepositoryTask<PMTTask> _task;
        private readonly ILogger<ManagerController> _logger;
        /// <summary>
        /// ManagerController
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberService"></param>
        /// <param name="tasks"></param>
        /// <param name="taskService"></param>
        /// <param name="logger"></param>
        public ManagerController(IRepository<Member> member, MemberService memberService, ILogger<ManagerController> logger)
        {
            _memberService = memberService;
            _member = member;
           // _taskService = taskService;
           // _task = tasks;
            _logger = logger;

        }
        //Get:/projectmgmt/api/v1/manager/list/{memberdetails
        //}

        /// <summary>
        /// list
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("manager/list")]

        public Object List(MemberRequest newMembersRequest)
        {
            try
            {
                var member = new Member
                {
                    MemberId = newMembersRequest.MemberId,
                    TeamMemberName = newMembersRequest.TeamMemberName,
                    ProjectstartDate = newMembersRequest.ProjectstartDate,
                    ProjectendDate = newMembersRequest.ProjectendDate
                };
                _logger.LogInformation("Starting List of memberDetails method...");
                var data = _memberService.GetAllMembers(member);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error memberDetails method..."+ex+"");
                throw ex;
            }
            

            

        }
        /// <summary>
        /// Add new member
        /// </summary>
        /// <returns></returns>
        [HttpPost("manager/add-member")]

        public async Task<IActionResult> Addmember(Member newMembers)
        {
            try
            {
                _logger.LogInformation("Starting Addmember method...");
                return Ok(await _memberService.AddNewMembers(newMembers));
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        ///// <summary>
        ///// Add new member
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("manager/assign-task")]

        //public async Task<IActionResult> AssignTask(PMTTask assigntask)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Starting AddNewTask method...");
        //        return Ok(await _taskService.AddNewTask(assigntask));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
            

        //}
        ///// <summary>
        ///// list
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("member/list/{memberId}/{taskDetails}")]

        //public Object AssignTaskView(int memberId, PMTTask tasks = null)
        //{
        //    try
        //    { 

        //         _logger.LogInformation("Starting AssignTaskView method...");
        //        if (memberId != 0)
        //            tasks.MemberId = memberId;
        //        var data = _taskService.GetAllTask(tasks);
        //        var json = JsonConvert.SerializeObject(data, Formatting.Indented,
        //            new JsonSerializerSettings()
        //            {
        //                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //            }
        //        );
        //        return json;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
            
        //}
        /// <summary>
        /// list
        /// </summary>
        /// <returns></returns>
        [HttpPost("manager/update")]

        public Object UpdateAllocationPercentage(AllocationRequest request)
        {
            try
            {
                _logger.LogInformation("Starting UpdateAllocationPercentage method...");
                var data = new Member();
                data.AllocationPercentage = Convert.ToString(request.allocationPercentage);
                data.MemberId = request.memberId;
                var data1 = _memberService.UpdateAllocationPercentage(data);
                var json = JsonConvert.SerializeObject(data1, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}
