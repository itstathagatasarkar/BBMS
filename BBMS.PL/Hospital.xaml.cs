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

namespace BBMS.PL
{
    /// <summary>
    /// Interaction logic for Hospital.xaml
    /// </summary>
    public partial class Hospital : Window
    {
        public Hospital()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddHospitalDetails ahd = new AddHospitalDetails();
            ahd.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateHospitalDetails uhd = new UpdateHospitalDetails();
            uhd.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteHospitalDetails dhd = new DeleteHospitalDetails();
            dhd.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewHospitalDetails vhd = new ViewHospitalDetails();
            vhd.Show();
        }
    }
}
