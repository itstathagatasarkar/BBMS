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
    /// Interaction logic for BloodDonationCamp.xaml
    /// </summary>
    public partial class BloodDonationCamp : Window
    {
        public BloodDonationCamp()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrganizeCamp oc = new OrganizeCamp();
            oc.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ModifyCampDetails mcv = new ModifyCampDetails();
            mcv.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewCampDetails vcd = new ViewCampDetails();
            vcd.Show();
        }
    }
}
