using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using Tasks.Persistense.EntityTypeConfigurations;

namespace Tasks.Persistense
{
    public class TasksDbContext :  DbContext, ITasksDbContext
    {
        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<Domain.User> Users { get; set; }

        public TasksDbContext(DbContextOptions<TasksDbContext> options)
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
