
using DataFiltering.ItemManager.Controls;
using DataFiltering.ItemManager.Models;
using DataFiltering.ItemManager.ViewModels;
using DataFiltering.Shared.Constants;
using DataFiltering.Shared.Interface;

namespace DataFiltering.ItemManager
{
    public class ItemManagerModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public ItemManagerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var itemManagerView = containerProvider.Resolve<ItemManagerView>();
            var region = _regionManager.Regions[UIRegions.ContentRegion];
            region.Add(itemManagerView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<ItemManagerView, ItemManagerViewModel>();
            containerRegistry.Register<IGroceryItem, Beverage>();
        }
    }
}
