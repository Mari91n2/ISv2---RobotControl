using System.Collections.Generic;

namespace InventoryApp.Models
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public Order(Customer customer)
        {
            Customer = customer;
        }

        // ✅ TotalPrice som property i stedet for metode
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var line in OrderLines)
                {
                    total += line.Item.PricePerUnit * line.Quantity;
                }
                return total;
            }
        }
    }
}