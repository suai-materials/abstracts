using System;
using System.Text.RegularExpressions;
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
    }
}