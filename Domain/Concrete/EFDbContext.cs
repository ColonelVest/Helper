using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Period> Periods
        {
            get;
            set;
        }

        public DbSet<Day> Days
        {
            get;
            set;
        }
    }
}
