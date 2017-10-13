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
    /// Interaction logic for AddInventory.xaml
    /// </summary>
    public partial class AddInventory : Window
    {
        public AddInventory()
        {
            InitializeComponent();
            SetID();
        }

        private void SetID()
        {
            try
            {
                int id = BloodInventoryValidation.GetNextIdBL();
                txt_id.Text = id.ToString();
            }
            catch (BloodBankException ex)
            {
                MessageBox.Show("Cannot Set Inventory ID. Reason: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot Set Inventory ID. Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Set Inventory ID. Reason: " + ex.Message);
            }
        }
        
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                int noOfBottles;
                int bloodBankID;

                string bloodGroup = cmb_blood_group.Text;
                DateTime expiaryDate = DateTime.Parse(dtpicker_expiary.Text);
                Int32.TryParse(txt_id.Text, out id);
                Int32.TryParse(txt_bottles.Text, out noOfBottles);
                Int32.TryParse(txt_bloodbank_id.Text, out bloodBankID);

                BloodInventory inventory = new BloodInventory()
                {
                    BloodInventoryID = id,
                    NumberofBottles = noOfBottles,
                    BlooadBankID = bloodBankID,
                    BloodGroup = bloodGroup,
                    ExpiryDate = expiaryDate
                };

                if (BloodInventoryValidation.AddInventoryBL(inventory))
                {
                    MessageBox.Show("Inventory Record Was Successfully Added");
                }
                else
                {
                    MessageBox.Show("Failed to Add Inventory Record");
                }
                
            }
            catch(BloodBankException ex) {
                MessageBox.Show("Cannot Add Inventory Record. Reason: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot Add Inventory Record. Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Add Inventory Record. Reason: " + ex.Message);
            }
        }
    }
}
