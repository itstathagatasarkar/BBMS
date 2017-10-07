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

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = txt_username.Text.Trim();
            string password = txt_password.Password.Trim();
            if (BloodBankValidations.ValidateBloodBankBL(userName, password))
            {
                this.Close();
                HomePage hpp = new HomePage();
                hpp.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }
    }
}
