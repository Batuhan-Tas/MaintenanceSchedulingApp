using MaintenanceSchedulingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceSchedulingApp.Data
{
    public class MaintenanceSchedulerContext : DbContext
    {

        public DbSet<Assets> Assets { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTask { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseNpgsql("Host=localhost;Port=9000;Database=maintenance;Username=postgres;Password=masal");
        }
    }

    
}
