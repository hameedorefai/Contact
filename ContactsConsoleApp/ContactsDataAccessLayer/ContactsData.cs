using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    internal static class clsContactDataAccess
    {
        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName,
                                    ref string Email, ref string Phone, ref string Address, 
                                    ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Contacts where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    ImagePath = (string)reader["ImagePath"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // do whatever you want to 
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        static public bool GetContactInfoByID(int iD, ref string firstName, ref string lastName, ref string email, ref string phone, ref string address, ref DateTime dateOfBirth, ref string imagePath)
        {
            throw new NotImplementedException();
        }
    }
}
 