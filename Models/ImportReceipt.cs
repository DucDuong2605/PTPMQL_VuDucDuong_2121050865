namespace MvcMovie.Models;

public class ImportReceipt
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<ImportDetail> Details { get; set; } = new List<ImportDetail>();
}