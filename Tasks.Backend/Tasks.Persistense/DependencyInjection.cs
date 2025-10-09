using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using DotNetEnv;

namespace Tasks.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                string envPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, ".env");
                DotNetEnv.Env.Load(envPath);
                connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_LOCAL");
            }    
            else
                connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_DOCKER");

            services.AddDbContext<TasksDbContext>(options =>
            {
                options.UseNpgsql(connectionString); 
            });

            services.AddScoped<ITasksDbContext>(provider =>
                provider.GetService<TasksDbContext>());

            return services;
        }
    }
}
