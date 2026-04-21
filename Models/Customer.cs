using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class Customer
    {
        public int CustomerID { get; set;}   
        public string? NameCustomer { get; set;}
        public string? Address { get; set;}
        public int Number { get; set;}
        public ICollection<Order> Orders { get; set;}= new List<Order>();

    }
}

