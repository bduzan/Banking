using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {

            Bank.CreateAccount1();
            Bank.CreateAccount2();

            foreach (KeyValuePair<long, IBankAccount> account in Bank.Accounts)
            {
                Console.WriteLine(account.Value);
                Console.WriteLine();

            }

            Bank.CloseAccount(101);
            Console.WriteLine();
            Bank.GetAccount(102);

            Random randomTrans = new Random();
            int range;
            Queue<string> transactionQueue = new Queue<string>();

            for (int counter = 1; counter <= 3; counter++)
            {
                range = randomTrans.Next(50, 101);
                BankTransaction randomDep = new BankTransaction((decimal)range, DateTime.Now);
                BankAccount deposit = new BankAccount();
                Bank.Accounts[102].Deposit((decimal)range, transactionQueue);
                Console.WriteLine();
            }
            Bank.GetAccount(102);
            Console.WriteLine();

            for (int counter = 1; counter <= 3; counter++)
            {
                range = randomTrans.Next(25, 51);
                BankTransaction randomWith = new BankTransaction((decimal)range, DateTime.Now);
                BankAccount withdraw = new BankAccount();
                Bank.Accounts[102].Withdraw((decimal)range, transactionQueue);
                Console.WriteLine();
            }
            Bank.GetAccount(102);
            Console.WriteLine();




            Console.ReadLine();

        }
    }
}
