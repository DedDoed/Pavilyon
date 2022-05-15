using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pavilyon.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ProjectsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
