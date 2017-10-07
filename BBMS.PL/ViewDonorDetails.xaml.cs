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
using BBMS.BL;
namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for ViewDonorDetails.xaml
    /// </summary>
    public partial class ViewDonorDetails : Window
    {
        public ViewDonorDetails()
        {
            InitializeComponent();
            List<BBMS.Entity.BloodDonor> donorList = new List<BBMS.Entity.BloodDonor>();
            donorList = BloodDonorValidations.DisplayDonor_BL();
            dt_donor_list.ItemsSource = donorList;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }   
    }
}
