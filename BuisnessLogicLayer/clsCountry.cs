using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BuisnessLogicLayer
{

    public class clsCountry
    {
        enum enMode { AddNew = 1, Update = 2 };
        enMode Mode { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this.Mode = enMode.Update;
        }
        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = string.Empty;
            this.Mode = enMode.AddNew;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = string.Empty;
            if(clsCountriesDataAccess.GetCountryByID(CountryID,ref CountryName))
            {
                return new clsCountry(CountryID,CountryName);
            }
            else
            {
                return new clsCountry();
            }
        }
        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;
            if (clsCountriesDataAccess.GetCountryByCountryName(ref CountryID, CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return new clsCountry();
            }
        }

        public static bool IsCountryExist(int CountryID)
        {
            return clsCountriesDataAccess.IsCountryExist(CountryID);
        }
        public static bool IsCountryExist(string CountryName)
        {
            return clsCountriesDataAccess.IsCountryExist(CountryName);
        }
        private bool _AddNewCountry()
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName);
            return (this.CountryID != -1);
        }
        private bool _UpdateCountry()
        {
            return clsCountriesDataAccess.UpdateCountry(this.CountryID,this.CountryName);
        }
        public static bool DeleteCountry(int CountryID)
        {
            return clsCountriesDataAccess.DeleteCountry(CountryID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        } 
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewCountry())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    if (this._UpdateCountry()) return true;
                    else return false;
                   
            }
            return false;
        }
    }
}
