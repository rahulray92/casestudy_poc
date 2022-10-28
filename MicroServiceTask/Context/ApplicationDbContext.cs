using MicroServiceTask.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Member>()
        //        .HasMany<Task>(t => t.)
        //        .WithOne(g => g.Member)
        //        .HasForeignKey(s => s.MemberId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //   // base.OnModelCreating(builder);
        //}

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        public DbSet<PMTATask> Tasks { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
