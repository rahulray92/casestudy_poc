using MicroServiceTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MicroServiceTask.Context
{
    public interface IApplicationDbContext
    {
        DbSet<PMTATask> Tasks { get; set; }
        DbSet<Member> Members { get; set; }

        Task<int> SaveChanges();
    }
}