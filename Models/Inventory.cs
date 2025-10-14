using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Models
{
    public class Inventory
    {
        private readonly Dictionary<Item, decimal> stock = new();

        // Tilføj en vare og dens mængde til lageret
        public void Add(Item item, decimal amount)
        {
            if (stock.ContainsKey(item))
                stock[item] += amount;
            else
                stock[item] = amount;
        }

        // Reducer lagerbeholdning
        public void ReduceStock(Item item, decimal amount)
        {
            if (stock.ContainsKey(item))
            {
                stock[item] -= amount;
                if (stock[item] < 0)
                    stock[item] = 0;
            }
        }

        // Få mængden af en bestemt vare
        public decimal GetStock(Item item)
        {
            return stock.TryGetValue(item, out var amount) ? amount : 0m;
        }

        // Hent alle varer med lav beholdning (< 5 fx)
        public IEnumerable<Item> LowStockItems()
        {
            return stock.Where(s => s.Value < 5).Select(s => s.Key);
        }
    }
}