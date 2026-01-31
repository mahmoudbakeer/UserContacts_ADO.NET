using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    enum enMode { AddNew = 1, Update = 2 };
    public class clsContact
    {
        private enMode Mode { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }

        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            // The First thing to notice is no object should be instanciated with value 
            // to ensure this you will make the par. constructor as private
            // Image instanciating object that doesn't exist in Database
            // the par. constructor should be used to just when returning object not creating it
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
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
            this.ImagePath = "";
            this.Mode = enMode.AddNew;

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

        private bool _UpdateContact()
        {
            return (clsContactsDataAccess.UpdateContact(ID, FirstName,LastName,Address,DateOfBirth,Email,Phone,ImagePath,CountryID));
        }

        private bool _AddNewContact()
        {
            this.ID = clsContactsDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email,this.DateOfBirth,this.Email,this.Phone,this.ImagePath,this.CountryID);
            return (this.ID != -1);
        }
        public static bool DeleteContact(int ContactID)
        {
            return (clsContactsDataAccess.DeleteContact(ContactID));
        }

        public static bool IsContactExist(int ContactID)
        {
            return clsContactsDataAccess.IsContactExist(ContactID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactsDataAccess.GetAllContacts();
        }
        public bool Save() 
        { 
            switch(Mode) 
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else return false;
                case enMode.Update:
                    if (_UpdateContact()) return true;
                    else return false;
            }
            return false;
        }
    }
  
}
