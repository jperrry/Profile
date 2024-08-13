using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banking
{
    public class WithdrawTransaction : Transaction
    {
        private Account _account;
        private bool _executed;
        private bool _reversed;

        public override bool Success {get {  return _success; } }

        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
            this._amount = amount;   
        }

        public override void Print()
        {
            if (!_success)
            {
                Console.WriteLine("Transaction executed at " + DateStamp + ". Amount: " + _amount.ToString("C") + "\nSuccess: " + Success + "\nExecuted: " + Executed + "\nReversed: " + Reversed);
                Console.WriteLine("Your transaction was unsuccessful");
            }
            else
            {
                Console.WriteLine("Transaction executed at " + DateStamp + ". Amount: " + _amount.ToString("C") + "\nSuccess: " + Success + "\nExecuted: " + Executed + "\nReversed: " + Reversed);
                //Console.WriteLine(_account.getName() + " is withdrawing " + _amount.ToString("C"));
                Console.WriteLine("Your transaction is successful.");
                //_account.Print();
            }           
        }

        public override void Execute()
        {
            base.Execute();

            _executed = true;
            _success = _account.Withdrawal(_amount); ;
            
        }

        public override void RollBack()
        {
            if (!_success)
            {
                Console.WriteLine("Previous transaction was unsuccessful and cannot be reversed.");
            }
            else if (Reversed)
            {
                Console.WriteLine("Transaction has already been reversed.");
            }
            else
            {
                base.RollBack();
                _account.Deposit(_amount);
                Console.WriteLine("Reversing transaction... \nDepositing " + _amount.ToString("C") + " back into " + _account.getName() + " account.");
            }

        }

    }
    
}

