using BeatySalon.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using BeatySalon.Model;
using System.ComponentModel;
using BeatySalon.View.Windows;

namespace BeatySalon.View
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {

        public ProductViewModel ProductViewModel { get; set; } = new ProductViewModel();
        public Products()
        {
            InitializeComponent();
            DataContext = ProductViewModel;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(SearchBox.Text, "[^А-я-0-9]"))
            {
                SearchBox.Text = SearchBox.Text.Remove(SearchBox.Text.Length - 1);
                SearchBox.SelectionStart = SearchBox.Text.Length;
                MessageBox.Show("Возможен только ввод букв и цифр!!!", "Ошибка");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderByComboBox.SelectedIndex == 0)
            {
                ListViewProduct.Items.SortDescriptions.Clear();
            }
            if (OrderByComboBox.SelectedIndex == 1)
            {
                ListViewProduct.Items.SortDescriptions.Clear();
                ListViewProduct.Items.SortDescriptions.Add(new SortDescription("Cost", ListSortDirection.Ascending));
            }
            if (OrderByComboBox.SelectedIndex == 2)
            {
                ListViewProduct.Items.SortDescriptions.Clear();
                ListViewProduct.Items.SortDescriptions.Add(new SortDescription("Cost", ListSortDirection.Descending));
            }
        }

        private void ManufacturerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManufacturerComboBox.SelectedIndex == 0)
            {
                ListViewProduct.Items.SortDescriptions.Clear();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Product selectedProduct = (sender as Button).DataContext as Product;

            if (selectedProduct != null)
            {
                MainWindow.Products.ProductViewModel.BasketList.Add(selectedProduct);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BasketButton.Visibility = Visibility.Collapsed;
            Basket basket = new Basket();
            basket.Show();
        }
    }
}
