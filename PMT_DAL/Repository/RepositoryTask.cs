using PMT_DAL.Data;
using PMT_DAL.Interface;
using PMT_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT_DAL.Repository
{
   public  class RepositoryTask : IRepositoryTask<PMTTask>
    {
        ApplicationDbContext _dbContext;
        public RepositoryTask(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        //public async Task<PMTTask> AddNewTask(PMTTask _object)
        //{
        //    var obj = await _dbContext.Tasks.AddAsync(_object);
        //    _dbContext.SaveChanges();
        //    return obj.Entity;
        //}

        //public void Delete(PMTTask _object)
        //{
        //    _dbContext.Remove(_object);
        //    _dbContext.SaveChanges();
        //}

        //public IEnumerable<TaskModel> GetAll(PMTTask tasks)
        //{
        //    try
        //    {
        //        var task = (from m in _dbContext.Members
        //                      join t in _dbContext.Tasks
        //                      on m.MemberId equals t.MemberId
        //                      where t.MemberId == tasks.MemberId || t.TaskName == tasks.TaskName || t.Deliverables == tasks.Deliverables || t.TaskendDate == tasks.TaskendDate || t.TaskstartDate == tasks.TaskstartDate
        //                      select new TaskModel
        //                      {
        //                          MemberId = t.MemberId,
        //                          MemberName=t.MemberName,
        //                          TaskName = t.TaskName,
        //                          Deliverables = t.Deliverables,
        //                          TaskendDate = t.TaskendDate,
        //                          TaskstartDate = t.TaskstartDate,
        //                          ProjectstartDate=m.ProjectstartDate,
        //                          ProjectendDate = m.ProjectendDate,
        //                          AllocationPercentage=m.AllocationPercentage
        //                      }).ToList();

        //        return task;

        //        //return _dbContext.Tasks.Where(x => x.MemberId == tasks.MemberId
        //        //||x.TaskName==tasks.TaskName ||x.Deliverables==tasks.Deliverables ||x.TaskendDate==tasks.TaskendDate ||x.TaskstartDate==tasks.TaskstartDate
        //        //).ToList();
        //    }
        //    catch (Exception ee)
        //    {
        //        throw;
        //    }
        //}

        //public PMTTask GetById(int Id)
        //{
        //    return _dbContext.Tasks.Where(x => x.TaskName !=null && x.Id == Id).FirstOrDefault();
        //}

        //public void Update(PMTTask _object)
        //{
        //    _dbContext.Tasks.Update(_object);
        //    _dbContext.SaveChanges();
        //}

        
    }
}
