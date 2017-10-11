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
    /// Interaction logic for ModifyCampDetails.xaml
    /// </summary>
    public partial class ModifyCampDetails : Window
    {
        public ModifyCampDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txt_bdc_id.Text);
                BBMS.Entity.BloodDonationCamp camp = new BBMS.Entity.BloodDonationCamp();
                camp = BloodDonationCampValidations.SearchBloodDonationCamp_BL(id);
                if (camp != null)
                {
                    txt_camp_name.Text = camp.CampName;
                    txt_address.Text = camp.Address;
                    txt_city.Text= camp.City ;
                    dp_start_date.Text= camp.CampStartDate.ToShortDateString();
                    dp_end_date.Text = camp.CampEndDate.ToShortDateString();
                    txt_bdc_id.IsEnabled = false;
                }
                else
                {
                    throw new BloodBankException("Blood Donation Camp ID " + id + " does not exists");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                BBMS.Entity.BloodDonationCamp camp = new BBMS.Entity.BloodDonationCamp();
                camp.BloodDonationCampID = Convert.ToInt32(txt_bdc_id.Text);
                camp.CampName = txt_camp_name.Text;
                camp.Address = txt_address.Text;
                camp.CampStartDate = Convert.ToDateTime(dp_start_date.Text);
                camp.CampEndDate = Convert.ToDateTime(dp_end_date.Text);
                bool campUpdated = BloodDonationCampValidations.UpdateDonationCamp_BL(camp);
                if (campUpdated == true)
                {
                    MessageBox.Show("Blood Donation Camp Updated");
                    this.Close(); 
                }
                else
                {
                    throw new BloodBankException("Blood Donation Camp Cannot be Updated");
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
