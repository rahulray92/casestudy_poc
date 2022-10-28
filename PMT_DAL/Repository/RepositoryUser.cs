using Microsoft.EntityFrameworkCore;
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
    public class RepositoryUser : IAuthRepository<User>
    {
        ApplicationDbContext _dbContext;
        public RepositoryUser(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<User> Register(User _object)
        {
            var obj = await _dbContext.Users.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
       
        public User Login(string username)
        {
          var user=  _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower().Equals(username.ToLower()));
           return user;
        }
        public async Task<bool> UserExists(string username)
        {
            if (await _dbContext.Users.AnyAsync(a => a.UserName.ToLower() == username.ToLower()))
            {
                return true;

            }
            else
                return false;
           
        }

       
    }
}
