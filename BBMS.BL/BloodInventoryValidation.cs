using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using BBMS.Entity;
using BBMS.Exceptions;
using BBMS.DAL;

namespace BBMS.BL
{
    public class BloodInventoryValidation
    {
        public static List<BloodInventory> GetBloodInventoryListBL()
        {
            List<BloodInventory> inventoryList = null;

            try
            {
                inventoryList = BloodInventoryOperations.GetBloodInventoryListDAL();
            }
            catch (BloodBankException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return inventoryList;
        }
    }
}
