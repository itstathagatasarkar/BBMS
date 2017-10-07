using BBMS.BL;
using BBMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for UpdateDonorDetails.xaml
    /// </summary>
    public partial class UpdateDonorDetails : Window
    {
        public UpdateDonorDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int donorId = Convert.ToInt32(txt_donor_id.Text);
                BBMS.Entity.BloodDonor donor = BloodDonorValidations.SearchDonor_BL(donorId);
                if (donor != null)
                {
                    txt_fname.Text = donor.FirstName;
                    txt_lname.Text = donor.LastName;
                    txt_addr.Text = donor.Address;
                    txt_city.Text = donor.City;
                    txt_mobile.Text = donor.MobileNo;
                    txt_blood_group.Text = donor.BloodGroup;
                    grid1.Visibility = Visibility.Visible;
                    txt_donor_id.IsEnabled = false;
                }
                else
                {
                    throw new BloodBankException("Donor ID " + donorId + " does not exists");
                }
            }
            catch (BloodBankException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
