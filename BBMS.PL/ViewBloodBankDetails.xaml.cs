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
using BBMS.Entity;
using BBMS.Exceptions;
using System.Data.SqlClient;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for ViewBloodBankDetails.xaml
    /// </summary>
    public partial class ViewBloodBankDetails : Window
    {
        public ViewBloodBankDetails()
        {
            InitializeComponent();
            DisplayBloodBank();
        }

        private void DisplayBloodBank() {
            List<Entity.BloodBank> bloodBankList = null;
            try
            {
                bloodBankList = BloodBankValidations.GetBloodBankListBL();
                
                foreach (Entity.BloodBank item in bloodBankList)
                {
                    gridview_display.Items.Add(item);
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
