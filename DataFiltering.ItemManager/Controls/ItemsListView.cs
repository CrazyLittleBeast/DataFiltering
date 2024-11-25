using System.Collections;
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
                propertyType: typeof(IEnumerable),
                ownerType: typeof(ItemListView),
                typeMetadata: new FrameworkPropertyMetadata(default(IEnumerable), OnItemsSourceChanged));
        public static readonly DependencyProperty FilterTargetProperty =
            DependencyProperty.Register(
                name: nameof(FilterTarget),
                propertyType: typeof(string),
                ownerType: typeof(ItemListView),
                typeMetadata: new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty DispalyMemberPathProperty =
            DependencyProperty.Register(
                name: nameof(DisplayMemberPath),
                propertyType: typeof(string),
                ownerType: typeof(ItemListView),
                typeMetadata: new PropertyMetadata(string.Empty));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }
        public ICollectionView? ItemsCollectionView { get; private set; }
        public string FilterTarget
        {
            get => (string)GetValue(FilterTargetProperty);
            set => SetValue(FilterTargetProperty, value);
        }
        public string DisplayMemberPath
        {
            get => (string)GetValue(DispalyMemberPathProperty);
            set => SetValue(DispalyMemberPathProperty, value);
        }
        public string FilterText
        {
            get => _filterText;
            set
            {
                if (SetProperty(ref _filterText, value))
                    ItemsCollectionView?.Refresh();
            }
        }

        private bool FilterLogic(object obj)
        {
            if (obj is null || string.IsNullOrWhiteSpace(FilterTarget))
                return false;

            var property = obj.GetType().GetProperty(FilterTarget);

            if (property is null || property.GetValue(obj) is not string value)
                return false;

            return string.IsNullOrWhiteSpace(FilterText) ||
                    value.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase);
        }
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ItemListView)d;
            control.ItemsCollectionView = CollectionViewSource.GetDefaultView(control.ItemsSource);
            control.ItemsCollectionView.Filter = control.FilterLogic;
        }
    }
}
