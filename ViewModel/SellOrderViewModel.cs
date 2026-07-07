namespace MedicalStore.ViewModels
{
    public class SellItemViewModel
    {
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class SellOrderViewModel
    {
        public int ClientId { get; set; }
        public List<SellItemViewModel> Items { get; set; } = new();
    }
}
