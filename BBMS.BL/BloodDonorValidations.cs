using BBMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBMS.DAL;
using BBMS.Exceptions;

namespace BBMS.BL
{
    /// <summary>
    /// Name: Arunodoy Datta
    /// Description: This class is for BloodDonor Validations (Business Layer)
    /// Date of Creation: 
    /// Change Date: 04/09/2017
    /// </summary>

    public class BloodDonorValidations
    {
        public static bool ValidateDonor(BloodDonor donor)
        {
            bool donorValidated = true;
            
            return donorValidated;
        }
        public static bool AddDonor_BL(BloodDonor donor)
        {
            bool donorAdded = false;
            try
            {
                if (ValidateDonor(donor))
                {
                    donorAdded = BloodDonorOperations.AddDonor_DAL(donor);
                }
                else
                {
                    throw new BloodBankException("Donor Details Are Invalid!");
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
            return donorAdded;
        }
        public static bool UpdateDonor_BL(BloodDonor donor)
        {
            bool donorUpdated = false;
            try
            {
                if (ValidateDonor(donor))
                {
                    donorUpdated = BloodDonorOperations.UpdateDonor_DAL(donor);
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
            return donorUpdated;
        }
        public static bool DeleteDonor_BL(int donorID)
        {
            bool donorDeleted = false;
            try
            {
                donorDeleted = BloodDonorOperations.DeleteDonor_DAL(donorID);
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
            return donorDeleted;
        }
        
        public static List<BloodDonor> DisplayDonor_BL()
        {
            List<BloodDonor> donorList = null;
            try
            {
                donorList = BloodDonorOperations.DisplayDonors_DAL();
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            return donorList;
        }

        public static BloodDonor SearchDonor_BL(int donorId)
        {
            BloodDonor donor = null;
            try
            {
                donor = BloodDonorOperations.SearchDonor_DAL(donorId);
            }
            catch (BloodBankException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            return donor;
        }

        public static int GetNextDonorID_BL()
        {
            return BloodDonorOperations.GetNextDonorID_DAL();
        }
    }
}
