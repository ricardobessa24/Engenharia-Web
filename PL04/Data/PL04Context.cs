using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PL04.Models;

namespace PL04.Data
{
    public class PL04Context : DbContext
    {
        public PL04Context (DbContextOptions<PL04Context> options)
            : base(options)
        {
        }

        public DbSet<PL04.Models.Category> Category { get; set; }
        public DbSet<PL04.Models.Course> Courses { get; set; }
    }
}
