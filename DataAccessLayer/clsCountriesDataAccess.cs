using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCountriesDataAccess
    {
        public static bool GetCountryByID(int CountryID, ref string CountryName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionsString))
            {
                string query = "SELECT * FROM Countries WHERE CountryID = @CountryID;";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            CountryName = (string)reader["CountryName"];
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }
        public static bool GetCountryByCountryName(ref int CountryID,string CountryName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionsString))
            {
                string query = "SELECT * FROM Countries WHERE CountryName = @CountryName;";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            CountryID = (int)reader["CountryID"];
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }

        public static int AddNewCountry(string CountryName) 
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionsString))
            {
                string query = "INSERT INTO countries VALUES(@CountryName); SELECT SCOPE_";

                using(SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@CountryName", CountryName);
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(),out int InsertedID)) 
                    {
                        return InsertedID;
                    }
                }
            }
            return -1;
        }

        public static bool DeleteCountry(string CountryID) 
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionsString))
            {
                string query = "DELETE From Countries WHERE CountryId = @CountryID;";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    connection.Open();
                    RowsAffected = cmd.ExecuteNonQuery();

                }
            }
            return (RowsAffected > 0);  
        }
        public static bool UpdateCountry(int CountryID,string CountryName)
        {
            int RowsAffected = 0;
            using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionsString))
            {
                string query = "UPDATE Countries SET CountryName = @CountryName;";
                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CountryID",CountryID);
                    connection.Open();
                    RowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return(RowsAffected > 0);
        }
    }
}
