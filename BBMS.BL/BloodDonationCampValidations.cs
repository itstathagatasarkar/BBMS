using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBMS.Entity;
using BBMS.DAL;
using BBMS.Exceptions;

namespace BBMS.BL
{
    /// <summary>
    /// Name: Arunodoy Datta
    /// Description: This class is for Blood Donation Camp Validations (Business Layer)
    /// Date of Creation: 10/10/2017
    /// Change Date: 11/09/2017
    /// </summary>
    public class BloodDonationCampValidations
    {
        public static bool ValidateBloodDonationCamp(BloodDonationCamp donor)
        {
            bool campValidated = true;

            return campValidated;
        }

        public static bool AddBloodDonationCamp_BL(BloodDonationCamp donor)
        {
            bool campAdded = false;
            try
            {
                if (ValidateBloodDonationCamp(donor))
                {
                    campAdded = BloodDonationCampOperations.AddBloodDonationCamp_DAL(donor);
                }
                else
                {
                    throw new BloodBankException("Blood Donation Camp Details Are Invalid!");
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
            return campAdded;
        }

        public static List<BloodDonationCamp> DisplayBloodDonationCamp_BL()
        {
            List<BloodDonationCamp> campList = null;
            try
            {
                campList = BloodDonationCampOperations.DisplayBloodDonationCamp_DAL();
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            return campList;
        }

        public static bool UpdateDonationCamp_BL(BloodDonationCamp donor)
        {
            bool campUpdated = false;
            try
            {
                if (ValidateBloodDonationCamp(donor))
                {
                    campUpdated = BloodDonationCampOperations.UpdateBloodDonationCamp_DAL(donor);
                }
                else
                {
                    throw new BloodBankException("Blood Donation Camp Details Are Invalid!");
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
            return campUpdated;
        }

        public static int GetNextBloodDonationCampID_BL()
        {
            return BloodDonationCampOperations.GetNextBloodDonationCampID_DAL();
        }
    }
}
