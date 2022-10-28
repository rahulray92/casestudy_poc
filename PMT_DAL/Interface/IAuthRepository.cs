using PMT_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMT_DAL.Interface
{
   public interface IAuthRepository<T>
    {
        public Task<T> Register(T _object);
        public T Login(string username);
        Task<bool> UserExists(string username);
    }
}
