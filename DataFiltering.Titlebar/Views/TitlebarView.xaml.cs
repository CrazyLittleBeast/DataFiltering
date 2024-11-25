using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataFiltering.Titlebar.Views
{
    /// <summary>
    /// Interaction logic for TitlebarView.xaml
    /// </summary>
    public partial class TitlebarView : UserControl
    {
        public TitlebarView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Application.Current.MainWindow.DragMove();
            }
        }
    }
}
