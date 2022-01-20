using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Record
    {
        public int StartBalance,EndBalace;
        public string Tras;
        public int Amt;
        public DateTime d;

        public Record(int start,int end,int amt,int type)
        {
            d = DateTime.Now;
            StartBalance = start;
            EndBalace = end;
            Amt = amt;

            if (type == 0)
            {
                Tras = "Credit";
            }
            else if(type==1)
            {
                Tras = "Debit";
             }
        }

        public override string ToString()
        {
            return d+"\t"+StartBalance+"\t\t"+Tras+"\t\t"+Amt+"\t\t"+EndBalace;
        }

    }
}
