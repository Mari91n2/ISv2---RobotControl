namespace InventoryApp.Models;

public abstract class Item
{
    public string Name { get; init; }
    public decimal PricePerUnit { get; init; }
    public string Unit { get; init; }

    protected Item(string name, decimal pricePerUnit, string unit)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Unit = unit;
    }
}

public sealed class BulkItem : Item
{
    public BulkItem(string name, decimal pricePerUnit, string unit)
        : base(name, pricePerUnit, unit) { }
}

public sealed class UnitItem : Item
{
    public UnitItem(string name, decimal pricePerUnit)
        : base(name, pricePerUnit, "pcs") { }
}