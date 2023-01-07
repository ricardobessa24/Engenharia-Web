using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial8Parte2.Models;

namespace Tutorial8Parte2.Data
{
    public class Class8bContext_Database : DbContext
    {
        public Class8bContext_Database (DbContextOptions<Class8bContext_Database> options)
            : base(options)
        {
        }

        public DbSet<Tutorial8Parte2.Models.User> User { get; set; }
    }
}
