using BeatySalon.Model;
using BeatySalon.ViewModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BeatySalon.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public ProductViewModel ProductViewModel { get; set; } = new ProductViewModel();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(LoginBox.Text, "[^A-z-0-9]"))
            {
                Dialog.IsOpen = true;
                LoginBox.Text = LoginBox.Text.Remove(LoginBox.Text.Length - 1);
                LoginBox.SelectionStart = LoginBox.Text.Length;
            }
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(Password.Text, "[^A-z-0-9]"))
            {
                Dialog.IsOpen = true;
                Password.Text = Password.Text.Remove(Password.Text.Length - 1);
                Password.SelectionStart = Password.Text.Length;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.IsOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (BeatySalonEntities db = new BeatySalonEntities())
            {
                var result = db.Client.ToList().Where(q=>q.Login == LoginBox.Text && q.Password == Password.Text).FirstOrDefault();

                if(result != null)
                {
                    switch(result.RoleID)
                    {
                        case 1:
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            break;
                            case 2:
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            break;
                    }
                }
                else
                {
                    DialogFail.IsOpen = true;
                }
            }
        }

        private void CloseButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogFail.IsOpen = false;
        }
    }
}
