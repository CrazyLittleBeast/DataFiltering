using DataFiltering.Shared.Interface;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataFiltering.ItemManager.Controls
{
    public partial class ItemListView : UserControl
    {
        private string _filterText = string.Empty;

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
            name: nameof(ItemsSource),
            propertyType: typeof(ObservableCollection<IGroceryItem>),
            ownerType: typeof(ItemListView),
            typeMetadata: new FrameworkPropertyMetadata(default(ObservableCollection<IGroceryItem>), OnItemsSourceChanged));

        public ObservableCollection<IGroceryItem> ItemsSource
        {
            get => (ObservableCollection<IGroceryItem>)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }
        public ICollectionView? ItemsCollectionView { get; private set; }
        public string FilterText
        {
            get => _filterText;
            set
            {
                if (SetProperty(ref _filterText, value))
                    ItemsCollectionView?.Refresh();
            }
        }
        private bool FilteredItems(object obj)
        {
            if (obj is not IGroceryItem item)
                return false;

            return string.IsNullOrWhiteSpace(_filterText) || item.ProductName.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase);
        }
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ItemListView)d;
            control.ItemsCollectionView = CollectionViewSource.GetDefaultView(control.ItemsSource);
            control.ItemsCollectionView.Filter = control.FilteredItems;
        }
    }
}
