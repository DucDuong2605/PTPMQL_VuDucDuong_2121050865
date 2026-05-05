namespace MvcMovie.Models;

public class ExportReceipt
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public ICollection<ExportDetail> Details { get; set; } = new List<ExportDetail>();
}