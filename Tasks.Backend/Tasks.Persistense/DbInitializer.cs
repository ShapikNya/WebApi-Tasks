using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Persistense
{
    public class DbInitializer
    {
        public static void Initialize(TasksDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
