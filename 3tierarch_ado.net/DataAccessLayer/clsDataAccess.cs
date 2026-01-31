using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsContactsDataAccess
    {
        public static bool GetContactInfoByID(
     int ID,
     ref string FirstName,
     ref string LastName,
     ref string Address,
     ref DateTime DateOfBirth,
     ref string Email,
     ref string Phone,
     ref string ImagePath,
     ref int CountryID)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                   new SqlConnection(DataAccessSettings.ConnectionsString))
            {
                string query = @"SELECT 
                            FirstName, LastName, Address, DateOfBirth,
                            Email, Phone, ImagePath, CountryID
                         FROM Contacts
                         WHERE ContactID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            FirstName = reader["FirstName"].ToString();
                            LastName = reader["LastName"].ToString();
                            Address = reader["Address"].ToString();
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Email = reader["Email"].ToString();
                            Phone = reader["Phone"].ToString();
                            CountryID = (int)reader["CountryID"];
                            ImagePath = reader["ImagePath"] == DBNull.Value
                                        ? ""
                                        : reader["ImagePath"].ToString();
                        }
                    }
                }
            }

            return IsFound;
        }

    }
}
