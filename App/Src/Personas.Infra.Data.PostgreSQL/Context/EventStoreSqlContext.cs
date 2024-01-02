using Microsoft.EntityFrameworkCore;
using Personas.Domain.Core.Events;
using Personas.Infra.Data.PostgreSQL.Mappings;

namespace Personas.Infra.Data.PostgreSQL.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        public DbSet<History> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
