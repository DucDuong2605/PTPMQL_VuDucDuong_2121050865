namespace MvcMovie.Models;

public class Device{
    public int id {get; set;}

    public string? name {get; set;}

    public Category? Category {get; set;}

    public int Quantity {get; set;}

    public ICollection<ImportDetail> ImportDetails { get; set; } = new List<ImportDetail>();// thuộc nhập xuất//
    public ICollection<ExportDetail> ExportDetails { get; set; } = new List<ExportDetail>();
}