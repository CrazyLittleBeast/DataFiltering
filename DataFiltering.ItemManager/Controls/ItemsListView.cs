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
            propertyType: typeof(ObservableCollection<string>),
            ownerType: typeof(ItemListView),
            typeMetadata: new FrameworkPropertyMetadata(default(ObservableCollection<string>), OnItemsSourceChanged));

        public ObservableCollection<string> ItemsSource
        {
            get => (ObservableCollection<string>)GetValue(ItemSourceProperty);
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
            if (string.IsNullOrWhiteSpace(FilterText))
                return true;

            return obj is string str && str.ToLower().Contains(FilterText.ToLower());
        }
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ItemListView)d;
            control.ItemsCollectionView = CollectionViewSource.GetDefaultView(control.ItemsSource);
            control.ItemsCollectionView.Filter = control.FilteredItems;
        }
    }
}
