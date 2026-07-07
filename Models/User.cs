using System.ComponentModel.DataAnnotations;

namespace MedicalStore.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Optional (e.g., Admin, Staff)

        // ✅ Added Email Property
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
