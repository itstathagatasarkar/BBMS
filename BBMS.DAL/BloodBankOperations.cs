using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using BBMS.Exceptions;
using BBMS.Entity;

namespace BBMS.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class BloodBankOperations
    {
        #region Variables
        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        #endregion

        #region Constructor
        static BloodBankOperations()
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

        public static int GetNextBloodBankIdDAL()
        {
            int id = -1;
            try
            {
                command.CommandText = "[bbms].[usp_CurrentBloodBankID]";
                command.Parameters.Clear();

                connection.Open();
                Int32.TryParse(command.ExecuteScalar().ToString(), out id);
                ++id;
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return id;
        }

        public static bool ValidateBloodBankDAL(string userName, string password)
        {
            bool bloodBankValid = false;
            try
            {
                command.CommandText = "bbms.usp_SearchUser";
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@userID", userName);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    bloodBankValid = true;
                }
                else
                {
                    bloodBankValid = false;
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return bloodBankValid;
        }       

        /// <summary>
        /// Returns the current BloodBank ID
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentBloodBankIdDAL()
        {
            int id = -1;
            try
            {
                command.CommandText = "[bbms].[usp_CurrentBloodBankID]";
                command.Parameters.Clear();

                connection.Open();
                Int32.TryParse(command.ExecuteScalar().ToString(), out id);
                ++id;
               
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return id;
        }
        /// <summary>
        /// Adds Blood Bank
        /// </summary>
        /// <param name="bloodBank"></param>
        /// <returns></returns>
        public static bool AddBloodBankDAL(BloodBank bloodBank)
        {
            bool bloodBankAdded = false;
            try
            {
                command.CommandText = "[bbms].[usp_AddBloodBank]";
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@bloodBankName", bloodBank.BloodBankName);
                command.Parameters.AddWithValue("@address", bloodBank.Address);
                command.Parameters.AddWithValue("@city", bloodBank.City);
                command.Parameters.AddWithValue("@contactNumber", bloodBank.ContactNumber);
                command.Parameters.AddWithValue("@userID", bloodBank.UserID);
                command.Parameters.AddWithValue("@password", bloodBank.Password);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    bloodBankAdded = true;
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return bloodBankAdded;
        }
        /// <summary>
        /// Updates Blood Bank
        /// </summary>
        /// <param name="bloodBank"></param>
        /// <returns></returns>
        public static bool UpdateBlooadBankDAL(BloodBank bloodBank)
        {
            bool bloodBankUpdated = false;
            try
            {
                command.CommandText = "bbms.usp_UpdateBloodBank";
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@bloodBankID", bloodBank.BloodBankID);
                command.Parameters.AddWithValue("@bloodBankName", bloodBank.BloodBankName);
                command.Parameters.AddWithValue("@address", bloodBank.Address);
                command.Parameters.AddWithValue("@city", bloodBank.City);
                command.Parameters.AddWithValue("@contactNumber", bloodBank.ContactNumber);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    bloodBankUpdated = true;
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }


            return bloodBankUpdated;
        }
        /// <summary>
        /// Deletes Blood Bank
        /// </summary>
        /// <param name="bloodBankID"></param>
        /// <returns></returns>
        public static bool DeleteBloodBankDAL(int bloodBankID)
        {
            bool bloodBankDeleted = false;

            try
            {
                command.CommandText = "bbms.usp_DeleteBloodBank";
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@bloodBankID", bloodBankID);
                
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    bloodBankDeleted = true;
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return bloodBankDeleted;
        }
        public static bool DonateBloodDAL()
        {
            return false;
        }
        public static BloodBank ViewDetailsDAL(int bloodBank)
        {
            return new BloodBank();
        }
        public static BloodBank SearchBloodBankDAL(int id)
        {
            BloodBank bloodBank = null;

            try
            {
                command.CommandText = "bbms.usp_SearchUserForUpdate";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@bloodBankID", id);

                connection.Open();
                SqlDataReader reader;

                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    bloodBank = new BloodBank();
                    bloodBank.BloodBankID = Convert.ToInt32(reader[0]);
                    bloodBank.BloodBankName = reader[1].ToString();
                    bloodBank.Address = reader[2].ToString();
                    bloodBank.City = reader[3].ToString();
                    bloodBank.ContactNumber = reader[4].ToString();
                    
                    
                }
                else
                {
                    throw new BloodBankException("Invalid Blood Bank with ID #" + id);
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
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return bloodBank;
        }
        public static List<BloodBank> GetBloodBankListDAL()
        {
            List<BloodBank> bloodBankList = null;
            try
            {
                command.CommandText = "bbms.usp_ViewBloodBanks";
                command.Parameters.Clear();               

                connection.Open();
                SqlDataReader reader;

                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    bloodBankList = new List<BloodBank>();
                    while (reader.Read())
                    {
                        BloodBank bloodBank = new BloodBank();
                        bloodBank.BloodBankID = Convert.ToInt32(reader[0]);
                        bloodBank.BloodBankName = reader[1].ToString();
                        bloodBank.Address = reader[2].ToString();
                        bloodBank.City = reader[3].ToString();
                        bloodBank.ContactNumber = reader[4].ToString();

                        bloodBankList.Add(bloodBank);

                    }
                }
                else
                {
                    throw new BloodBankException("No Blood Banks in the Data Base");
                }
            }
            catch(BloodBankException) 
            {
                throw;
            }
            catch(SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return bloodBankList;
        }

        #endregion

    }
}
