using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CarEngine;

namespace PR14
{
    public partial class EngineListViewer : Page
    {
        public EngineListViewer()
        {
            InitializeComponent();
            GridEngineList.ItemsSource = EngineData.EngineList;
            DataContext = EngineData.EngineList;
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            var engine = (sender as Button).DataContext as Engine;
            NavigationManager.Frame.Navigate(new AddEngine(engine, Mode.Edit));
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var enginesForDel = GridEngineList.SelectedItems.Cast<Engine>().ToList();
            if (enginesForDel.Count != 0 && MessageBox.Show($"Вы точно хотите удалить {enginesForDel.Count} заводов",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                EngineData.EngineList.RemoveAll(engine => enginesForDel.Contains(engine));
                GridEngineList.Items.Refresh();
                DataContext = null;
                DataContext = EngineData.EngineList;
            }
        }
    }
}