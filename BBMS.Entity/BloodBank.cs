using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS.Entity
{
    /// <summary>
    /// Name: Tathagata Sarkar
    /// Description: This class is for BloodBank Entity
    /// Date of Creation: 
    /// Change Date: 04/09/2017 
    /// </summary>
    public class BloodBank
    {
        #region Properties
        public int BloodBankID { get; set; }
        public string BloodBankName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
