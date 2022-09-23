using Aircraft.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircraft.Infrastructure.Context
{
    public class AircraftContext : DbContext
    {
        public AircraftContext(DbContextOptions<AircraftContext> context) : base(context)
        {

        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Stage> Stages { get; set; }

    }
}
