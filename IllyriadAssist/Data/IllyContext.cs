using IllyriadAssist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IllyriadAssist.Data
{
    public class IllyContext : DbContext
    {
        public IllyContext(DbContextOptions<IllyContext> options) : base(options)
        {
        }
        public DbSet<RareMinerals> RareMinerals { get; set; }
        public DbSet<APISettings> Settings { get; set; }
    }
}
