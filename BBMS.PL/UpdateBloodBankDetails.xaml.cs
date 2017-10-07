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
    /// Interaction logic for UpdateBloodBankDetails.xaml
    /// </summary>
    public partial class UpdateBloodBankDetails : Window
    {
        public UpdateBloodBankDetails()
        {
            InitializeComponent();
        }

        private void txt_search_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Entity.BloodBank bloodBank = null;

            try
            {
                Int32.TryParse(txt_blood_bank_id.Text, out id);
                bloodBank = BloodBankValidations.SearchBloodBankBL(id);

                if(bloodBank != null)
                {
                    txt_blood_bank_id.IsEnabled = false;
                    txt_search.IsEnabled = false;
                    txt_blood_bank_name.Text = bloodBank.BloodBankName;
                    txt_city.Text = bloodBank.City;
                    txt_address.Text = bloodBank.Address;
                    txt_contact.Text = bloodBank.ContactNumber;
                }
                else
                {
                    MessageBox.Show("Blood Bank ID#" + id + " Doesnot Exist");
                }
            }
            catch(BloodBankException ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                    
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Entity.BloodBank bloodBank = new Entity.BloodBank();
            bloodBank.BloodBankID = Convert.ToInt32(txt_blood_bank_id.Text);
            bloodBank.BloodBankName = txt_blood_bank_name.Text;
            bloodBank.Address = txt_address.Text;
            bloodBank.City = txt_city.Text;
            bloodBank.ContactNumber = txt_contact.Text;

            try
            {
                if (BloodBankValidations.UpdateBloodBankBL(bloodBank))
                {
                    MessageBox.Show("Details Updated Successfully");

                    txt_blood_bank_name.Text = "";
                    txt_city.Text = "";
                    txt_address.Text = "";
                    txt_contact.Text = "";

                    txt_search.IsEnabled = true;
                    txt_blood_bank_id.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Details Were Not Updated");
                }
            }
            catch(BloodBankException ex){
                MessageBox.Show("Exception: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);

            }

        }
    }
}
