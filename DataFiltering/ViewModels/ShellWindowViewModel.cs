using DataFiltering.Shared.Constants;

namespace DataFiltering.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        public string ContentRegion
        {
            get => UIRegions.ContentRegion;
        }

        public string Title
        {
            get => "Data Filtering";
        }
    }
}
