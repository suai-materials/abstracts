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
    public partial class AddCar : Page
    {
        private Engine _currentEngine = new();

        public AddCar()
        {
            InitializeComponent();
            DataContext = _currentEngine;
        }

        public AddCar(Engine engine) : this()
        {
            _currentEngine = engine;
            DataContext = engine;
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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
            EngineData.EngineList.Add(_currentEngine);
        }
    }
}