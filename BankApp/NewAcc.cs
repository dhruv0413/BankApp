using System;

namespace BankApp
{
    public class NewAcc
    {
        public static void AddAcc()
        {
            int cid;

            Console.WriteLine("For Which Customer? (If Don't have CustomerID then press 0 to go back): ");
            Console.Write("Enter CustomerId: ");

            try
            {
                string input = Console.ReadLine();
                if (input.Length>10)
                {
                    throw new FormatException();
                }
                cid = int.Parse(input);
                
                if (cid == 0) { return; }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Not Valid CustomerId");
                return;
            }


            if (AllData.AllCustomers.TryGetValue(cid, out Customer customer))
            {
                int type;

                bool flag = true;
                while (flag)
                {
                    Console.Write("Enter 0 for Saving Account Or 1 for Current Account. Enter 2 to Go Back: ");
                    try
                    {
                        type = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Enter Proper Choice");
                        continue;
                    }
                    switch (type)
                    {
                        case 0:
                        case 1:
                            Account account = new Account(type);
                            customer.AddAccount(account);
                            AllData.AddAccount(account);
                            flag = false;
                            break;

                        case 2:
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Enter Proper Choice ");
                            break;
                    }
                }
            }


            else
            {
                Console.WriteLine("Customer Does Not Exists");
                return;
            }

        }

    }
}