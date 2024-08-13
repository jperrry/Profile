using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banking
{
    internal class Bank
    {
        private List<Account> accounts = new List<Account>();
        private List<Transaction> _transaction = new List<Transaction>();

        public Bank()
        {
            List<Transaction> transaction = new List<Transaction>();
            List<Account> _accounts = new List<Account>();
        }

        public List<Transaction> GetTransaction()
        {
            return _transaction;
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account GetAccount(String name)
        {
            foreach (Account account in accounts)
            {
                if (account.getName() == name)
                {
                    return account;
                }
            }

            return null;
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            try
            {
                _transaction.Add(transaction);
                transaction.Execute();
            }
            catch (Exception)
            {

                Console.WriteLine("Error");
            }
           
        }

        public void RollBackTransaction(Transaction transaction)
        {
            try
            {
                transaction.RollBack();
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Transaction cannot be reversed");

            }
        }

        public void PrintTransactionHistory()
        {

            Console.WriteLine("Transaction History: ");
            Console.WriteLine();

            for (int i = 0; i < _transaction.Count; i++)
            {
                Console.Write(i + 1 + ": ");
                _transaction[i].Print();
                Console.WriteLine();
            }
        }

    }
}
