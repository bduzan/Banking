using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    interface IBankAccount
    {
        //A read-only bank account number
        long AccountNumber{ get;  }

        //Read/Write property to track account holder information,
        string AccountHolder { get; set; }

        //A read-only bank account type. The account type is either Checking or Deposit.
        BankTransaction.AccountType BankAccountType{ get;  }

        //A generic read-only collection property of type Queue to hold all bank account transactions where is the custom bank transaction type.
        Queue<string> TransactionQueue { get;  }

        //The withdraw method should return a value indicating success or failure of the withdraw attempt. 
        string Withdraw(decimal amount, Queue<string> transactionQueue);

        //The deposit method should return the current balance in the account.
        decimal Deposit(decimal amount, Queue<string> transactionQueue);

        //A method to return the account balance.
        Decimal AccountBalance();
    }
}
