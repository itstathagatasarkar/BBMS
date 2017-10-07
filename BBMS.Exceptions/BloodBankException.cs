using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class BloodBankException: ApplicationException
    {
        public BloodBankException()
            :base()
        {

        }
        public BloodBankException(string message)
            : base(message)
        {

        }
    }
}
