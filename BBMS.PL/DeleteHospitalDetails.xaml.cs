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
using BBMS.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for DeleteHospitalDetails.xaml
    /// </summary>
    public partial class DeleteHospitalDetails : Window
    {
        public DeleteHospitalDetails()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Convert.ToString(txt_name.Text);
            bool hospitalDeleted = HospitalValidations.DeleteHospital_BL(name);
            if (hospitalDeleted)
                MessageBox.Show("Hospital Successfully deleted");
            else
                throw new BloodBankException("Hospital not successfully deleted");
        }
    }
}
