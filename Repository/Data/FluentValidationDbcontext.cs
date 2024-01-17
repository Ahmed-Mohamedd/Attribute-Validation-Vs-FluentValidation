using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public  class FluentValidationDbcontext:DbContext
    {
        public FluentValidationDbcontext(DbContextOptions<FluentValidationDbcontext> options):base(options)
        {     
        }

        public DbSet<BreakFast> breakFasts { get; set; }
    }
}
