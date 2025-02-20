using System.ComponentModel.DataAnnotations;
namespace BusinessLogic.Models
{
    public class TicketModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;

        [Required]
        public long WagonNumber { get; set; }

        [Required]
        public long SeatNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainName { get; set; } = null!;  // Назва поїзда

        [Required]
        [StringLength(50)]
        public string StartStationName { get; set; } = null!;  // Початкова станція

        [Required]
        [StringLength(50)]
        public string EndStationName { get; set; } = null!;  // Кінцева станція

    }
}
