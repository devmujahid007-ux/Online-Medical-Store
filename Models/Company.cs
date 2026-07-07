using System.ComponentModel.DataAnnotations;

namespace MedicalStore.Models
{
    public class Company
    {
        [Key] // ✅ Explicitly mark this as the primary key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }
    }
}
