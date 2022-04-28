using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Stock_021_EMA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new First());
        }

        private void ButtonBase_2_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Second());
        }
    }
}