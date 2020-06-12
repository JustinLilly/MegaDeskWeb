using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Data
{
    public class MegaDeskWebContext : DbContext
    {
        public MegaDeskWebContext (DbContextOptions<MegaDeskWebContext> options)
            : base(options)
        {
        }

        public DbSet<DeskQuote> DeskQuote { get; set; }
        public DbSet<Desk> Desk { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DesktopMaterial> DesktopMaterial { get; set; }
    }
}
