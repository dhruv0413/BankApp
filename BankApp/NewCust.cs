using System;
using System.Text.RegularExpressions;

namespace BankApp
{
    public static class NewCust
    {
        public static void AddCust()
        {
            Regex re = new Regex(@"^([A-Z]|[a-z]|\s)+$");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine().Trim();

            if (re.IsMatch(name))
            {
                Customer customer = new Customer(name);
                AllData.AddCustomer(customer);
                Console.WriteLine($"Customer {name} is added successfully with  CustomerId: {customer.CId}");
            }

            else
            {
                Console.WriteLine("Invalid Name");
            }
        }
        
    }
}
