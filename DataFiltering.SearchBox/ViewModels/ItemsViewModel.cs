using DataFiltering.Data.Models;
using DataFiltering.Shared.Interface;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace DataFiltering.SearchBox.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        private ObservableCollection<IGroceryItem> _groceryItems = [];
        private string _filterText = string.Empty;

        public ItemsViewModel()
        {
            GroceryItems = new ObservableCollection<IGroceryItem>
            {
                 new Beverage("Orange Juice", 3.50m, 50, 1.5f, false),
                 new Beverage("Beer", 2.00m, 100, 0.5f, true),
                 new Beverage("Wine", 10.00m, 25, 0.75f, true),
                 new Beverage("Cola", 1.50m, 200, 0.33f, false),
                 new Beverage("Whiskey", 25.00m, 30, 0.7f, true),
                 new Beverage("Energy Drink", 2.00m, 150, 0.25f, false)
            };
            GroceryItemsView = CollectionViewSource.GetDefaultView(GroceryItems);
            GroceryItemsView.Filter = FilterGroceryItems;
        }

        public ObservableCollection<IGroceryItem> GroceryItems
        {
            get => _groceryItems;
            set => SetProperty(ref _groceryItems, value);
        }
        public ICollectionView GroceryItemsView { get; }
        public string FilterText
        {
            get => _filterText;
            set
            {
                SetProperty(ref _filterText, value);
                GroceryItemsView.Refresh();
            }
        }

        private bool FilterGroceryItems(object obj)
        {
            if (obj is not IGroceryItem item)
                return false;

            return string.IsNullOrWhiteSpace(FilterText) ||
                    item.ProductName.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
