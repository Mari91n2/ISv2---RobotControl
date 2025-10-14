namespace InventoryApp.Models
{
    public class OrderLine
    {
        public Item Item { get; set; }
        public decimal Quantity { get; set; }   // Brug decimal til mængder

        public OrderLine(Item item, decimal quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}

