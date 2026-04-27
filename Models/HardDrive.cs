using System.ComponentModel.DataAnnotations;

namespace CIT195HonorsProject.Models
{
    public class HardDrive
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [Range(1, 100000)]
        [Display(Name = "Capacity (GB)")]
        public int CapacityGB { get; set; }

        [Display(Name = "Is SSD")]
        public bool IsSolidState { get; set; }

        [Display(Name = "Assigned Node")]
        public int NodeClusterId { get; set; }

        // Nav prop
        public NodeCluster? NodeClusters { get; set; }
    }
}
