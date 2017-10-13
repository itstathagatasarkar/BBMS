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

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for UpdateInventory.xaml
    /// </summary>
    public partial class UpdateInventory : Window
    {
        public UpdateInventory()
        {
            InitializeComponent();
        }

        private void btn_fetch_Click(object sender, RoutedEventArgs e)
        {
            int id;
            BloodInventory inventory = null;

            Int32.TryParse(txt_id.Text, out id);
            try
            {
                inventory = BloodInventoryValidation.SearchBloodInventoryBL(id);
                if (inventory != null)
                {

                    cmb_blood_group.Text = inventory.BloodGroup;
                    txt_bottles.Text = inventory.NumberofBottles.ToString();                    
                    dtpicker_expiary.SelectedDate = inventory.ExpiryDate;
                    txt_bloodbank_id.Text = inventory.BlooadBankID.ToString();

                    txt_bloodbank_id.IsEnabled = true;
                    txt_bottles.IsEnabled = true;
                    dtpicker_expiary.IsEnabled = true;
                    cmb_blood_group.IsEnabled = true;

                    btn_fetch.IsEnabled = false;
                    btn_update.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("No Inventory Record Exist With ID: " + id);
                }
            }
            catch(BloodBankException ex) 
            {
                MessageBox.Show("Cannot Fetch Record. Reason: " + ex.Message);            
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot Fetch Record. Reason: " + ex.Message);            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Fetch Record. Reason: " + ex.Message);            
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            BloodInventory inventory = null;
            try
            {
                inventory = new BloodInventory();

                inventory.BloodGroup = cmb_blood_group.Text;
                inventory.NumberofBottles = Convert.ToInt32(txt_bottles.Text);
                inventory.ExpiryDate = DateTime.Parse(dtpicker_expiary.Text);
                inventory.BlooadBankID = Convert.ToInt32(txt_bloodbank_id.Text);
                inventory.BloodInventoryID = Convert.ToInt32(txt_id.Text);

                if (BloodInventoryValidation.UpdateInventoryBL(inventory))
                {
                    MessageBox.Show("Inventory Record Were Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Inventory Record Were Not Updated");
                }
            }
            catch (BloodBankException ex)
            {
                MessageBox.Show("Cannot Update Record. Reason: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot Update Record. Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Update Record. Reason: " + ex.Message);
            }
        }
    }
}
