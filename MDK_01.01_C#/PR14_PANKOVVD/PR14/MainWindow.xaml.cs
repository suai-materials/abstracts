using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using CarEngine;

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
            NavigationManager.Frame = Frame;
            NavigationManager.MainWindow = this;
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (_, _) =>
                StatusDate.Content =
                    DateTime.Now.ToString("dddd, dd MMMM yyyy г.", CultureInfo.GetCultureInfo("ru-ru"));
            timer.Tick += (_, _) =>
                StatusTime.Content = DateTime.Now.ToString("hh:mm", CultureInfo.GetCultureInfo("ru-ru"));
            timer.IsEnabled = true;
            timer.Start();
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

                    switch (btn.Name)
                    {
                        case "AddCar":
                            Frame.Navigate(new AddEngine());
                            break;
                        case "Certificates":
                            if (EngineData.EngineList.Count > 0)
                            {
                                Frame.Navigate(new Certificates());
                            }
                            else
                            {
                                MessageBox.Show("Надо добавить информацию в Add cars. Для того чтобы продолжить");
                                AddCar.IsChecked = true;
                            }

                            break;
                        case "EditCars":
                            Frame.Navigate(new EngineListViewer());
                            break;
                        default:
                            MessageBox.Show("Это появится в будущем.");
                            AddCar.IsChecked = true;
                            break;
                    }

                    // Frame.Source = new Uri(btn.Name + ".xaml", UriKind.Relative);


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


        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Import_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}