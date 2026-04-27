using CIT195HonorsProject.Data; // Ensures the context is found
using Microsoft.EntityFrameworkCore;

namespace CIT195HonorsProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CIT195HonorsProjectContext(
                serviceProvider.GetRequiredService<DbContextOptions<CIT195HonorsProjectContext>>()))
            {
                // Check if the database has already been seeded
                if (context.NodeClusters.Any())
                {
                    return;
                }


                var alphaCluster = new NodeCluster { NodeLocation = "Bay 0" };
                var betaCluster = new NodeCluster { NodeLocation = "Bay 1" };

                context.NodeClusters.AddRange(alphaCluster, betaCluster);
                context.SaveChanges();


                context.HardDrives.AddRange(
                    new HardDrive
                    {
                        Manufacturer = "Seagate",
                        CapacityGB = 16000,
                        IsSolidState = false,
                        NodeClusterId = alphaCluster.Id
                    },
                    new HardDrive
                    {
                        Manufacturer = "Samsung",
                        CapacityGB = 4000,
                        IsSolidState = true,
                        NodeClusterId = betaCluster.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}