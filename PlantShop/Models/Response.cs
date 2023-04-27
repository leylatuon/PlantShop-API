using System;
namespace PlantShop.Models
{
	public class Response
	{
		public int StatusCode { get; set; }
		public string StatusDescription { get; set; }
		public List<Order?> Orders { get; set; }
        public List<OrderItem?> OrderItems { get; set; }

    }
}

