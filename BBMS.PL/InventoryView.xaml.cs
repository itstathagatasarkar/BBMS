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
using BBMS.Exceptions;
using BBMS.BL;
using System.Data.SqlClient;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : Window
    {
        public InventoryView()
        {
            InitializeComponent();
            GetInventory();
        }

        private void GetInventory()
        {
            try
            {
                grid_display.ItemsSource = BloodInventoryValidation.GetBloodInventoryListBL();
                
            }
            catch (BloodBankException ex)
            {
                MessageBox.Show("Cannot Get Inventory. Reason: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot Get Inventory. Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Get Inventory. Reason: " + ex.Message);
            }
        }
    }
}
