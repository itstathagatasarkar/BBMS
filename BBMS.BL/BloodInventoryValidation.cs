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

        private static bool ValidateInventory(BloodInventory inventory) {
            bool inventoryValid = true;
            StringBuilder errorMessage = new StringBuilder();

            if (inventory.BlooadBankID <= 0)
            {
                errorMessage.Append("Enter A Valid Blood Bank ID\n");
                inventoryValid = false;
            }
            if (inventory.BloodGroup == String.Empty)
            {
                errorMessage.Append("Blood Group Cannot Be Lefft Empty\n");
                inventoryValid = false;
            }
            if (inventory.ExpiryDate < DateTime.Now)
            {
                errorMessage.Append("Expiry Date Cannot Be Less Than Equal To Today\'s Date\n");
                inventoryValid = false;
            }
            if (inventoryValid == false)
            {
                throw new BloodBankException(errorMessage.ToString());
            }
            return inventoryValid;
        }

        public static bool AddInventoryBL(BloodInventory inventory) {
            bool inventoryAdded = false;

            try
            {
                if(ValidateInventory(inventory))
                    inventoryAdded = BloodInventoryOperations.AddInventoryDAL(inventory);
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

            return inventoryAdded;
        }

        public static int GetNextIdBL()
        {
            int id = -1;

            try
            {
                id = BloodInventoryOperations.GetNextIdDAL();
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

            return id;
        }

        public static BloodInventory SearchBloodInventoryBL(int id)
        {
            BloodInventory inventory = null;

            try
            {
                inventory = BloodInventoryOperations.SearchBloodInventoryDAL(id);
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
           
            return inventory;
        }

        public static bool UpdateInventoryBL(BloodInventory inventory)
        {
            bool inventoryUpdated = false;
            try
            {
                if (ValidateInventory(inventory))
                    inventoryUpdated = BloodInventoryOperations.UpdateInventoryDAL(inventory);
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

            return inventoryUpdated;
        }
    }
}
