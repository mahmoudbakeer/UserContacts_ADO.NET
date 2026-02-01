using BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierArch_ADO.NET
{
    internal class PresentationLayer
    {
        public static void GetUserContactByID(int ID)
        {
            clsContact Contact = clsContact.Find(ID);
            if (Contact != null)
            {
                Console.WriteLine($"ID : {Contact.ID}");
                Console.WriteLine($"FirstName : {Contact.FirstName}");
                Console.WriteLine($"LastName : {Contact.LastName}");
                Console.WriteLine($"Email : {Contact.Email}");
                Console.WriteLine($"Phone : {Contact.Phone}");
                Console.WriteLine($"Adress : {Contact.Address}");
                Console.WriteLine($"DateOfBirth : {Contact.DateOfBirth}");
                Console.WriteLine($"ImagePath : {Contact.ImagePath}");
                Console.WriteLine($"Code : {Contact.Code}");
                Console.WriteLine($"PhoneCode : {Contact.PhoneCode}");
                Console.WriteLine($"CountryID : {Contact.CountryID}");
            }
            else
            {
                Console.WriteLine("There is no such User...");
            }
        }
        public static bool InsertNewUser(clsContact Contact)
        {
            return(Contact.Save());
        }
        public static void DeleteUserContact(int ContactID)
        {
            if (clsContact.DeleteContact(ContactID))
            {
                Console.WriteLine("The Contacts Deleted Successfully ....");
            }
            else
            {
                Console.WriteLine("Somthing Went Wrong....");
            }
        }
        public static void UpdateContact(int ID)
        {
            clsContact contact = clsContact.Find(ID);
            Console.WriteLine("Before Update :");
            GetCountryByID(ID);
            if (contact != null)
            {
                Console.WriteLine("Enter the required The New Data : ");
                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Email: ");
                contact.Email = Console.ReadLine();

                Console.Write("Phone: ");
                contact.Phone = Console.ReadLine();

                Console.Write("Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("Country ID: ");
                contact.CountryID = int.Parse(Console.ReadLine());

                Console.Write("Code : ");
                contact.Code = Console.ReadLine();

                Console.Write("PhoneCode : ");
                contact.PhoneCode = Console.ReadLine();

                Console.Write("Date of Birth (yyyy-mm-dd): ");
                contact.DateOfBirth = DateTime.Parse(Console.ReadLine());

                if (contact.Save())
                    Console.WriteLine("The Contact Updated Successfully...");
                else
                    Console.WriteLine("Error Occurred...");
            }

        }

        public static bool IsContactExist(int ContactID)
        {
            return clsContact.IsContactExist(ContactID);
        }
        public static void ShowAllContacts()
        {
            DataTable dt = clsContact.GetAllContacts();
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"ContactID : {row["ContactID"].ToString()}  ,  Name {row["FirstName"] + " " + row["LastName"]}");
            }
        }

        /*
         
         Countries Functionalities
         
         */

        public static void GetCountryByID(int CountryID)
        {
            clsCountry Country = clsCountry.Find(CountryID);    
            if (Country != null)
            {
                Console.WriteLine($"CountryID : {Country.CountryID}");
                Console.WriteLine($"CountryName : {Country.CountryName}");
            }
            else
            {
                Console.WriteLine("There is no such Country...");
            }
        }
        public static void GetCountryByName(string CountryName)
        {
            clsCountry Country = clsCountry.Find(CountryName);
            if (Country != null)
            {
                Console.WriteLine($"CountryID : {Country.CountryID}");
                Console.WriteLine($"CountryName : {Country.CountryName}");
            }
            else
            {
                Console.WriteLine("There is no such Country...");
            }
        }

        public static void InsertNewCountry(string CountryName)
        {
            clsCountry country  = new clsCountry();
            country.CountryName = CountryName;
            if (country.Save())
            {
                Console.WriteLine($"The Country Has been Added Successfully ..");
                Console.WriteLine($"The New Added CountryID is : {country.CountryID}");
            }
            else
            {
                Console.WriteLine("Somthing Went Wrong ...");
            }
        }

        public static void DeleteCountry(int CountryID) 
        {
            if (clsCountry.DeleteCountry(CountryID))
            {
                Console.WriteLine("Country Has Been Deleted Successfully ..");
            }
            else
            {
                Console.WriteLine("Somthing Went Wrong ..");
            }
        }
        public static void UpdateCountry(clsCountry country)
        {
            if (country.Save())
            {
                Console.WriteLine("Country Updated Successfully ...");
                Console.WriteLine($"CountryID : {country.CountryID}");
                Console.WriteLine($"CountryName : {country.CountryName}");
            }
            else
            {
                Console.WriteLine("Somthing Went Wrong ..");
            }
        }

        public static void IsCountryExist(int CountryID) 
        {
            if (clsCountry.IsCountryExist(CountryID))
            {
                Console.WriteLine("The Country is Exist ...");
            }
            else
            {
                Console.WriteLine("The Country is Not Exist ...");

            }
        }
        public static void IsCountryExist(string CountryName)
        {
            if (clsCountry.IsCountryExist(CountryName))
            {
                Console.WriteLine("The Country is Exist ...");
            }
            else
            {
                Console.WriteLine("The Country is Not Exist ...");
            }
        }

        public static void ShowAllTheCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();

            if(dt.Rows.Count > 0)
            {
                Console.WriteLine("The Available Countries in The DataBase :");
                foreach(DataRow dr in dt.Rows)
                {
                    Console.WriteLine($"CountryID is {dr["CountryID"]}");
                    Console.WriteLine($"CountryName is {dr["CountryName"]}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Available Countries in the DataBase ...");
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("===== CONTACT TEST CONSOLE =====");

            // -------- INSERT CONTACT --------
            Console.WriteLine("\n--- Insert New Contact ---");

            clsContact contact = new clsContact();

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("Phone: ");
            contact.Phone = Console.ReadLine();

            Console.Write("Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Country ID: ");
            contact.CountryID = int.Parse(Console.ReadLine());

            Console.Write("Code : ");
            contact.Code = Console.ReadLine();

            Console.Write("PhoneCode : ");
            contact.PhoneCode = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            contact.DateOfBirth = DateTime.Parse(Console.ReadLine());

            if (InsertNewUser(contact))
                Console.WriteLine($"✔ Contact added successfully. New ID = {contact.ID}");
            else
                Console.WriteLine("✖ Failed to add contact.");

            // -------- GET CONTACT --------
            Console.WriteLine("\n--- Get Contact By ID ---");
            Console.Write("Enter Contact ID: ");
            int contactID = int.Parse(Console.ReadLine());
            GetUserContactByID(contactID);

            // -------- UPDATE CONTACT --------
            Console.WriteLine("\n--- Update Contact ---");
            Console.Write("Enter Contact ID to update: ");
            int updateID = int.Parse(Console.ReadLine());
            UpdateContact(updateID);

            // -------- CHECK EXISTENCE --------
            Console.WriteLine("\n--- Check Contact Existence ---");
            Console.Write("Enter Contact ID: ");
            int existID = int.Parse(Console.ReadLine());
            Console.WriteLine(
                IsContactExist(existID)
                ? "✔ Contact exists."
                : "✖ Contact does not exist."
            );

            // -------- SHOW ALL CONTACTS --------
            Console.WriteLine("\n--- All Contacts ---");
            ShowAllContacts();

            // -------- DELETE CONTACT --------
            Console.WriteLine("\n--- Delete Contact ---");
            Console.Write("Enter Contact ID to delete: ");
            int deleteID = int.Parse(Console.ReadLine());
            DeleteUserContact(deleteID);

            //--------COUNTRY TESTS--------
            Console.WriteLine("\n===== COUNTRY TESTS =====");

            // Insert country
            Console.Write("\nEnter new country name: ");
            string countryName = Console.ReadLine();
            InsertNewCountry(countryName);

            // Get country by name
            Console.Write("\nEnter country name to search: ");
            GetCountryByName(Console.ReadLine());

            // Get country by ID
            Console.Write("\nEnter country ID to search: ");
            GetCountryByID(int.Parse(Console.ReadLine()));

            // Check country existence
            Console.Write("\nCheck country by ID: ");
            IsCountryExist(int.Parse(Console.ReadLine()));

            Console.Write("\nCheck country by name: ");
            IsCountryExist(Console.ReadLine());

            Console.WriteLine("\n===== TESTING FINISHED =====");
            Console.ReadKey();
        }

    }
}
