namespace MvcMovie.Models;
using System.ComponentModel.DataAnnotations;

public class Supplier {
    public int ID { get; set; }

    [Required( ErrorMessage = "Tên nhà cung cấp")]
    [StringLength(100)]
    public string? Name { get; set; }

    public string? Gmail {get; set;}

    public string? Number {get; set;}
    
    public string? Adddress {get; set;}

    public ICollection<ImportReceipt> ImportReceipts { get; set; } = new List<ImportReceipt>();
}