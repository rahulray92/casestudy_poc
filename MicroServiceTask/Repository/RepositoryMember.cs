using MicroServiceTask.Context;
using MicroServiceTask.Model;
using MicroServiceTask.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryMember : IRepositoryMember<Member>
    {
        ApplicationDbContext _dbContext;
        public RepositoryMember(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Member> AddNewMember(Member _object)
        {
            var obj = await _dbContext.Members.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Member _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Member> GetAll()
        {
            try
            {
                return _dbContext.Members.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Member GetById(int Id)
        {
            return _dbContext.Members.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Member _object)
        {
            _dbContext.Members.Update(_object);
            _dbContext.SaveChanges();
        }
        //public bool UpdateAllocationPercentage(Member _object)
        //{
        //    _dbContext.Members.Update(_object);
        //    var status = _dbContext.SaveChanges();
        //    return status == 1 ? true : false;
        //}


    }
}
