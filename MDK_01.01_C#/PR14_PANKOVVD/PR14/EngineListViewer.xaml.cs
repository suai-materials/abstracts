using System.Windows.Controls;

namespace PR14
{
    public partial class EngineListViewer : Page
    {
        public EngineListViewer()
        {
            InitializeComponent();
            GridEngineList.ItemsSource = EngineData.EngineList;
        }
    }
}