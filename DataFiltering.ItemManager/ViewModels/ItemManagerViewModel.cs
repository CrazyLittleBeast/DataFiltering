using DataFiltering.Shared.Constants;
using System.Collections.ObjectModel;

namespace DataFiltering.ItemManager.ViewModels
{
    public class ItemManagerViewModel : BindableBase
    {
        private ObservableCollection<string> _groceries = new ObservableCollection<string>();

        public DelegateCommand GetGroceriesCommand { get; private set; }

        public ItemManagerViewModel()
        {
            Groceries = new ObservableCollection<string>()
            {
               "Coke",
               "Sprite",
               "Rice"
            };
            GetGroceriesCommand = new DelegateCommand(GetGroceries);
        }

        private void GetGroceries()
        {
            var x = new ObservableCollection<string>()
            {
                "Apple",
                "Banana",
                "Beef",
                "Milk",
                "Coffee",
                "Beer"
            };
            Groceries.AddRange(x);

        }

        public ObservableCollection<string> Groceries
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
