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
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------");

            GetUserContactByID(2);

            Console.WriteLine("-------------------");

            Console.ReadKey();
        }
    }
}
