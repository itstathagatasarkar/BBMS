using BBMS.BL;
using BBMS.Exceptions;
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
    /// Interaction logic for DeleteDonorDetails.xaml
    /// </summary>
    public partial class DeleteDonorDetails : Window
    {
        public DeleteDonorDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id=Convert.ToInt32( txt_donor_id.Text);
            bool donorDeleted = BloodDonorValidations.DeleteDonor_BL(id);
            if (donorDeleted)
                MessageBox.Show("Donor Successfully deleted");
            else
                throw new BloodBankException("Donor not successfully deleted");
        }
    }
}
