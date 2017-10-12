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
        }

        
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch(BloodBankException ex) {

            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}
