using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class clsContact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }

        public clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
        }
        public clsContact()
        {
            this.ID = -1;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;
            this.Address = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = string.Empty;
        }
        public static clsContact Find(int id)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", ImagePath = ""
             , Adress = "";
            int CountryID = 0;
            DateTime DateOfBirth = DateTime.MinValue;
            if (clsContactsDataAccess.GetContactInfoByID(id, ref FirstName, ref LastName, ref Adress, ref DateOfBirth, ref Email, ref Phone, ref ImagePath, ref CountryID))
            {
                return new clsContact(id, FirstName, LastName, Email, Phone, Adress, DateOfBirth, CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
    }
}
