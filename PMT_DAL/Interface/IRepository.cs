using PMT_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMT_DAL.Interface
{

    public interface IRepository<T>
    {
        public Task<T> AddNewMember(T _object);
       
        public void Update(T _object);

        public IEnumerable<T> GetAll( T _object);

        public T GetById(int Id);

        public void Delete(T _object);
        public bool UpdateAllocationPercentage(Member member);


    }

}
