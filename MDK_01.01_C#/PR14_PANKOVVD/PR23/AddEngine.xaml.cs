#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CarEngine;

namespace PR14
{
    /* Да, я ужасный человек и не помещу это в отдельный файл,
     как можно терпеть меня
     */
    public enum Mode
    {
        Add,
        Edit
    }

    public partial class AddEngine : Page
    {
        private Engine _currentEngine = new();
        private Mode _mode;

        public AddEngine()
        {
            InitializeComponent();
            DataContext = _currentEngine;
        }

        public AddEngine(Engine engine, Mode mode = Mode.Add) : this()
        {
            _currentEngine = engine;
            DataContext = engine;
            _mode = mode;
            switch (mode)
            {
                case Mode.Add:
                    break;
                case Mode.Edit:
                    NavigationManager.MainWindow.AppBar.Text = "Edit car";
                    Back.Visibility = Visibility.Visible;
                    AutoType.SelectedItem = _currentEngine.TypeOfProducedCars;
                    MarkType.SelectedItem = MarkType.Items.Cast<StackPanel>().ToList().Find(panel =>
                        (panel.Children[1] as TextBlock)!.Text == _currentEngine.Mark)!;
                    ((Add.Content as StackPanel)?.Children[0] as TextBlock)!.Text = "Done";
                    var bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("pack://application:,,,/res/done.png",
                        UriKind.Absolute);
                    bi3.EndInit();
                    var t = new List<RadioButton> {rb3, rb5, rb10, rb15};
                    t.Find(b => b.Content.ToString() == _currentEngine.Markup)!.IsChecked = true;
                    break;
            }
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            var t = new List<RadioButton>() {rb3, rb5, rb10, rb15};
            t = t.Where(b => b.IsChecked is true).ToList();

            if (FactoryName.Text.Trim() == "" || AutoType.Text.Trim() == "" ||
                ((MarkType.SelectedItem as StackPanel)!.Children[1] as TextBlock)!.Text.Trim() == "" ||
                Quantity.Text.Trim() == "" ||
                Price.Text.Trim() == "" || Date.Text.Trim() == "" || t.Count == 0)
            {
                MessageBox.Show("Вы что-то не ввели");
                return;
            }

            _currentEngine.Markup = t[0].Content.ToString();
            _currentEngine.Mark = ((MarkType.SelectedItem as StackPanel).Children[1] as TextBlock).Text;
            if (_mode == Mode.Add)
            {
                EngineData.EngineList.AddEngine(_currentEngine);
                _currentEngine = new Engine();
                DataContext = _currentEngine;
                MarkType.SelectedItem = null;
                new List<RadioButton> {rb3, rb5, rb10, rb15}.Select(button => button.IsChecked = false).ToArray();
            }
            else
            {
                NavigationManager.Frame.GoBack();
            }
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationManager.Frame.GoBack();
        }
    }
}