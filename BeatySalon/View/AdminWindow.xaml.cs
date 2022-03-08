using BeatySalon.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BeatySalon.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            DoubleAnimation textblockAnimtion = new DoubleAnimation();
            textblockAnimtion.From = 1;
            textblockAnimtion.To = 0;
            textblockAnimtion.Duration = TimeSpan.FromSeconds(0.25);
            SelectorText.BeginAnimation(Button.OpacityProperty, textblockAnimtion);
        }
    }
}
