using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using BBMS.DAL;
using BBMS.Entity;
using BBMS.Exceptions;
using System.Data.SqlClient;

namespace BBMS.BL
{
    /// <summary>
    /// Name: Tathagata Sarkar
    /// </summary>
    public class BloodBankValidations
    {
        public static int GetNextBloodBankIdBL()
        {
            return BloodBankOperations.GetCurrentBloodBankIdDAL();
        }

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

        public static bool ValidateBloodBankInput(BloodBank bloodBank)
        {
            StringBuilder errorString = new StringBuilder();
            bool bloodBankValid = true;
            try
            {
                if (bloodBank.BloodBankName == String.Empty)
                {
                    bloodBankValid = false;
                    errorString.Append("Blood Bank Name Cannot Be Empty\n");
                }

                if (bloodBank.City == String.Empty)
                {
                    bloodBankValid = false;
                    errorString.Append("City Cannot Be Empty\n");
                }

                if (bloodBank.Address == String.Empty)
                {
                    bloodBankValid = false;
                    errorString.Append("Address Cannot be Empty");
                }

                if (!Regex.IsMatch(bloodBank.ContactNumber, "^[7-9][0-9]{9}$"))
                {
                    bloodBankValid = false;
                    errorString.Append("Invalid Phone Number");
                }
                throw new BloodBankException(errorString.ToString());
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
            
            return bloodBankValid;
        }

        public static bool AddBloodBankBL(BloodBank bloodBank)
        {
            bool bloodBankAdded = false;
            try
            {
                if (ValidateBloodBankInput(bloodBank))
                {
                    if (BloodBankOperations.AddBloodBankDAL(bloodBank))
                    {
                        bloodBankAdded = true;
                    }
                }
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

            return bloodBankAdded;
        }

        public static bool UpdateBloodBankBL(BloodBank bloodBank)
        {
            throw new NotImplementedException();
        }

        public static BloodBank SearchBloodBankBL(int id)
        {
            BloodBank bloodBank = null;
            try
            {
                bloodBank = BloodBankOperations.SearchBloodBankDAL(id);
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
            return bloodBank;
        }

    }
}
