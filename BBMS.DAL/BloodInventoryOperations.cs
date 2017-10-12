using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using BBMS.Entity;
using BBMS.Exceptions;

namespace BBMS.DAL
{
    public class BloodInventoryOperations
    {
        #region Variables
        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        #endregion

        #region Constructor
        static BloodInventoryOperations()
        {
            connectionString = GetConnectionString();
            
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
        }
        #endregion

        #region Methods
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BloodBankManagementConnectionString"].ConnectionString;
        }

        public static List<BloodInventory> GetBloodInventoryListDAL()
        {
            List<BloodInventory> inventoryList = null;
            try
            {
                command.CommandText = "[bbms].[usp_DisplayBloodInventory]";
                command.Parameters.Clear();

                connection.Open();
                SqlDataReader reader;

                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    inventoryList = new List<BloodInventory>();
                    while (reader.Read())
                    {
                        BloodInventory inventory = new BloodInventory();
                        inventory.BloodInventoryID = Convert.ToInt32(reader[0].ToString());
                        inventory.BlooadBankID = Convert.ToInt32(reader[1].ToString());
                        inventory.BloodGroup = reader[2].ToString();
                        inventory.NumberofBottles = Convert.ToInt32(reader[3].ToString());
                        inventory.ExpiryDate = DateTime.Parse(reader[4].ToString());
                        

                        inventoryList.Add(inventory);

                    }
                }
                else
                {
                    throw new BloodBankException("No Inventory Record Found in the Data Base");
                }
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return inventoryList;
        }
        #endregion
    }
}
