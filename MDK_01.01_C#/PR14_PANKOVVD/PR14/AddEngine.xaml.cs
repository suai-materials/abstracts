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
            switch (mode)
            {
                case Mode.Add:
                    break;
                case Mode.Edit:
                    NavigationManager.MainWindow.AppBar.Text = "Edit car";
                    Back.Visibility = Visibility.Visible;
                    ((Add.Content as StackPanel)?.Children[0] as TextBlock)!.Text = "Done";
                    break;
            }
        }

        private static readonly Regex URegexNotFloat = new("[^0-9]+");
        private static readonly Regex URegex = new("[^0-9]+.");

        private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = URegexNotFloat.IsMatch((sender as TextBox)!.Text);
        }

        private void Second_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = URegex.IsMatch((sender as TextBox)!.Text);
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
            }
            else
                NavigationManager.Frame.GoBack();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationManager.Frame.GoBack();
        }
    }
}