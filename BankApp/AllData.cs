using System;
using System.Collections.Generic;

namespace BankApp
{
    public static class AllData
    {
        public static Dictionary<int, Account> AllAccounts = new Dictionary<int, Account>();

        public static Dictionary<int, Customer> AllCustomers = new Dictionary<int, Customer>();

        public static void AddCustomer(Customer c)
        {
            AllCustomers.Add(c.CId, c);
            Console.WriteLine();
        }

        public static void AddAccount(Account a)
        {
            AllAccounts.Add(a.AccountNum, a);
            Console.WriteLine();
        }
    }
}
