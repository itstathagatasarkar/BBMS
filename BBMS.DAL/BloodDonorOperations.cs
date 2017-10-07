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
    class BloodDonorOperations
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
        public bool AddDonor(BloodDonor bd)
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
        public int GetDonorID()
        {
            int donorID = 0;

            return donorID;
        }

        public static List<BloodDonor> ViewDonors()
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
        #endregion
    }
}
