using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBMS.DAL;
using BBMS.Entity;
using BBMS.Exceptions;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace BBMS.BL
{
    public class HospitalValidations
    {
        public static int GetNextHospitalID_BL()
        {
            return HospitalOperations.GetNextHospitalID_DAL();
        }


        public static bool ValidateHospital(Hospital hospital)
        {
            StringBuilder errorString = new StringBuilder();
            bool hospitalValid = true;
            try
            {
                if (hospital.HospitalName == String.Empty)
                {
                    hospitalValid = false;
                    errorString.Append("Hospital Name Cannot Be Empty\n");
                }

                if (hospital.City == String.Empty)
                {
                    hospitalValid = false;
                    errorString.Append("City Cannot Be Empty\n");
                }

                if (hospital.Address == String.Empty)
                {
                    hospitalValid = false;
                    errorString.Append("Address Cannot be Empty");
                }

                if (!Regex.IsMatch(hospital.ContactNo, "^[7-9][0-9]{9}$"))
                {
                    hospitalValid = false;
                    errorString.Append("Invalid Phone Number");
                }
                if (!hospitalValid)
                    throw new BloodBankException(errorString.ToString());
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

            return hospitalValid;
        }

        public static bool AddHospitalDetails(Hospital hospital)
        {
            bool HospitalDetailsAdded = false;
            try
            {
                if (ValidateHospital(hospital))
                {


                    HospitalDetailsAdded = HospitalOperations.AddHospitalDetails_DAL(hospital);
                }
                else
                {
                    throw new BloodBankException("Hospital Details Are Invalid!");
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
            catch (SystemException ex)
            {
                throw ex;
            }

            return HospitalDetailsAdded;
        }

        public static bool UpdateHospital_BL(Hospital hospital)
        {
            bool hospitalUpdated = false;
            try
            {
                if (ValidateHospital(hospital))
                {
                    if (HospitalOperations.UpdateHospital_DAL(hospital))
                    {
                        hospitalUpdated = true;
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
            return hospitalUpdated;
        }

        public static bool DeleteHospital_BL(string hospitalName)
        {
            bool hospitalDeleted = false;
            try
            {
                hospitalDeleted = HospitalOperations.DeleteHospital_DAL(hospitalName);
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
            return hospitalDeleted;
        }

        public static List<Hospital> DisplayHospital_BL()
        {
            List<Hospital> hospitalList = null;
            try
            {
                hospitalList = HospitalOperations.DisplayHospital_DAL();
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
            return hospitalList;
        }


        public static Hospital SearchHospital_BL(string HospitalName)
        {
            Hospital hospital = null;
            try
            {
                hospital = HospitalOperations.SearchHospital_DAL(HospitalName);
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            return hospital;
        }

        public static int GetNextHospitalD_BL()
        {
            return HospitalOperations.GetNextHospitalID_DAL();
        }

    }
}
