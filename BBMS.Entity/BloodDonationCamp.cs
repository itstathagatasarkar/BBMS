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
    class BloodDonationCamp
    {
        #region Properties
        public int BloodDonationCampID { get; set; }
        public string CampName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime CampStartDate { get; set; }
        public DateTime CampEndDate { get; set; }
        #endregion
    }
}
