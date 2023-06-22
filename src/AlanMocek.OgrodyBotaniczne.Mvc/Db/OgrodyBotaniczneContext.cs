using AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate;
using Microsoft.EntityFrameworkCore;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Db
{
    public class OgrodyBotaniczneContext : DbContext
    {
        public DbSet<BotanicGarden> BotanicGardens { get; set; }

        public OgrodyBotaniczneContext(DbContextOptions<OgrodyBotaniczneContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BotanicGardenConfiguration());
        }
    }
}
