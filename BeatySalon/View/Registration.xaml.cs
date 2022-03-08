using BeatySalon.Model;
using MaterialDesignThemes.Wpf;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BeatySalon.View
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        DialogHost dialogHost = new DialogHost();
        
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regex.IsMatch(Login.Text, "[^A-z-0-9]"))
            {
                Dialog.IsOpen = true;
                Login.Text = Login.Text.Remove(Login.Text.Length - 1);
                Login.SelectionStart = Login.Text.Length;
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
            Client client = new Client() { Login = Login.Text, Password = Password.Text, RoleID = 2 };

            using (BeatySalonEntities db = new BeatySalonEntities())
            {
                var result = db.Client.ToList().Where(q=>q.Login == Login.Text && q.Password == Password.Text).FirstOrDefault();

                if(result == null)
                {
                    db.Client.Add(client);
                    db.SaveChanges();
                    db.Dispose();
                    DialogSucces.IsOpen = true;
                }
                else
                {
                    DialogClient.IsOpen = true;
                }
            }
        }
        private void CloseButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogClient.IsOpen = false;
        }

        private void CloseButton_Click_2(object sender, RoutedEventArgs e)
        {
            DialogSucces.IsOpen = false;
        }
    }
}
