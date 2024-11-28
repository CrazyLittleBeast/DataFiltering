using DataFiltering.Shared.Constants;
using DataFiltering.Titlebar.ViewModels;
using DataFiltering.Titlebar.Views;

namespace DataFiltering.Titlebar
{
    public class TitlebarModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public TitlebarModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var titlebar = containerProvider.Resolve<TitlebarView>();
            var region = _regionManager.Regions[UIRegions.TitleBarRegion];
            region.Add(titlebar);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TitlebarView, TitlebarViewModel>();
        }
    }
}
