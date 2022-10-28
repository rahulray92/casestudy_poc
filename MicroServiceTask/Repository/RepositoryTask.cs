using MicroServiceTask.Context;
using MicroServiceTask.Model;
using MicroServiceTask.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Repository
{
    public class RepositoryTask : IRepositoryTask<PMTATask>
    {
        ApplicationDbContext _dbContext;
        public RepositoryTask(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<PMTATask> AddNewTask(PMTATask _object)
        {
            var obj = await _dbContext.Tasks.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(PMTATask _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<PMTATask> GetAll(PMTATask tasks)
        {
            try
            {
                //var task = (from m in _dbContext.Members
                //            join t in _dbContext.Tasks
                //            on m.MemberId equals t.MemberId
                //            where t.MemberId == tasks.MemberId || t.TaskName == tasks.TaskName || t.Deliverables == tasks.Deliverables || t.TaskendDate == tasks.TaskendDate || t.TaskstartDate == tasks.TaskstartDate
                //            select new TaskModel
                //            {
                //                MemberId = t.MemberId,
                //                MemberName = t.MemberName,
                //                TaskName = t.TaskName,
                //                Deliverables = t.Deliverables,
                //                TaskendDate = t.TaskendDate,
                //                TaskstartDate = t.TaskstartDate,
                //                ProjectstartDate = m.ProjectstartDate,
                //                ProjectendDate = m.ProjectendDate,
                //                AllocationPercentage = m.AllocationPercentage
                //            }).ToList();

                //return task;

                return _dbContext.Tasks.Where(x => x.MemberId == tasks.MemberId
                || x.TaskName == tasks.TaskName || x.Deliverables == tasks.Deliverables || x.TaskendDate == tasks.TaskendDate || x.TaskstartDate == tasks.TaskstartDate
                ).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public PMTATask GetById(int Id)
        {
            return _dbContext.Tasks.Where(x => x.TaskName != null && x.TaskId == Id).FirstOrDefault();
        }

        public void Update(PMTATask _object)
        {
            _dbContext.Tasks.Update(_object);
            _dbContext.SaveChanges();
        }

    }
}
