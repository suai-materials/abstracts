using System.Windows.Controls;

namespace PR14
{
    public static class NavigationManager
    {
        public static MainWindow MainWindow { get; set; }
        public static Frame Frame { get; set; } = new();
    }
}