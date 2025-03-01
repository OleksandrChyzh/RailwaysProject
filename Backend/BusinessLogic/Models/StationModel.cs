using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class StationModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;
    }
}
