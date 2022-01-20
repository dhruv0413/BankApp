using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class GetValidAmt
    {
        public static int GetAmt()
        {
            int amt;
            string input = Console.ReadLine();
            try
            {
                amt = int.Parse(input);

                if (amt <= 0)
                {
                    throw new FormatException();
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Not Valid Amount");
                return 0;
            }
            
            if(amt%100!=0)
            {
                Console.WriteLine("Ammount must be in multiple of 100 only.");
                return 0;
            }

            return amt;
        }
    }
}
