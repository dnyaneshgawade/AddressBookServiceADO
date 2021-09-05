using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookServiceADO
{
    public class AddressBookOperations
    {
        public List<AddressBook> list = new List<AddressBook>();
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

        public void DeleteAddress()
        {
            try
            {
                SqlCommand command = new SqlCommand("spDeleteAddress", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                Console.Write("\n Enter FirstName");
                string firstName = Console.ReadLine();
                command.Parameters.AddWithValue("@FirstName", firstName);
                sqlConnection.Open();
                int i = command.ExecuteNonQuery();
                if (i >= 1)
                {
                    Console.WriteLine("Data Deleted sucessfully...");
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

        public List<AddressBook> RetrieveAddressBelongsToCityOrState()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spRetrieveAddressBelongsToCityOrState", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Enter City and State\n ");
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", city);
                sqlCommand.Parameters.AddWithValue("@State", state);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlConnection.Open();
                da.Fill(dataTable);

                list.Clear();
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(
                        new AddressBook
                        {
                            AddressId = Convert.ToInt32(dr["AddressId"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Address = Convert.ToString(dr["Address"]),
                            City = Convert.ToString(dr["City"]),
                            State = Convert.ToString(dr["State"]),
                            Zip = Convert.ToDouble(dr["Zip"]),
                            PhoneNumber = Convert.ToDouble(dr["PhoneNumber"]),
                            Email = Convert.ToString(dr["Email"]),
                        }
                        );
                }
                return list;
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

        public void Display()
        {
            foreach (AddressBook record in list)
            {
                Console.WriteLine("_________________________________");
                Console.WriteLine("Address Id  :" + record.AddressId);
                Console.WriteLine("First name :" + record.FirstName);
                Console.WriteLine("Last Name :" + record.LastName);
                Console.WriteLine("Address :" + record.Address);
                Console.WriteLine("City :" + record.City);
                Console.WriteLine("State :" + record.State);
                Console.WriteLine(" Zip:" + record.Zip);
                Console.WriteLine("PhoneNumber :" + record.PhoneNumber);
                Console.WriteLine("Email :" + record.Email);
                Console.WriteLine("_________________________________\n\n");
            }
        }
        public void Operations()
        {
            while (choice != 15)
            {
                Console.WriteLine("\n Enter 1 for Add Address Record" +
                    "\n Enter 2 for Update Address Record"+
                    "\n Enter 3 for Delete Address Record" +
                    "\n Enter 4 for Retrive Address belongs to City or State" +
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
                    case 3:
                        DeleteAddress();
                        break;
                    case 4:
                        RetrieveAddressBelongsToCityOrState();
                        Display();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }
    }
}
