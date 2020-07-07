using Micro.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro.Database
{
    public class DBContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DEV\SQLEXPRESS; initial catalog=MicroDB; persist security info=True; user id=Dev; password=Password12$;");
        }
    }
}
