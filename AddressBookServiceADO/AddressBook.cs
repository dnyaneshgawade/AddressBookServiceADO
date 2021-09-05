using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookServiceADO
{
    public class AddressBook
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookServiceADO";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}
