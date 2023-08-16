using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mobileInfo_Assignment03.Models;

namespace mobileInfo_Assignment03.Data
{
    public class mobileInfo_Assignment03Context : DbContext
    {
        public mobileInfo_Assignment03Context (DbContextOptions<mobileInfo_Assignment03Context> options)
            : base(options)
        {
        }

        public DbSet<mobileInfo_Assignment03.Models.mobileInfo> mobileInfo { get; set; } = default!;
    }
}
