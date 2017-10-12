using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BloodInventory
    {
        #region Properties
        public int BloodInventoryID { get; set; }
        public string BloodGroup{ get; set; }
        public int NumberofBottles { get; set; }
        public int BlooadBankID { get; set; }
        public DateTime ExpiryDate { get; set; }
        #endregion
    }
}
