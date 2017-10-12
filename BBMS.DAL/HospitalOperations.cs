using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBMS.Entity;
using BBMS.Exceptions;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BBMS.DAL
{
    public class HospitalOperations
    {
        #region Variables
        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        #endregion

        #region Constructor
        static HospitalOperations()
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
        public static bool AddHospitalDetails_DAL(Hospital hptl)
        {
            bool HospitalAdded = false;
            try
            {
                command.CommandText = "[bbms].[usp_AddHospital]";
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@hospitalName", hptl.HospitalName);
                command.Parameters.AddWithValue("@address", hptl.Address);
                command.Parameters.AddWithValue("@city", hptl.City);
                command.Parameters.AddWithValue("@contactNo", hptl.ContactNo);
                connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                    HospitalAdded = true;

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
            return HospitalAdded;
        }

        public static List<Hospital> DisplayHospital_DAL()
        {

            List<Hospital> hospitalList = null;
            try
            {

                command.CommandText = "[bbms].[usp_ViewHospitalDetails]";

                connection.Open();
                command.Parameters.Clear();

                SqlDataReader rdr;
                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    hospitalList = new List<Hospital>();
                    while (rdr.Read())
                    {


                        Hospital hptl = new Hospital();
                        hptl.HospitalID = Convert.ToInt32(rdr[0]);

                        hptl.HospitalName = rdr[1].ToString();
                        hptl.Address = rdr[2].ToString();
                        hptl.City = rdr[3].ToString();
                        hptl.ContactNo = rdr[4].ToString();
                        hospitalList.Add(hptl);
                    }


                }
                else
                {
                    throw new BloodBankException("No details are available");
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
            catch (SystemException)
            {
                throw;
            }

            return hospitalList;

        }

        public static int GetNextHospitalID_DAL()
        {
            int id = -1;

            try
            {
                command.CommandText = "[bbms].[usp_CurrentHospitalID]";
                command.CommandType = CommandType.StoredProcedure;

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


        public static Hospital SearchHospital_DAL(string hospitalName)
        {
            Hospital hospital = new Hospital();
            SqlDataReader rdr = null;
            try
            {

                command.CommandText = "[bbms].[usp_SearchHospital]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@hospitalName", hospitalName);
                connection.Open();
                DataTable dt = new DataTable();

                rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        hospital.HospitalID = (int)rdr["HospitalId"];

                        hospital.HospitalName = rdr["HospitalName"].ToString();
                        hospital.Address = rdr["Address"].ToString();
                        hospital.City = rdr["City"].ToString();
                        hospital.ContactNo = rdr["ContactNo"].ToString();

                    }
                }
                else
                {
                    throw new BloodBankException("No Hospital found with Hospital Name" + hospitalName);
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
            return hospital;
        }

        public static bool UpdateHospital_DAL(Hospital hptl)
        {
            bool hospitalUpdated = false;
            try
            {
                command.CommandText = "[bbms].[usp_UpdateHospital]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@hospitalID", hptl.HospitalID);
                command.Parameters.AddWithValue("@hospitalName", hptl.HospitalName);
                command.Parameters.AddWithValue("@address", hptl.Address);

                command.Parameters.AddWithValue("@city", hptl.City);
                command.Parameters.AddWithValue("@contactNo", hptl.ContactNo);

                connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                    hospitalUpdated = true;

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
            return hospitalUpdated;
        }

        public static bool DeleteHospital_DAL(string name)
        {
            bool hospitalDeleted = false;
            try
            {
                command.CommandText = "[bbms].[usp_DeleteHospital]";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@hospitalName", name);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    hospitalDeleted = true;
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
            return hospitalDeleted;
        }

        #endregion
    }
}
