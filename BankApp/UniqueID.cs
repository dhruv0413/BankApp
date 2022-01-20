using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class UniqueID
    {
        public static int GenerateUniqueID()
        {
            int Id = Math.Abs(Guid.NewGuid().GetHashCode());
            while (Id < 1000000000)
            {
                Id *= 10;
            }
            return Id;
        }
    }
}
