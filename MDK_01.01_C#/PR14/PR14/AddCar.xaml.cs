using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PR14
{
    public partial class AddCar : Page
    {
        public AddCar()
        {
            InitializeComponent();
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

            if (FactoryName.Text == "" || AutoType.Text == "" ||
                ((MarkType.SelectedItem as StackPanel)!.Children[1] as TextBlock)!.Text == "" || Quantity.Text == "" ||
                Price.Text == "" || Date.Text == "" || t.Count == 0)
            {
                MessageBox.Show("Вы что-то не ввели");
                return;
            }

            var save = "";
            if (File.Exists("1.txt"))
                using (var file_r = new StreamReader("1.txt"))
                {
                    save = file_r.ReadToEnd();
                }
            else
                File.Create("1.txt");

            using (var file = new StreamWriter("1.txt"))
            {
                file.Write(save);
                file.WriteLine(
                    $"{FactoryName.Text}~{AutoType.Text}~{((MarkType.SelectedItem as StackPanel)!.Children[1] as TextBlock)!.Text}~{Quantity.Text}~{Price.Text}~{Date.Text}~{t[0].Content}");
            }
        }
    }
}