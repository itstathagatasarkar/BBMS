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
    /// Interaction logic for BloodBank.xaml
    /// </summary>
    public partial class BloodBank : Window
    {
        public BloodBank()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBloodBankDetails abb = new AddBloodBankDetails();
            abb.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateBloodBankDetails ubb = new UpdateBloodBankDetails();
            ubb.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteBloodBankDetails dbb = new DeleteBloodBankDetails();
            dbb.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewBloodBankDetails vbb = new ViewBloodBankDetails();
            vbb.Show();
        }
    }
}
