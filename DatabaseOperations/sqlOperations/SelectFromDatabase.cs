using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace DatabaseOperations.sqlOperations
{
    public class SelectFromDatabase
    {
        public bool selectAllCustomers()
        {
            DatabaseConnect databaseConnect = DatabaseConnect.of();
            try
            {
                databaseConnect.cnn.Open();
                Console.WriteLine("Connection Open");
                string sql = "SELECT * FROM customers";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnect.cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                databaseConnect.cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool selectCustomer(int customerNr)
        {
            DatabaseConnect databaseConnect = DatabaseConnect.of();
            try
            {
                databaseConnect.cnn.Open();

                string sql = "SELECT * FROM customers WHERE customer_nr=@customerNr";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnect.cnn);
                cmd.Parameters.AddWithValue("@customerNr", customerNr);

                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                    }
                }
                else
                {
                    Console.WriteLine($"No rows found for customer with customer_Nr:{customerNr}");
                }

                databaseConnect.cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        
                //Still working on code
         public Boolean getAmountOfCopies()
         {
             string connectionString = null;
             MySqlConnection cnn;
             connectionString = "server=localhost;database=whatsapp;uid=root;pwd=;";
             cnn = new MySqlConnection(connectionString);
             try
             {
                 //Opens the connection to the database
                 cnn.Open();
                 Console.WriteLine("Connection Open");
                 //Database Query to execute
                 const string sql = "SELECT nr_copies FROM print_orders";
                 //Combines the action of the connection and the query
                 MySqlCommand cmd = new MySqlCommand(sql, cnn);
                 //Reads the data from the database as a value in the variable 'rdr'
                 MySqlDataReader rdr = cmd.ExecuteReader();
                 //Using a loop to read all the contents from the database related to the query
                 while (rdr.Read())
                 {
                     //Checks if the value is null
                     if (rdr[0] == null)
                     {
                         //If it is null execute the Console.WriteLine
                         Console.WriteLine("There is no value, it is null.");
                         return false;
                     }
                     else
                     {
                         //Converting object to int
                         int numberOfCopies = Convert.ToInt32(rdr[0]);
                         //Source directory for the PDF
                         string sourceDir = @"C:/Orders/0931617841_13_05_22/";
                         //Source directory for the new folder directory
                         string backupDir = @"C:/Orders/AmountOfCopies";

                         //If not null
                         try
                         {
                             //Gets the file composite.pdf inside the 'sourceDir' variable, which is instantiated above
                             string[] pdfList = Directory.GetFiles(sourceDir, "*.pdf");

                             // Copy pdf file.
                             foreach (string f in pdfList)
                             {
                                 //For loop to change the file name using 'i'
                                 for (int i = 0; i < numberOfCopies; i++)
                                 {
                                     string oldPath = @"C:/Orders/0931617841_13_05_22/composite.pdf";
                                     string newpath = @"C:/Orders/AmountOfCopies/";
                                     string newFileName = "composite" + i;
                                     FileInfo f1 = new FileInfo(oldPath);
                                     if(f1.Exists)
                                     {
                                         if(!Directory.Exists(newpath))
                                         {
                                             Directory.CreateDirectory(newpath); 
                                         }
                                         f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
                                     }
                                 }
                             }
                         }
                        //If no directory as that name is found execute exception
                         catch (DirectoryNotFoundException dirNotFound)
                         {
                             Console.WriteLine(dirNotFound.Message);
                         }
                     }
                 }
                 //Close the connection
                 cnn.Close();
                 Console.WriteLine("Connection Closed");
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
