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
    /// <summary>
    /// Name: Arunodoy Datta
    /// Description: This class is for BloodDonor Operations(Data Access Layer)
    /// Date of Creation: 02-Oct-2017
    /// Change Date: 09-Oct-2017
    /// </summary>
    public class BloodDonorOperations
    {
        #region Variables
        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        #endregion

        #region Constructor
        static BloodDonorOperations()
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

        //Adding new Blood donor 
        public static bool AddDonor_DAL(BloodDonor bd)
        {
            bool donorAdded = false;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_AddDonor]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("", bd.FirstName);
                command.Parameters.AddWithValue("", bd.LastName);
                command.Parameters.AddWithValue("", bd.Address);
                command.Parameters.AddWithValue("", bd.City);
                command.Parameters.AddWithValue("", bd.MobileNo);
                command.Parameters.AddWithValue("", bd.BloodGroup);
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
        

        public static List<BloodDonor> DisplayDonors_DAL()
        {
            List<BloodDonor> donorList = new List<BloodDonor>();
            SqlDataReader rdr = null;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_AddDonor]";
                connection.Open();
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    BloodDonor bd = new BloodDonor()
                    {
                        BloodDonorID =Convert.ToInt32( rdr["BloodDonorID"]),
                        FirstName= rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Address = rdr["Address"].ToString(),
                        City = rdr["City"].ToString(),
                        MobileNo = rdr["MobileNo"].ToString(),
                        BloodGroup = rdr["BloodGroup"].ToString()
                    };
                    donorList.Add(bd);
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
            return donorList;

        }


        public static int GetNextEmpID_DAL()
        {

            command.CommandText = "[bbms].[bbms.usp_GetNextDonorID]";
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


        public static BloodDonor SearchDonor_DAL(int donorId)
        {
            BloodDonor donor = new BloodDonor();
            SqlDataReader rdr = null;
            try
            {

                command.CommandText = "[bbms].[bbms.usp_SearchDonor]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@BloodDonorID", donorId);
                connection.Open();
                DataTable dt = new DataTable();

                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        donor.BloodDonorID = (int)rdr["BloodDonorID"];
                        donor.FirstName = rdr["FirstName"].ToString();
                        donor.LastName=rdr["LastName"].ToString();
                        donor.Address = rdr["Address"].ToString();
                        donor.City= rdr["City"].ToString();
                        donor.MobileNo = rdr["MobileNo"].ToString();
                        donor.BloodGroup = rdr["BloodGroup"].ToString();
                    }
                }
                else
                {
                    throw new BloodBankException("No donor found with Donor ID" + donorId);
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
            return donor;
        }
        public static bool UpdateDonor_DAL(BloodDonor bd)
        {
            bool donorUpdated = false;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_UpdateDonor]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("", bd.BloodDonorID);
                command.Parameters.AddWithValue("", bd.FirstName);
                command.Parameters.AddWithValue("", bd.LastName);
                command.Parameters.AddWithValue("", bd.Address);
                command.Parameters.AddWithValue("", bd.City);
                command.Parameters.AddWithValue("", bd.MobileNo);
                command.Parameters.AddWithValue("", bd.BloodGroup);
                connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                    donorUpdated = true;

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
            return donorUpdated;
        }
        public static bool DeleteDonor_DAL(int id)
        {
            bool donorDeleted = false;
            try
            {
                command.CommandText = "[bbms].[bbms.usp_UpdateDonor]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@BloodDonorID", id);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    donorDeleted = true;
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
            return donorDeleted;
        }

        #endregion
    }
}
