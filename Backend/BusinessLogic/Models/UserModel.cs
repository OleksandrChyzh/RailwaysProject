using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class UserModel
    {
        [Key]
        [EmailAddress]
        [Required]
        [StringLength(50)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = null!;

        [Phone]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
    }
}
