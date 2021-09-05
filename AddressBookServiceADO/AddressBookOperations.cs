using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookServiceADO
{
    public class AddressBookOperations
    {
        public static int choice;
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookServiceADO";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void AddEmployee()
        {
            SqlCommand command = new SqlCommand("spInsertAddress", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter FirstName, LastName,Address, City, State, Zip,PhoneNumber, Email");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string address = Console.ReadLine();
            string city = Console.ReadLine();
            string state = Console.ReadLine();
            double zip = Convert.ToDouble(Console.ReadLine());
            double phoneNumber = Convert.ToDouble(Console.ReadLine());
            string email = Console.ReadLine();
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@City", city);
            command.Parameters.AddWithValue("@State", state);
            command.Parameters.AddWithValue("@Zip",zip);
            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@Email",email);

            sqlConnection.Open();
            int i = command.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {
                Console.WriteLine("Data inserted sucessfully...");
            }
            else
            {
                Console.WriteLine("Something went wrong... ");
            }
        }

        public void UpdateAddress()
        {
            try
            {
                SqlCommand command = new SqlCommand("spUpdateAddress",sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                Console.Write("\n Enter FirstName And Address ");
                string firstName = Console.ReadLine();
                string address = Console.ReadLine();
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@FirstName", firstName);
                sqlConnection.Open();
                int i = command.ExecuteNonQuery();
                if (i >= 1)
                {
                    Console.WriteLine("Data Updated sucessfully...");
                }
                else
                    Console.WriteLine("Something went wrong... ");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void Operations()
        {
            while (choice != 15)
            {
                Console.WriteLine("\n Enter 1 for Add Address Record" +
                    "\n Enter 2 for Update Address Record"+
                    "\n Enter 15 for Exit");
                Console.WriteLine("\n Enter Your Choice ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        UpdateAddress();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }
    }
}
