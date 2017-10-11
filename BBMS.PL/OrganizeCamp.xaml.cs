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
    /// Interaction logic for OrganizeCamp.xaml
    /// </summary>
    public partial class OrganizeCamp : Window
    {
        public OrganizeCamp()
        {
            InitializeComponent();
            txt_bdc_id.Text = BloodDonationCampValidations.GetNextBloodDonationCampID_BL().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BBMS.Entity.BloodDonationCamp camp = new BBMS.Entity.BloodDonationCamp();
                camp.BloodDonationCampID = Convert.ToInt32(txt_bdc_id.Text);
                camp.CampName = txt_bdc_name.Text;
                camp.Address = txt_address.Text;
                camp.City = txt_city.Text;
                camp.CampStartDate =Convert.ToDateTime(dp_start_date.Text);
                camp.CampEndDate = Convert.ToDateTime(dp_end_date.Text);
                bool campAdded = BloodDonationCampValidations.AddBloodDonationCamp_BL(camp);
                if (campAdded)
                {
                    MessageBox.Show("Blood Donor Camp Added");
                    this.Close();
                }
                else
                {
                    throw new BloodBankException("Blood Donation Camp Cannot be added");
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
