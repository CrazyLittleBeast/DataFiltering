
using System.Windows;

namespace DataFiltering.Titlebar.ViewModels
{
    public class TitlebarViewModel : BindableBase
    {
        public TitlebarViewModel()
        {
            ExitApplicationCommand = new DelegateCommand(ExitApplication);
            MinimizeApplicationCommand = new DelegateCommand(MinimizeApplication);
        }

        public DelegateCommand ExitApplicationCommand { get; set; }
        public DelegateCommand MinimizeApplicationCommand { get; set; }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
        private void MinimizeApplication()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

    }
}
