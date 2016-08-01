using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class Bank
    {
        //Add a static generic collection property of type Dictionary<T1, T2> to store new instances of all new bank accounts created. 
        //Use the account number as the key and the account instance as the value. (account number is calculated in a BankAccount method)
        private static Dictionary<long, IBankAccount> _accounts;

        public static Dictionary<long, IBankAccount> Accounts
        {
            get {
                if (_accounts == null)
                    _accounts = new Dictionary<long, IBankAccount>();
                return _accounts; 
            }
        }

        //static BankAccount acct1 = new BankAccount(BankTransaction.AccountType.CHECKING, 2000.00M);
        //static BankAccount acct2 = new BankAccount(BankTransaction.AccountType.DEPOSIT);
        //static BankAccount acct3 = new BankAccount(4000.00M);
        //static BankAccount acct4 = new BankAccount(BankTransaction.AccountType.CHECKING, 3000.00M);

        //Add 4 static methods to create new bank accounts using the 4 bank account constructors 
        //returning the value of the new account number in each created method.
        public static void CreateAccount1()
        {
            IBankAccount acct = new BankAccount(BankTransaction.AccountType.CHECKING, 2000.00M);
            var x = acct.AccountNumber;
            Accounts.Add(x, acct);
            //var x = acct1.NextNumber();
            //var newaccount = new Dictionary(x, acct1);
            //Accounts.Add(x, acct1);
            //return acct1.NextNumber();
            //accounts.Add( acct1.NextNumber()  , acct1);
            //return acct1.ToString();
        }

        public static void CreateAccount2()
        {
            IBankAccount acct = new BankAccount(BankTransaction.AccountType.DEPOSIT);
            var x2 = acct.AccountNumber;
            Accounts.Add(x2, acct);
        }

        public static void CreateAccount3()
        {
            IBankAccount acct = new BankAccount(4000.00M);
            var x3 = acct.AccountNumber;
            Accounts.Add(x3, acct);
        }

        public static void CreateAccount4()
        {
            IBankAccount acct = new BankAccount(BankTransaction.AccountType.CHECKING, 3000.00M);
            var x4 = acct.AccountNumber;
            Accounts.Add(x4, acct);
        }

        public static string CloseAccount(long acctNumber)
        {
           
            Accounts.Remove(acctNumber);
            Console.WriteLine("Account {0} has been closed.\n", acctNumber);
            return "Account " +acctNumber+ " has been closed.";

        }

        public static decimal GetAccount(long acctNumber)
        {
            var x = Accounts[acctNumber];
            Console.WriteLine("Here is the information for account {0}: \n{1}", acctNumber, x.ToString());
            return x.AccountBalance();
        }
    }
}
