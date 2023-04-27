using System;
using System.ComponentModel.DataAnnotations;

namespace PlantShop.Models
{
    public class OrderItem
    {
        [Key] public int ItemId { get; set; }
        public string PlantName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
    }
}