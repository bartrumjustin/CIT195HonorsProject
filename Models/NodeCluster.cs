using System.ComponentModel.DataAnnotations;

namespace CIT195HonorsProject.Models
{
    public class NodeCluster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Cluster Location")]
        public string ClusterLocation { get; set; } = string.Empty;

        // Nav prop
        public ICollection<HardDrive>? HardDrives { get; set; }
    }
}
