using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Models
{
    public class OrderBook
    {
        public List<Order> QueuedOrders { get; set; } = new();
        public List<Order> ProcessedOrders { get; set; } = new();

        public void QueueOrder(Order order)
        {
            QueuedOrders.Add(order);
        }

        public void ProcessNextOrder(Inventory inventory)
        {
            if (QueuedOrders.Count == 0)
                return;

            var order = QueuedOrders.First();
            QueuedOrders.RemoveAt(0);
            ProcessedOrders.Add(order);

            // ✅ Brug decimal, ikke double
            foreach (var line in order.OrderLines)
            {
                inventory.ReduceStock(line.Item, line.Quantity);
            }
        }

        // ✅ Brug property i stedet for metode
        public decimal TotalRevenue => ProcessedOrders.Sum(o => o.TotalPrice);
    }
}