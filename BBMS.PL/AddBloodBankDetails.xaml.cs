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
using System.Data.SqlClient;

using BBMS.BL;
using BBMS.Entity;
using BBMS.Exceptions;
using System.Data.SqlClient;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for AddBloodBankDetails.xaml
    /// </summary>
    public partial class AddBloodBankDetails : Window
    {
        public AddBloodBankDetails()
        {
            InitializeComponent();
            SetBloodBankID();
           
        }

        private void SetBloodBankID()
        {
            try
            {
                int id = BloodBankValidations.GetNextBloodBankIdBL();
                txt_blood_bank_id.Text = id.ToString();
            }
            catch(BloodBankException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message);

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_add_details_Click(object sender, RoutedEventArgs e)
        {
            string bloodBankName = txt_blood_bank_name.Text;
            string address = txt_blood_bank_address.Text;
            string city = txt_blood_bank_city.Text;
            string password = txt_blood_bank_password.Text;
            string userId = txt_blood_bank_user_id.Text;
            string contactNumber = (txt_blood_bank_contact.Text);

            Entity.BloodBank bloodBank = new Entity.BloodBank();

            bloodBank.BloodBankName = bloodBankName;
            bloodBank.Address = address;
            bloodBank.City = city;
            bloodBank.Password = password;
            bloodBank.UserID = userId;
            bloodBank.ContactNumber = contactNumber;

            try
            {
                if (BloodBankValidations.AddBloodBankBL(bloodBank))
                {
                    MessageBox.Show("Blood Bank Added");

                    txt_blood_bank_name.Text = "";
                    txt_blood_bank_address.Text = "";
                    txt_blood_bank_city.Text = "";
                    txt_blood_bank_password.Text = "";
                    txt_blood_bank_id.Text = "";
                    txt_blood_bank_contact.Text = "";
                    txt_blood_bank_user_id.Text = "";

                    SetBloodBankID();
                }
                else
                {
                    MessageBox.Show("Blood Bank Not Added");
                }
            }
            catch(BloodBankException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message);
            }
                 
        }
    }
}
