using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
                    cmd.Parameters.AddWithValue("@ID", ID);

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

        public static int AddNewContact(
         string FirstName,
         string LastName,
         string Address,
         DateTime DateOfBirth,
         string Email,
         string Phone,
         string ImagePath,
         int CountryID)
        {
            int NewID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionsString))
            {
                string query = "INSERT INTO Contacts (FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath) " +
                    "VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath); " +
                    "SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@ImagePath", (ImagePath == "") ? (object)System.DBNull.Value : ImagePath);
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);

                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int InsertedID))
                    {
                        NewID = InsertedID;
                    }

                }
            }
            return NewID;
        }

        public static bool UpdateContact(
             int ID,
             string FirstName,
             string LastName,
             string Address,
             DateTime DateOfBirth,
             string Email,
             string Phone,
             string ImagePath,
             int CountryID)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionsString)) 
            {
                string query = "UPDATE Contacts SET FirstName = @FirstName,LastName = @LastName,Email = @Email,Phone = @Phone,Address = @Address,DateOfBirth = @DateOfBirth,CountryID = @CountryID , ImagePath = @ImagePath" +
                    " WHERE ContactID = @ID";
                using(SqlCommand cmd = new SqlCommand(query,connection))
                
                {

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@ImagePath", (ImagePath == "") ? (object)System.DBNull.Value : ImagePath);
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    connection.Open();
                    RowsAffected = cmd.ExecuteNonQuery();

                }
            }
            return (RowsAffected > 0);
        }

        public static bool DeleteContact(int ContactID)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionsString))
            {
                string query = "DELETE FROM Contacts WHERE ContactID = @ContactID";
                using (SqlCommand cmd = new SqlCommand(query, connection)) 
                {
                    cmd.Parameters.AddWithValue("@ContactID", ContactID);
                    connection.Open();
                    RowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return (RowsAffected > 0);
        }

        public static DataTable GetAllContacts()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionsString)) 
            {
                string query = "SELECT * FROM Contacts";
                using(SqlCommand cmd = new SqlCommand(query,connection))
                {
                    connection.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            datatable.Load(reader);
                            return datatable;
                        }
                    }
                }
            }
            return datatable;
        }

        public static bool IsContactExist(int ContactID)
        {
            using(SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionsString))
            {
                string query = "Select Found = 1 FROM Contacts WHERE ContactID = @ContactID";

                using(SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@ContactID", ContactID);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && (int)result > 0;
                }
            }
        }
    }
}
