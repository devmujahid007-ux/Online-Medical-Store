using MedicalStore.Models;

public class SellItem
{
    public int Id { get; set; }
    public int SellOrderId { get; set; }
    public SellOrder SellOrder { get; set; }

    public string MedicineName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
