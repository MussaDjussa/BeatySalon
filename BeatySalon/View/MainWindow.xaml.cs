using BeatySalon.View;
using System.Windows;
namespace BeatySalon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Products Products { get; set; } = new Products();
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = Products;
        }
    }
}
