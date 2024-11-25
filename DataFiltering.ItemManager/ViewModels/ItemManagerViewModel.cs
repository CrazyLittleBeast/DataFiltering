using DataFiltering.ItemManager.Models;
using DataFiltering.Shared.Constants;
using DataFiltering.Shared.Interface;
using System.Collections.ObjectModel;

namespace DataFiltering.ItemManager.ViewModels
{
    public class ItemManagerViewModel : BindableBase
    {
        private ObservableCollection<IGroceryItem> _groceries = new ObservableCollection<IGroceryItem>();

        public DelegateCommand GetGroceriesCommand { get; private set; }

        public ItemManagerViewModel()
        {
            Groceries = new ObservableCollection<IGroceryItem>
            {
                 new Beverage("Orange Juice", 3.50m, 50, 1.5f, false),
                 new Beverage("Beer", 2.00m, 100, 0.5f, true),
                 new Beverage("Wine", 10.00m, 25, 0.75f, true),

            };
            GetGroceriesCommand = new DelegateCommand(GetGroceries);
        }

        private void GetGroceries()
        {
            var x = new ObservableCollection<IGroceryItem>()
            {
                 new Beverage("Cola", 1.50m, 200, 0.33f, false),
                 new Beverage("Whiskey", 25.00m, 30, 0.7f, true),
                 new Beverage("Energy Drink", 2.00m, 150, 0.25f, false)
            };
            Groceries.AddRange(x);

        }

        public ObservableCollection<IGroceryItem> Groceries
        {
            get => _groceries;
            set => SetProperty(ref _groceries, value);
        }
        public string ItemManagementRegion
        {
            get => UIRegions.ItemManagementRegion;
        }
        public string Title
        {
            get => "Filtered Data";
        }

    }
}
