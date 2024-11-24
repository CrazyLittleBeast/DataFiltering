using DataFiltering.SearchBox.ViewModels;
using DataFiltering.SearchBox.Views;
using DataFiltering.Shared.Constants;

namespace DataFiltering.SearchBox
{
    public class SearchBox : IModule
    {
        private IRegionManager _regionManager;
        public SearchBox(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var itemsParentView = containerProvider.Resolve<ItemsView>();
            IRegion contentRegion = _regionManager.Regions[UIRegions.ContentRegion];
            contentRegion.Add(itemsParentView);
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<ItemsView, ItemsViewModel>();
        }
    }
}
