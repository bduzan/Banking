using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class BankTransaction
    {
        private decimal amount;
        private DateTime when = DateTime.Now;

        public decimal Amount 
        {
            get { return amount; }
        }

        public DateTime When
        {
            get { return when; }
        }

        // Add a non-default constructor to initialize the read-only amount and date properties.
        public BankTransaction(decimal amt, DateTime date)
        {
            amount = amt;
            when = date;
        }

        //Add an enumeration type to reflect that bank accounts are either type Checking or Deposit.
        public enum AccountType { CHECKING, DEPOSIT }
    }
}
