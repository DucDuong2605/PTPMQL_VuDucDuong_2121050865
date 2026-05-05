namespace MvcMovie.Models;

public class ExportDetail
{
    public int Id { get; set; }

    public int ExportReceiptId { get; set; }
    public ExportReceipt? ExportReceipts { get; set; }

    public int DeviceId { get; set; }
    public Device? Devices { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal Total => Quantity * Price;
}