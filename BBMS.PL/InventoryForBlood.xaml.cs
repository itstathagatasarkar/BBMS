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
    /// Interaction logic for InventoryForBlood.xaml
    /// </summary>
    public partial class InventoryForBlood : Window
    {
        public InventoryForBlood()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new InventoryView().Show();
        }

        private void btn_add_to_inventory_Click(object sender, RoutedEventArgs e)
        {
            new AddInventory().Show();
        }

        private void btn_update_inventory_Click(object sender, RoutedEventArgs e)
        {
            new UpdateInventory().Show();
        }
    }
}
