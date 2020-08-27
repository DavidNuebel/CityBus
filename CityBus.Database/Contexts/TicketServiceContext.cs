using CityBus.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityBus.Database.Contexts
{
    public class TicketServiceContext : DbContext
    {
        public TicketServiceContext(DbContextOptions options) : base(options) {}

        public DbSet<TicketCondition> TicketConditions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
