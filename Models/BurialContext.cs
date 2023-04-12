using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models
{
    public class BurialContext : DbContext
    {
        public BurialContext()
        {
        }

        public BurialContext(DbContextOptions<BurialContext>options) : base(options)
        {
        }

        public DbSet<Burialmain> Burials { get; set; }
    }
}
