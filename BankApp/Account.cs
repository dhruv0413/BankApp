using System;
using System.Collections.Generic;

namespace BankApp
{
    public enum Type { Saving, Current };

    public class Account
    {
        public int AccountNum { get; private set; }

        public Type AcType;
        public int Balance { get; private set; }

        public List<Record> Statement = new List<Record>();

        public Account(int type)
        {
            Balance = 0;
            AccountNum = UniqueID.GenerateUniqueID();
            AcType = (Type)type;

            Console.WriteLine($"New {AcType} Account of Ac. Number: {AccountNum} has been Created.");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balacnce Of AcNo: {AccountNum} is {Balance} Rs");
        }

        public int Credit(int Amt)
        {
            if (!CheckCapablity()) { return 0; }

            int temp = Balance;
            Balance += Amt;
            Statement.Add(new Record(temp, Balance, Amt, 0));

            ShowBalance();
            return Balance;
        }

        public int Debit(int Amt)
        {
            int temp = Balance;
            int maxdebitpertrans=50000;
            int ELegableForTax = 30000;
            int Tax = 30;

            if(!CheckCapablity()) { return 0; }
            if (!CheckCap(Amt)) { return 0; }


            if (Amt >maxdebitpertrans)
            {
                Console.WriteLine($"You can not Withdraw more than {maxdebitpertrans} in a single transaction.");
                return 0;
            }
            else if (Amt > ELegableForTax)
            {
                Console.WriteLine($"Amount is Greater Than {ELegableForTax}. So {Tax}Rs Service-Charge will be deducted.");
                Amt += Tax;
            }

            try
            {
                if (Amt > Balance)
                {
                    throw new NotSufficientBalance();
                }
                Balance -= Amt;
                Statement.Add(new Record(temp, Balance, Amt, 1));
            }
            catch (NotSufficientBalance e)
            {
                Console.WriteLine("Not Sufficient Balance. Debit Transaction Failed");
            }

            ShowBalance();
            return Balance;

        }

        public void ShowStatements()
        {
            foreach(Record r in Statement)
            {
                Console.WriteLine(r);
            }
        }

        public bool CheckCapablity()
        {
            //C-1
            int maxtransperhour = 4;


            if (Statement.Count >= maxtransperhour)
            {
                TimeSpan One = new TimeSpan(0, 1, 0, 0);
                TimeSpan Check = DateTime.Now - Statement[Statement.Count - maxtransperhour].d;

                if (One > Check)
                {
                    Console.WriteLine($"Can Not Perform More Than {maxtransperhour} Transactions in an Hour");
                    return false;
                }
            }
            return true;
        }

        public bool CheckCap(int amt)
        {
            //C-2
            int LastHour = amt;
            int maxdebitperhour = 200000;

            for (int i = Statement.Count - 1; i >= 0; i--)
            {
                TimeSpan One = new TimeSpan(0, 1, 0, 0);
                TimeSpan Check = DateTime.Now - Statement[i].d;

                if (One <= Check)
                {
                    break;
                }

                if (Statement[i].Tras == "Debit")
                {
                    LastHour += Statement[i].Amt;
                }
                if (LastHour > maxdebitperhour)
                {
                    Console.WriteLine($"You have reached Maximum Withdrawal limit per hour ({maxdebitperhour}). Transaction can't be performed.");
                    return false;
                }
            }
            return true;
        }




    }

}
