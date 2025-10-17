using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using InventoryApp.Models;

namespace InventoryApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Order> QueuedOrders { get; } = new();
        public ObservableCollection<Order> ProcessedOrders { get; } = new();

        private decimal _totalRevenue;
        public decimal TotalRevenue
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

        private readonly Inventory _inventory = new();
        private readonly OrderBook _orderBook = new();

        public MainViewModel()
        {
            // 🧱 Tilføj testdata
            var customer = new Customer("Ordre 1: Stor model serie");
            var item1 = new UnitItem("Laptop", 5000m);
            var item2 = new UnitItem("Mouse", 250m);

            var order1 = new Order(customer);
            order1.OrderLines.Add(new OrderLine(item1, 1));
            order1.OrderLines.Add(new OrderLine(item2, 2));

            var order2 = new Order(customer);
            order2.OrderLines.Add(new OrderLine(item2, 3));

            _orderBook.QueueOrder(order1);
            _orderBook.QueueOrder(order2);

            foreach (var order in _orderBook.QueuedOrders)
                QueuedOrders.Add(order);

            ProcessNextOrderCommand = new RelayCommand(_ => ProcessNextOrder());
        }

        private void ProcessNextOrder()
        {
            if (_orderBook.QueuedOrders.Count == 0)
                return;

            _orderBook.ProcessNextOrder(_inventory);

            QueuedOrders.Clear();
            foreach (var o in _orderBook.QueuedOrders)
                QueuedOrders.Add(o);

            ProcessedOrders.Clear();
            foreach (var o in _orderBook.ProcessedOrders)
                ProcessedOrders.Add(o);

            TotalRevenue = _orderBook.TotalRevenue;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
