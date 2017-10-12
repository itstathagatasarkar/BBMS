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
    public class Hospital
    {
        #region Properties
        public int HospitalID{ get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ContactNo { get; set; }
        #endregion
    }
}
