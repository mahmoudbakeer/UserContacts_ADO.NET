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

            if (contact != null)
            {
                contact.FirstName = "SOSO";
                contact.LastName = "Sadik";
                contact.Email = "Kifak@gmail.com";
                contact.Phone = "213442412";
                contact.DateOfBirth = new DateTime(1999, 11, 27);
                contact.Address = "REEF/Syria/MiddleEast";
                contact.CountryID = 2;

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
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------");

            //GetUserContactByID(2);

            Console.WriteLine("-------------------");

            //clsContact contact = new clsContact();
            //contact.FirstName = "SOSO";
            //contact.LastName = "Sadik";
            //contact.Email = "Kifak@gmail.com";
            //contact.Phone = "213442412";
            //contact.DateOfBirth = new DateTime(1999,11,27);
            //contact.Address = "REEF/Syria/MiddleEast";
            //contact.CountryID = 2;

            //if (InsertNewUser(contact))
            //{
            //    Console.WriteLine($"The User Added Successfully NewID is {contact.ID}");
            //}
            //else { Console.WriteLine("Error Occured ..."); }

            //Console.WriteLine("-------------------");

            //GetUserContactByID(6);

            //Console.WriteLine("-------------------");

            //UpdateContact(6);


            //Console.WriteLine("-------------------");

            //GetUserContactByID(6);

            //Console.WriteLine("-------------------");


            //DeleteUserContact(12);


            Console.WriteLine("-------------------");
            ShowAllContacts();
            Console.WriteLine("-------------------");

            Console.ReadKey();
        }
    }
}
