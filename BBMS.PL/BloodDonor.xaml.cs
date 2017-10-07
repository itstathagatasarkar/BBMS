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
    /// Interaction logic for BloodDonor.xaml
    /// </summary>
    public partial class BloodDonor : Window
    {
        public BloodDonor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDonorDetails add = new AddDonorDetails();
            add.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateDonorDetails udd = new UpdateDonorDetails();
            udd.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteDonorDetails dd = new DeleteDonorDetails();
            dd.Show();
            

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewDonorDetails vd = new ViewDonorDetails();
            vd.Show();
            
        }
    }
}
