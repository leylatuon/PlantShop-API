using System;
using System.ComponentModel.DataAnnotations;

namespace PlantShop.Models
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string FulfillmentStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}

