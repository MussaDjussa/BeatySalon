using System.Linq;
using System.Windows;

namespace BeatySalon.View.Windows
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();
            ListViewProduct.ItemsSource = MainWindow.Products.ProductViewModel.BasketList.ToList();
            this.Closing += Basket_Closing;
        }

        private void Basket_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.Products.BasketButton.Visibility = Visibility.Visible;
        }
    }
}
