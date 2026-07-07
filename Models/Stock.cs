using System.ComponentModel.DataAnnotations;

namespace MedicalStore.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MedicineName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }

    }
}
