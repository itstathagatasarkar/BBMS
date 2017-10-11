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
using BBMS.Exceptions;
using System.Data.SqlClient;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for AddDonorDetails1.xaml
    /// </summary>
    public partial class AddDonorDetails1 : Window
    {
        public AddDonorDetails1()
        {
            InitializeComponent();
            txt_donor_id.Text = BloodDonorValidations.GetNextDonorID_BL().ToString();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BBMS.Entity.BloodDonor donor = new BBMS.Entity.BloodDonor();
                donor.BloodDonorID = Convert.ToInt32(txt_donor_id.Text);
                donor.FirstName = txt_fname.Text;
                donor.LastName = txt_lname.Text;
                donor.Address = txt_addr.Text;
                donor.City = txt_city.Text;
                donor.MobileNo = txt_mobile.Text;
                donor.BloodGroup = cmb_blood_group.Text;
                bool donorAdded = BloodDonorValidations.AddDonor_BL(donor);
                if (donorAdded)
                {
                    MessageBox.Show("Donor Successfully Added");
                }
                else
                    throw new BloodBankException("Donor Cannot be added");
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
