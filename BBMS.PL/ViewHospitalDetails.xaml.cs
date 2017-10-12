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
    /// Interaction logic for ViewHospitalDetails.xaml
    /// </summary>
    public partial class ViewHospitalDetails : Window
    {
        public ViewHospitalDetails()
        {
            InitializeComponent();
        
            DisplayHospital();
        }
        private void DisplayHospital()
        {
            List<BBMS.Entity.Hospital> hospitalList = null;
            try
            {
                hospitalList = HospitalValidations.DisplayHospital_BL();


                dt_hospital_list.ItemsSource = hospitalList;



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

