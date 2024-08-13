using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public abstract class Transaction
    {
        protected decimal _amount;
        protected bool _success;
        private bool _executed;
        private bool _reversed;
        private DateTime _dateStamp;


        public Transaction(decimal amount)
        {
            this._amount = amount;
            _dateStamp = DateTime.Now;
        }

        public abstract void Print();

        public virtual void Execute()
        {
            if (!Executed)
            {
                _executed = true;
                //Console.WriteLine("Transaction executed at " + DateStamp + " for amount: " +  _amount.ToString("C"));
                _success = true;              
            }
            else
            {
                Console.WriteLine("Transaction already executed.");
            }
        }

        public virtual void RollBack()
        {
            if (Reversed)
            {
                Console.WriteLine("Transaction has already been reversed.");
            }
            else
            {
                Console.WriteLine("Transaction executed on " + DateStamp + " for amount: " + _amount.ToString("C"));
                _reversed = true;
                _success = true;
            }

            /*if (Executed && !Reversed)
            {
                Console.WriteLine("Transaction executed on " + DateStamp + " for amount: " + _amount.ToString("C"));
                _reversed = true;
                _success = true;
            }
            else
            {
                Console.WriteLine("Transaction not executed or already reversed.");
            }*/
        }
        
        
        public bool Reversed { get { return _reversed; } }

        public abstract bool Success { get; }

        public bool Executed { get { return _executed; } }

        public DateTime DateStamp { get {  return _dateStamp; } }

    }
}
