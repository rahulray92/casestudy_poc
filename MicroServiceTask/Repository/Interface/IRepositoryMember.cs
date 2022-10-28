using MicroServiceTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Repository.Interface
{
    /// <summary>
    /// IRepositoryMember
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryMember<T>
    {
        /// <summary>
        /// AddNewMember
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public Task<T> AddNewMember(T _object);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="_object"></param>
        public void Update(T _object);
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll();
        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetById(int Id);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="_object"></param>
        public void Delete(T _object);
        //public bool UpdateAllocationPercentage(Member member);
    }
}
