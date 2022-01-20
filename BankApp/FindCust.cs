using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class FindCust
    {
        public static Customer FindAcById()
        {
            int cid;

            Console.Write("Enter CustomerID (Press 0 to go back) : ");
            try
            {
                string input = Console.ReadLine();
                if (input.Length > 10)
                {
                    throw new FormatException();
                }
                cid = int.Parse(input);

                if (cid == 0) { return null; }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Not Valid CustomerID");
                return null;
            }

            if (AllData.AllCustomers.TryGetValue(cid, out Customer customer))
            {
                return customer;
            }
            else
            {
                Console.WriteLine("Customer Does not exist");
                return null;
            }

        }
    }
}
