using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class TrainModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainName { get; set; } = null!;

        [Required]
        public long PricePerInterval { get; set; }

        public long? NumberOfWagons { get; set; }

        public long? NumberOfSeats { get; set; }
    }
}
