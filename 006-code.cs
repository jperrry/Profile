using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class Account
    {
        private decimal _balance;
        private string _name;

        public Account(string name, decimal balance)
        {
            this._name = name;
            this._balance = balance;
        }

        //accessor methods
        public string getName()
        {
            return this._name;
        }

        public decimal getBalance()
        {
            return this._balance;
        }

        //mutator methods
        public void setName(string _name)
        {
            this._name = _name;
        }

        public void setBalance(decimal _balance)
        {
            this._balance = _balance;
        }

        //methods
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid input. Cannot deposit " + amount.ToString("C") + " into your account.");
                return false;
            }
            else
            {
                this._balance += amount;
                return true;
            }
        }

        public bool Withdrawal(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid input. Cannot withdraw " + amount.ToString("C") + " from your account.");
                return false;
            }
            else if (amount <= _balance)
            {
                _balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }

        }

        public void Print()
        {
            Console.WriteLine("Account name: " + getName());
            Console.WriteLine("Account balance: " + getBalance().ToString("C"));
        }

    }


}
