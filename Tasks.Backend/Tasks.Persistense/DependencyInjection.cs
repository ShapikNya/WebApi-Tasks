using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;

namespace Tasks.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<TasksDbContext>(options =>
            {
                options.UseNpgsql(connectionString); // <-- меняем на PostgreSQL
            });

            services.AddScoped<ITasksDbContext>(provider =>
                provider.GetService<TasksDbContext>());

            return services;
        }
    }
}
