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
    class BloodDonorDonation
    {
        #region Properties
        public int BloodDonationID { get; set; }
        public DateTime BloodDonationDate { get; set; }
        public int NumberofBottles { get; set; }
        public int Weight { get; set; }
        public int HBCount { get; set; }
        #endregion
    }
}
