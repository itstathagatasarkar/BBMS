﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BloodDonor
    {
        #region Properties
        public int BloodDonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City {get; set;}
        public string MobileNo { get; set; }
        public string BloodGroup { get; set; }
        #endregion

    }
}