using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BBMS.DAL;
using BBMS.Entity;
using BBMS.Exceptions;
using System.Data.SqlClient;

namespace BBMS.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class BloodBankValidations
    {
        public static bool ValidateBloodBankBL(string userName, string password)
        {
            bool bloodBankValid = false;

            try
            {
                if (BloodBankOperations.ValidateBloodBankDAL(userName, password))
                {
                    bloodBankValid = true;
                }
            }
            catch(BloodBankException ex)
            {
                throw ex;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return bloodBankValid;
        }
    }
}
