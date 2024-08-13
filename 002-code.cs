using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class TransferTransaction : Transaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _reversed;

        public override bool Success {get { return _success; } }

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {
            _withdraw = new WithdrawTransaction(fromAccount, amount);
            _deposit = new DepositTransaction(toAccount, amount);
            _amount = amount;
            _fromAccount = fromAccount;
            _toAccount = toAccount;
        }

        public override void Print()
        {
            if (_success)
            {
                //Console.WriteLine("Transferred " + _amount.ToString("C") + " from " + _fromAccount.getName() + " to " + _toAccount.getName());
                Console.WriteLine("Transaction executed at " + DateStamp + "\nTransferred " + _amount.ToString("C") + " from " + _fromAccount.getName() + " to " + _toAccount.getName() + "\nSuccess: " + Success + "\nExecuted: " + Executed + "\nReversed: " + Reversed);
            }
            else
            {
                Console.WriteLine("Transaction executed at " + DateStamp + ". Amount: " + _amount.ToString("C") + "\nSuccess: " + Success + "\nExecuted: " + Executed + "\nReversed: " + Reversed);
                Console.WriteLine("Transaction could not be completed.");
            }           
        }

        public override void Execute()
        {
            base.Execute();

            if (_executed)
            {
                Console.WriteLine("This action has already been executed");
            }
            else if (_amount > _fromAccount.getBalance())
            {
                Console.WriteLine("The credit account has insufficient funds.");
            }
            else
            {
                _executed = true;
                _withdraw.Execute();
                _deposit.Execute();
            }
        }

        public override void RollBack()
        {
            if (!_executed)
            {
                Console.WriteLine("No transfer has been executed.");
            }
            else if (_reversed)
            {
                Console.WriteLine("The transfer has already been reversed");
            }
            else if (!_success)
            {
                Console.WriteLine("The previous transfer was unsuccessful");
            }
            else
            {
                _deposit.RollBack();
                _withdraw.RollBack();
                _reversed = true;
            }
        }
    }
}


