using System;

namespace BankApp
{
    public class NotSufficientBalance: Exception
    {
        public NotSufficientBalance() : base() { }
        public NotSufficientBalance(string message) : base(message) { }
        public NotSufficientBalance(string message, Exception inner) : base(message, inner) { }
    }

}
