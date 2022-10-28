using PMT_DAL.Interface;
using PMT_DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT_BAL.Service
{
    public class TaskService
    {
        private readonly IRepositoryTask<PMTTask> _task;
        private readonly IRepository<Member> _member;
        public TaskService(IRepositoryTask<PMTTask> task, IRepository<Member> member)
        {
            _task = task;
            _member = member;
        }

        //public async Task<PMTTask> AddNewTask(PMTTask tasks)
        //{
        //    try
        //    {
        //        var memberDetails = _member.GetAll().ToList();
        //        var data = new PMTTask();
        //        if (memberDetails != null)
        //        {
        //            DateTime d1, d2,d3;
        //            d1 = DateTime.Parse(tasks.TaskstartDate, new CultureInfo("en-US", true));
        //            d2 = DateTime.Parse(tasks.TaskendDate, new CultureInfo("en-US", true));
        //            if (d2.Date > d1.Date)
        //                throw new Exception("Task end date should be greater than task start date");
        //            else
        //            {
        //                foreach (var item in memberDetails)
        //                {
        //                    d3 = DateTime.Parse(item.ProjectendDate, new CultureInfo("en-US", true));
        //                    if (d2.Date > d3.Date)
        //                        throw new Exception("Task end date should not  be greater thean project end date");
        //                    else
        //                    {
        //                        tasks.MemberName = item.TeamMemberName;
        //                        tasks.MemberId = item.MemberId;
        //                        data = await _task.AddNewTask(tasks);
        //                    }

        //                }
        //            }

        //        }
        //        return data;
        //        //var val = new Member();

        //        //var validationMsg = Valdation(tasks);
        //        //if (validationMsg != string.Empty)
        //        //    return val;
        //        //else

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        
        //public IEnumerable<TaskModel> GetAllTask(PMTTask tasks)
        //{
        //    try
        //    {
        //        var data = _task.GetAll(tasks).ToList();
               

        //        return data;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        
    }
}
