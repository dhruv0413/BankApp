using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Customer
    {
        public string Name;
        public int CId { get; private set; }

        public Dictionary<int,Account> Accounts= new Dictionary<int, Account>();


        public Customer(string name)
        {
            Name = name;
            CId= UniqueID.GenerateUniqueID();
        }


        public void AddAccount(Account a)
        {
            Accounts.Add(a.AccountNum, a);
        }

        public void DisplayAllAccountBalace()
        {
            foreach(var i in Accounts)
            {
                i.Value.ShowBalance();
            }
        }



    }
}
