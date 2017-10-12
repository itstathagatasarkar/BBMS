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

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for AddHospitalDetails.xaml
    /// </summary>
    public partial class AddHospitalDetails : Window
    {
        public AddHospitalDetails()
        {
            InitializeComponent();
            txt_HospitalId.Text = HospitalValidations.GetNextHospitalID_BL().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                BBMS.Entity.Hospital hptl = new Entity.Hospital();
                hptl.HospitalName = txt_Name.Text;
                hptl.Address = txt_Address.Text;
                hptl.City = txt_City.Text;
                hptl.ContactNo = txt_Contact.Text;



                bool HospitalDetailsAdded = HospitalValidations.AddHospitalDetails(hptl);
                if (!HospitalDetailsAdded)
                {
                    throw new BloodBankException("Details Cannot be Added");
                }
                    
                else
                {
                    MessageBox.Show("Details Added Successfully");
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
