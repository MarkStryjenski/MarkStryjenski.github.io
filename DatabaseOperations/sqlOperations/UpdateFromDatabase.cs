using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.models;
using MySql.Data.MySqlClient;

namespace DatabaseOperations.sqlOperations
{
    public class UpdateFromDatabase
    {
        public bool updateCustomerData(int customerNr,int balance,string telephoneNr)
        {
            DatabaseConnect databaseConnect = DatabaseConnect.of();
            Client client=Client.of(customerNr, balance, telephoneNr);

            try
            {
                databaseConnect.cnn.Open();

                string query = $"UPDATE customers SET " +
                    $"balance=@balance,telephone_nr=@telephoneNr WHERE customer_nr=@customerNr";
                MySqlCommand cmd = new MySqlCommand(query, databaseConnect.cnn);

                cmd.Parameters.AddWithValue("@customerNr", customerNr);
                cmd.Parameters.AddWithValue("@balance", client.balance);
                cmd.Parameters.AddWithValue("@telephoneNr", client.telephoneNr);

                MySqlDataReader rdr = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();
                //Console.WriteLine($"Data for customer with new customer_Nr:{customerNr} has been updated");
                databaseConnect.cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
    }
    public class DeleteFromDatabase
    {
        public bool deleteCustomerData(int customerNr)
        {
            DatabaseConnect databaseConnect = DatabaseConnect.of();
            try
            {
                databaseConnect.cnn.Open();
                string query = $"Delete FROM customers WHERE customer_nr=@customeNr";

                MySqlCommand cmd = new MySqlCommand(query, databaseConnect.cnn);
                cmd.Connection = databaseConnect.cnn;

                cmd.Parameters.AddWithValue("@customerNr", customerNr);


                cmd.ExecuteNonQuery();
                databaseConnect.cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
    }

}
