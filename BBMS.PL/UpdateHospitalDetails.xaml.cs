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
using BBMS.Entity;
using BBMS.BL;
using BBMS.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for UpdateHospitalDetails.xaml
    /// </summary>
    public partial class UpdateHospitalDetails : Window
    {
        public UpdateHospitalDetails()
        {
            InitializeComponent();
            txt_HospitalId.Text = HospitalValidations.GetNextHospitalID_BL().ToString();
        }
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hospitalName = Convert.ToString(txt_name.Text);
                BBMS.Entity.Hospital hospital = HospitalValidations.SearchHospital_BL(hospitalName);
                if (hospital != null)
                {
                    txt_address.Text = hospital.Address;
                    txt_city.Text = hospital.City;
                    txt_contact.Text = hospital.ContactNo;
                    txt_search.IsEnabled = false;
                    txt_HospitalId.IsEnabled = false;
                
                }
                else
                {
                    throw new BloodBankException("Hospital Name " + hospitalName+ " does not exists");
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
                BBMS.Entity.Hospital hospital = new BBMS.Entity.Hospital();
                hospital.HospitalID = Convert.ToInt32(txt_HospitalId.Text);
                hospital.HospitalName = txt_name.Text;
                hospital.Address = txt_address.Text;
                hospital.City = txt_city.Text;
                hospital.ContactNo = txt_contact.Text;
                try
                {
                    if (HospitalValidations.UpdateHospital_BL(hospital))
                    {
                        MessageBox.Show("Details Updated Successfully");

                        txt_name.Text = "";
                        txt_city.Text = "";
                        txt_address.Text = "";
                        txt_contact.Text = "";

                        txt_search.IsEnabled = true;
                        txt_HospitalId.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Details Were Not Updated");
                    }
               
                }
                 catch (BloodBankException ex)
                {
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

