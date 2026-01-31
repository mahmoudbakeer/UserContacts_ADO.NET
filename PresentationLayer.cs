using BuisnessLogicLayer;
using System;
using System.Collections.Generic;
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
        public static bool InsertNewUser(clsContact Contact)git init
git branch -M main
git remote add origin https://github.com/USERNAME/REPO_NAME.git

        {
            return(Contact.Save());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------");

            //GetUserContactByID(2);

            Console.WriteLine("-------------------");

            clsContact contact = new clsContact();
            contact.FirstName = "Maher";
            contact.LastName = "Sadik";
            contact.Email = "Hallo@gmail.com";
            contact.Phone = "213442412";
            contact.DateOfBirth = new DateTime(1999,11,27);
            contact.Address = "Harah/Syria/MiddleEast";
            contact.CountryID = 2;

            if (InsertNewUser(contact))
            {
                Console.WriteLine($"The User Added Successfully NewID is {contact.ID}");
            }
            else { Console.WriteLine("Error Occured ..."); }
                Console.ReadKey();
        }
    }
}
