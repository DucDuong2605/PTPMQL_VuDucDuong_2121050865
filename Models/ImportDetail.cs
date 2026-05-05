namespace MvcMovie.Models;

public class ImportDetail
{
    public int Id { get; set; }

    public int ImportReceiptId { get; set; }
    public ImportReceipt ImportReceipt { get; set; } 

    public int DeviceId { get; set; }
    public Device? Devices { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal Total => Quantity * Price;
}