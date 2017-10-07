using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BloodDonor bd = new BloodDonor();
            bd.Show();
          
                
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BloodBank bb = new BloodBank();
            bb.Show();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Hospital h1 = new Hospital();
            h1.Show();
           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            InventoryForBlood ib = new InventoryForBlood();
            ib.Show();
          
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            BloodDonationCamp bdcamp = new BloodDonationCamp();
            bdcamp.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
