using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankApp
{
    class Program
    {
        public enum Type { Saving=1, Current };

        static void Main(string[] args)
        {
            int choice = 1;

            do
            {
                Console.WriteLine();
                Console.Write("Enter 1 to Add New Customer\t\t");
                Console.WriteLine("Enter 2 to Add New Account");
                Console.Write("Enter 3 to Credit\t\t\t");
                Console.WriteLine("Enter 4 to Debit");
                Console.Write("Enter 5 to Check Balance\t\t");
                Console.WriteLine("Enter 6 to Show all accout's balance of Custumer");
                Console.Write("Enter 7 to show Account Statement\t");
                Console.WriteLine("Enter 0 to Exit");
                Console.Write("Enter your Choice: ");
               
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Enter Proper Choice");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        NewCust.AddCust();
                        break;

                    case 2:
                        NewAcc.AddAcc();
                        break;

                    case 3:
                        {
                            Account account = FindAcc.FindAcById();
                            if (account != null)
                            {
                                Console.Write("Enter Ammount for Credit (It Must be in multiples of 100): ");
                                int amt = GetValidAmt.GetAmt();
                                if (amt != 0) { account.Credit(amt); }
                            }
                        }
                        break;

                    case 4:
                        {
                            Account account = FindAcc.FindAcById();
                            if (account != null)
                            {
                                Console.Write("Enter Ammount for Debit (It Must be in multiples of 100): ");
                                int amt = GetValidAmt.GetAmt();
                                if (amt != 0) { account.Debit(amt); }
                            }
                        }
                        break;

                    case 5:
                        {
                            Account account = FindAcc.FindAcById();
                            if (account != null)
                            {
                                account.ShowBalance();
                            }
                        }
                        break;

                    case 6:
                        {
                            Customer customer = FindCust.FindAcById();
                            if (customer!=null)
                            {
                                customer.DisplayAllAccountBalace();
                            }
                        }
                        break;

                    case 7:
                        {
                            Account account = FindAcc.FindAcById();
                            if (account != null)
                            {
                                Console.WriteLine("Date       Time  \tStartBalance\tTransaction\tAmount\t\tEndBalance");
                                account.ShowStatements();
                            }
                        }
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 0);
        }
    



    }
}
