using System;


namespace BankApp
{
    public class FindAcc
    {
        public static Account FindAcById()
        {
            int aid;

            Console.Write("Enter AccountId (Press 0 to go back) : ");
            try
            {
                string input = Console.ReadLine();
                if (input.Length > 10)
                {
                    throw new FormatException();
                }
                aid = int.Parse(input);

                if (aid == 0) { return null; }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Not Valid AccountId");
                return null;
            }

            if (AllData.AllAccounts.TryGetValue(aid, out Account account))
            {
                return account;
            }
            else
            {
                Console.WriteLine("Account Does not exist");
                return null;
            }


        }
    }
}
