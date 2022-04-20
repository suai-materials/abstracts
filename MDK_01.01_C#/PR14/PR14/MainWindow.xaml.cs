using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HashSet<ToggleButton> navMenu = new() { };

        public MainWindow()
        {
            InitializeComponent();
            navMenu.Add(AddCar);
            navMenu.Add(EditCars);
            navMenu.Add(Certificates);
        }


        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var it = sender as ToggleButton;

            foreach (var btn in navMenu)
            {
                var im = (btn.Content as DockPanel)!.Children[0] as Image;
                var bi3 = new BitmapImage();
                bi3.BeginInit();
                switch (btn.Name)
                {
                    case "AddCar":
                        bi3.UriSource = new Uri($"pack://application:,,,/res/{(btn == it ? "w" : "")}car.png",
                            UriKind.Absolute);
                        break;
                    case "EditCars":
                        bi3.UriSource = new Uri($"pack://application:,,,/res/{(btn == it ? "w" : "")}settings.png",
                            UriKind.Absolute);
                        break;
                    case "Certificates":
                        bi3.UriSource = new Uri($"pack://application:,,,/res/{(btn == it ? "w" : "")}description.png",
                            UriKind.Absolute);
                        break;
                    default:
                        break;
                }

                bi3.EndInit();
                im.Source = bi3;
                if (btn == it)
                {
                    AppBar.Text = ((btn.Content as DockPanel)!.Children[1] as TextBlock).Text;
                    ((btn.Content as DockPanel)!.Children[1] as TextBlock).Foreground =
                        Application.Current.Resources["SecondaryTextColor"] as SolidColorBrush;
                    try
                    {
                        Frame.Source = new Uri(btn.Name + ".xaml", UriKind.Relative);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Это появится в будующем.");
                    }
                    
                    continue;
                }

                ((btn.Content as DockPanel)!.Children[1] as TextBlock).Foreground =
                    Application.Current.Resources["PrimaryTextColor"] as SolidColorBrush;
                btn.IsChecked = false;
            }
        }

        private void AddCar_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var it = sender as ToggleButton;
            foreach (var btn in navMenu)
            {
                if (btn == it)
                    continue;
                if (btn.IsChecked is true)
                    return;
            }

            it.IsChecked = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavViewColumn.MaxWidth != 56)
            {
                NavViewColumn.MinWidth = 56;
                NavViewColumn.MaxWidth = 56;
                foreach (var btn in navMenu)
                    ((btn.Content as DockPanel).Children[0] as Image).Margin = new Thickness(3, 0, 0, 0);

                return;
            }

            NavViewColumn.MaxWidth = 300;
            NavViewColumn.MinWidth = 175;
            foreach (var btn in navMenu)
                ((btn.Content as DockPanel).Children[0] as Image).Margin = new Thickness(20, 0, 0, 0);
        }
    }
}