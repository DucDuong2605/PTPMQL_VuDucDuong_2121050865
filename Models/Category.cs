namespace MvcMovie.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Device> Devices { get; set; } = new List<Device>();
}