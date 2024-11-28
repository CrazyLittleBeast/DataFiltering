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
            InitialItemList();
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
            var moreBeer = new ObservableCollection<IGroceryItem>()
            {
                new Beverage("Guinness Foreign Extra Stout", 4.99m, 50, 0.33f, true),
                new Beverage("Delirium Tremens", 5.49m, 30, 0.33f, true),
                new Beverage("BrewDog Tokyo", 6.99m, 20, 0.33f, true),
                new Beverage("Samichlaus Bier", 7.99m, 25, 0.33f, true),
                new Beverage("Schneider Aventinus Weizen-Eisbock", 5.99m, 40, 0.5f, true),
                new Beverage("Goose Island Bourbon County Stout", 14.99m, 10, 0.5f, true),
                new Beverage("The Bruery Black Tuesday", 29.99m, 5, 0.75f, true)
            };
            Groceries.AddRange(moreBeer);
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
        private void InitialItemList()
        {
            Groceries = new ObservableCollection<IGroceryItem>
            {
                 new Beverage("Orange Juice", 3.50m, 50, 1.5f, false),
                 new Beverage("Red Horse", 2.00m, 100, 0.5f, true),
                 new Beverage("Wine", 10.00m, 25, 0.75f, true),
            };
        }
    }
}
