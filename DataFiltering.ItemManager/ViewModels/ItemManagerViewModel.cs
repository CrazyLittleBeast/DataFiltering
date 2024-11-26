using DataFiltering.ItemManager.Models;
using DataFiltering.Shared.Constants;
using DataFiltering.Shared.Interface;
using System.Collections.ObjectModel;

namespace DataFiltering.ItemManager.ViewModels
{
    public class ItemManagerViewModel : BindableBase
    {
        private ObservableCollection<IGroceryItem> _groceries = new();
        private IGroceryItem? _selectedGroceryItem;
        private Beverage? _newBeverageItem = new Beverage();
        private string _validationMessage = string.Empty;

        public ItemManagerViewModel()
        {
            ImitialItemList();
            GetGroceriesCommand = new DelegateCommand(GetGroceries);
            AddNewItemCommand = new DelegateCommand(AddNewItem);
        }

        public DelegateCommand GetGroceriesCommand { get; private set; }
        public DelegateCommand AddNewItemCommand { get; private set; }
        public string ValidationMessage
        {
            get => _validationMessage;
            set => SetProperty(ref _validationMessage, value);
        }

        public IGroceryItem? SelectedGroceryItem
        {
            get => _selectedGroceryItem;
            set => SetProperty(ref _selectedGroceryItem, value);
        }
        public Beverage? NewBeverageItem
        {
            get => _newBeverageItem;
            set => SetProperty(ref _newBeverageItem, value);
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
        private void AddNewItem()
        {
            ValidationMessage = string.Empty;
            if (NewBeverageItem is null || Groceries.Any(i => i.ProductName.Equals(NewBeverageItem.ProductName)))
                return;

            if (!NewBeverageItem.IsValid(out var validationMessage))
            {
                ValidationMessage = validationMessage;
                return;
            }

            Groceries.Add(NewBeverageItem);
            NewBeverageItem = new Beverage();
        }
        private void ImitialItemList()
        {
            Groceries = new ObservableCollection<IGroceryItem>
            {
                 new Beverage("Orange Juice", 3.50m, 50, 1.5f, false),
                 new Beverage("Beer", 2.00m, 100, 0.5f, true),
                 new Beverage("Wine", 10.00m, 25, 0.75f, true),
            };
        }
    }
}
