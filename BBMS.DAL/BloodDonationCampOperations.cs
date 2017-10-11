using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBMS.Entity;
using BBMS.Exceptions;

namespace BBMS.DAL
{
    /// <summary>
    /// Name: Arunodoy Datta
    /// Description: This class is for Blood Donation Camp Operations(Data Access Layer)
    /// Date of Creation: 10-Oct-2017
    /// Change Date: 11-Oct-2017
    /// </summary>
    public class BloodDonationCampOperations
    {
        #region Variables
        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        #endregion

        #region Constructor
        static BloodDonationCampOperations()
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

        public static bool AddBloodDonationCamp_DAL(BloodDonationCamp bdcamp)
        {
            bool donorAdded = false;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_AddBloodDonationCamp]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("", bdcamp.BloodDonationCampID);
                command.Parameters.AddWithValue("", bdcamp.CampName);
                command.Parameters.AddWithValue("", bdcamp.Address);
                command.Parameters.AddWithValue("", bdcamp.City);
                command.Parameters.AddWithValue("", bdcamp.CampStartDate);
                command.Parameters.AddWithValue("", bdcamp.CampEndDate);
                
                connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                    donorAdded = true;

            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return donorAdded;
        }

        public static List<BloodDonationCamp> DisplayBloodDonationCamp_DAL()
        {
            List<BloodDonationCamp> campList = new List<BloodDonationCamp>();
            SqlDataReader rdr = null;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_ViewBloodDonationCamp]";
                connection.Open();
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    BloodDonationCamp bdcamp = new BloodDonationCamp()
                    {
                        BloodDonationCampID = Convert.ToInt32(rdr["BloodDonationCampID"]),
                        CampName = rdr["CampDate"].ToString(),
                        Address = rdr["Address"].ToString(),
                        City = rdr["City"].ToString(),
                        CampStartDate=Convert.ToDateTime( rdr["CampStartDate"]),
                        CampEndDate = Convert.ToDateTime(rdr["CampEndDate"]),
                    };
                    campList.Add(bdcamp);
                }
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                rdr.Close();
                connection.Close();
            }
            return campList;

        }

        public static bool UpdateBloodDonationCamp_DAL(BloodDonationCamp bdcamp)
        {
            bool campUpdated = false;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_UpdateBLoodDonationCamp]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("", bdcamp.BloodDonationCampID);
                command.Parameters.AddWithValue("", bdcamp.CampName);
                command.Parameters.AddWithValue("", bdcamp.Address);
                command.Parameters.AddWithValue("", bdcamp.City);
                command.Parameters.AddWithValue("", bdcamp.CampStartDate);
                command.Parameters.AddWithValue("", bdcamp.CampEndDate);
                connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                    campUpdated = true;

            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return campUpdated;
        }

        public static BloodDonationCamp SearchBloodDonationCamp_DAL(int id)
        {
            BloodDonationCamp camp = new BloodDonationCamp();
            SqlDataReader rdr = null;
            try
            {

                command.CommandText = "[bbms].[bbms.usp_SearchBloodDonationCamp]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@BloodDonationCampID", id);
                connection.Open();
                DataTable dt = new DataTable();

                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        camp.BloodDonationCampID = (int)rdr["BloodDonorID"];
                        camp.CampName = rdr["CampName"].ToString();
                        camp.Address = rdr["Address"].ToString();
                        camp.City = rdr["City"].ToString();
                        camp.CampStartDate = (DateTime)rdr["CampStartDate"];
                        camp.CampEndDate = (DateTime)rdr["CampEndDate"];
                    }
                }
                else
                {
                    throw new BloodBankException("No donor found with Donor ID" + id);
                }
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                rdr.Close();
                connection.Close();
            }
            return camp;
        }

        public static int GetNextBloodDonationCampID_DAL()
        {

            command.CommandText = "[bbms].[bbms.usp_GetNexBloodDonationCampID]";
            command.CommandType = CommandType.StoredProcedure;
            int id;
            try
            {
                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return id;
        }

        #endregion
    }
}
