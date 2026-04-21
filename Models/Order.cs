namespace MvcMovie.Models;

public class Order
{
    public int OrderID { get; set;}
    public string? NameOrder { get; set;}
    public int Quantity { get; set;}
    public DateTime Orderdate { get; set;}
    public Customer? Customer { get; set;}
    public Product? Product { get; set;} 
}