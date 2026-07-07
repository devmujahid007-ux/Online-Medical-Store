using System.ComponentModel.DataAnnotations;

namespace MedicalStore.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }
    }
}
