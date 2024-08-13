using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class DepositTransaction : Transaction
    {
        private Account _account;
        private bool _executed;
        private bool _reversed;

        public override bool Success { get {  return _success; } }
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public override void Print()
        {
            if (_success)
            {
                Console.WriteLine("Transaction executed at " + DateStamp + ". Amount: " + _amount.ToString("C") + "\nSuccess: " + Success + "\nExecuted: " + Executed + "\nReversed: " + Reversed);
                //Console.WriteLine(_account.getName() + " is depositing " + _amount.ToString("C"));
                Console.WriteLine("Your transaction is successful");
                //_account.Print();
            }
            else if (_reversed)
            {
                Console.WriteLine("This transaction has been reversed! \nUpdated account balance: " + _account.getBalance());
            }
            else
            {
                Console.WriteLine("Transaction executed at " + DateStamp + ". Amount: " + _amount.ToString("C") + "\nSuccess: " + Success + "\nExecuted: " + Executed + "\nReversed: " + Reversed);
                Console.WriteLine("Your transaction was unsuccessful");
            }
        }
        public override void Execute()
        {
            base.Execute();

            _executed = true;
            _success = _account.Deposit(_amount);
        }
        public override void RollBack()
        {
            if (_reversed)
            {
                throw new Exception("The deposit has already been reversed");
            }
            else if (!_success)
            {
                throw new Exception("The previous deposit was unsuccessful");
            }
            else if (_amount > _account.getBalance())
            {
                throw new Exception("Money cannot be withdrawn. Insufficient funds.");
            }
            else
            {
                _reversed = _account.Withdrawal(_amount);
                Console.WriteLine("Reversing transaction... \nWithdrawing " + _amount.ToString("C") + " from " + _account.getName() + " account.");
            }

        }


    }
}


