using System.ComponentModel.DataAnnotations;

namespace CIT195HonorsProject.Models
{
    public class NodeCluster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Node Location")]
        public string NodeLocation { get; set; } = string.Empty;

        // Nav prop
        public ICollection<HardDrive>? HardDrives { get; set; } = new List<HardDrive>();
    }
}
