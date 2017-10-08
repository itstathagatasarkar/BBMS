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

using BBMS.BL;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for DeleteBloodBankDetails.xaml
    /// </summary>
    public partial class DeleteBloodBankDetails : Window
    {
        public DeleteBloodBankDetails()
        {
            InitializeComponent();
        }

        private void btn_blood_bank_delete_Click(object sender, RoutedEventArgs e)
        {
            int id;

            Int32.TryParse(txt_blood_bank_id.Text, out id);
            try
            {
                if (BloodBankValidations.DeleteBloodBankBL(id))
                {
                    MessageBox.Show("Blood Bank Successfully Successfully Deleted");
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
