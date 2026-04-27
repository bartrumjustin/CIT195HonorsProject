using Microsoft.EntityFrameworkCore;

namespace CIT195HonorsProject.Data
{
    public class CIT195HonorsProjectContext : DbContext
    {
        public CIT195HonorsProjectContext(DbContextOptions<CIT195HonorsProjectContext> options)
            : base(options)
        {
        }
        public DbSet<CIT195HonorsProject.Models.NodeCluster> NodeClusters { get; set; } = default!;
        public DbSet<CIT195HonorsProject.Models.HardDrive> HardDrives { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CIT195HonorsProject.Models.NodeCluster>()
                .HasIndex(n => n.NodeLocation)
                .IsUnique();
        }

    }
}
