using System.Collections.ObjectModel;
using System.Linq;

namespace InventoryApp.Models
{
    public class OrderBook
    {
        public ObservableCollection<Order> QueuedOrders { get; set; } = new();
        public ObservableCollection<Order> ProcessedOrders { get; set; } = new();

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

            foreach (var line in order.OrderLines)
                inventory.ReduceStock(line.Item, line.Quantity);
        }

        public decimal TotalRevenue => ProcessedOrders.Sum(o => o.TotalPrice);
    }
}