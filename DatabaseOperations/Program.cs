
using DatabaseOperations.sqlOperations;
using System;

namespace DatabaseOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            //new SelectFromDatabase().selectAllCustomers();
            new SelectFromDatabase().selectCustomer(1);
            //new UpdateFromDatabase().updateCustomerData(1,22,"+48");
        }
    }
}
