using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace InventoryApp;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<string> QueuedOrders { get; } = new();
    public ObservableCollection<string> ProcessedOrders { get; } = new();

    private double _totalRevenue;
    public double TotalRevenue
    {
        get => _totalRevenue;
        set
        {
            if (_totalRevenue != value)
            {
                _totalRevenue = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand ProcessNextOrderCommand { get; }

    public MainViewModel()
    {
        // tre ordrer til test
        QueuedOrders.Add("Item 1 - 120");
        QueuedOrders.Add("Item 2 - 90");
        QueuedOrders.Add("Item 3 - 90");

        ProcessNextOrderCommand = new RelayCommand(_ => ProcessNextOrder());
    }

    private void ProcessNextOrder()
    {
        if (QueuedOrders.Count == 0)
            return;

        var order = QueuedOrders.First();
        QueuedOrders.Remove(order);
        ProcessedOrders.Add(order);

        // hent pris efter bindestreg
        var parts = order.Split('-');
        if (parts.Length > 1 && double.TryParse(parts[1].Trim(), out var price))
        {
            TotalRevenue += price;
            OnPropertyChanged(nameof(TotalRevenue));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}