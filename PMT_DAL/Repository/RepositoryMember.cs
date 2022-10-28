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
    public class RepositoryMember:IRepository<Member>
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

        public IEnumerable<Member> GetAll(Member _object)
        {
            try
            {
                return _dbContext.Members.Where(x => x.IsDeleted == false ||x.TeamMemberName.ToLower().Trim()
                == (_object.TeamMemberName==string.Empty?null:_object.TeamMemberName.ToLower().Trim()) ||x.MemberId==_object.MemberId ||x.ProjectstartDate==_object.ProjectstartDate ||
                x.ProjectendDate==_object.ProjectendDate).ToList();
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
        public bool UpdateAllocationPercentage(Member _object)
        {
            _dbContext.Members.Update(_object);
           var status= _dbContext.SaveChanges();
            return status==1?true:false;
        }


    }
}
