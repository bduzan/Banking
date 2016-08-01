using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    sealed class BankAccount : IBankAccount
    {
        private decimal accountBalance;
        private string accountHolder = "";
        private static long nextAccountNumber = 100;
        private long accountNumber = 100;
        private BankTransaction.AccountType accountType;

        //private long nextAccountNumber = 101;
        private Queue<string> transactionQueue;

        string IBankAccount.AccountHolder
        {
            get { return accountHolder; }
            set { value = accountHolder; }
        }

        long IBankAccount.AccountNumber
        {
            get { return accountNumber; }
        }

        BankTransaction.AccountType IBankAccount.BankAccountType
        {
            get { return accountType; }
        }

        Queue<string> IBankAccount.TransactionQueue
        {
            get { return transactionQueue; }
        }

        public BankAccount(decimal balance = 0, BankTransaction.AccountType type = BankTransaction.AccountType.CHECKING) //Default constructor
        {
            accountNumber = NextNumber();
            accountType = type;
            accountBalance = balance;
        }

        public BankAccount(BankTransaction.AccountType type)// 1st non-default constructor
        {
            accountNumber = NextNumber();
            accountType = type;
            accountBalance = 0;
        }

        public BankAccount(decimal balance)// 2nd non-default constructor
        {
            accountNumber = NextNumber();
            accountType = 0;
            accountBalance = balance;
        }

        public BankAccount(BankTransaction.AccountType type, decimal balance)// 3rd non-default constructor
        {
            accountNumber = NextNumber();
            accountType = type;
            accountBalance = balance;
        }

        public string Withdraw(decimal amount, Queue<string> transactionQueue) //Withdraw
        {
            if (amount <= accountBalance)
            {
                accountBalance -= amount;
                transactionQueue.Enqueue(ToString());
                Console.WriteLine("The withdraw of {0:C} was a success ({1}).", amount, DateTime.Now);
                Console.WriteLine("The new balance is {0:C}.", accountBalance);
                Console.WriteLine("Transactions in the queue: {0}", transactionQueue.Count);
                return "The withdraw was a success.";
            }
            else
            {
                Console.WriteLine("Insufficient funds to withdraw {0:C}. Try a different amount.", amount);
                return "Insufficient funds. Try a different amount";
            }
        }

        public decimal Deposit(decimal amount, Queue<string> transactionQueue) //Deposit
        {
            accountBalance += amount;

            transactionQueue.Enqueue(ToString());
            Console.WriteLine("The deposit of {0:C} was a success ({1}).", amount, DateTime.Now);
            Console.WriteLine("The new balance is {0:C}.", accountBalance);
            Console.WriteLine("Transactions in the queue: {0}\n", transactionQueue.Count);

            return accountBalance;
        }

        public Decimal AccountBalance()
        {
            return accountBalance;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString() //ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3}\n{4}: {5}\n{6}: {7}\n{8}: {9:C}",
                "Hash Code: ", GetHashCode(), "Account Number: ", accountNumber, "Account Holder: ", accountHolder, "Account Type: ", accountType,
                "Account Balance: ", accountBalance);
        }

        public static long NextNumber()
        {
            return ++nextAccountNumber;
        }

        public static bool operator ==(BankAccount acct1, BankAccount acct2)
        {
            bool equal = false;
            if (acct1.accountNumber == acct2.accountNumber && acct1.accountType == acct2.accountType)
            {
                equal = true;
            }

            return equal;
        }

        public static bool operator !=(BankAccount acct1, BankAccount acct2)
        {
            bool equal = false;
            if (acct1.accountNumber != acct2.accountNumber || acct1.accountType != acct2.accountType)
            {
                equal = true;
            }

            return equal;
        }

        //Implement the IDisposable interface to provide functionality to clean up unmanaged resources that may be used by a bank account instance.
        private bool disposed = false;

        public void Dispose()
        {
            disposed = true;
        }
    }
}
