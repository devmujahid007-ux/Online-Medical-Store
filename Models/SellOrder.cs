namespace MedicalStore.Models;

public class SellOrder
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public ICollection<SellItem> Items { get; set; } = new List<SellItem>();
}
