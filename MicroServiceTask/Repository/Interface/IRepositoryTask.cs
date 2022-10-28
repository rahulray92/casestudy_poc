using MicroServiceTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Repository.Interface
{
    public interface IRepositoryTask<T>
    {
        public Task<T> AddNewTask(T _object);
        public void Update(T _object);

        public IEnumerable<PMTATask> GetAll(PMTATask tasks);

        public T GetById(int Id);

        public void Delete(T _object);
    }
}
