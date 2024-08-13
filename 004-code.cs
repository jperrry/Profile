namespace Banking
{
    public enum MenuOption
    {
        Add  = 1,
        Withdraw = 2,
        Deposit = 3,
        Transfer = 4,
        Print = 5,
        TransactionHistory = 6,
        Quit = 7,
    }

    class BankSystem
    {
        public static MenuOption ReadUserOption()
        {
            
            int choice;

            do
            {
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Print");
                Console.WriteLine("6. Transaction History");
                Console.WriteLine("7. Quit");
                Console.Write("Please select an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option (1-7).");
                }
            }
            while (choice < 1 || choice > 7);
            return (MenuOption)choice;

        }

        private static Account FindAccount (Bank bank)
        {
            Console.WriteLine("Enter account name: ");
            string name = Console.ReadLine() ?? "";

            return bank.GetAccount(name);

        }

        public static void DoDeposit(Bank bank)
        {
            Account account = FindAccount(bank);

            if(account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            Console.Write("Enter deposit amount: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                return;
            }

            DepositTransaction depositTransaction = new DepositTransaction(account, amount);

            bank.ExecuteTransaction(depositTransaction);
            depositTransaction.Print();
        }

        public static void DoWithdraw(Bank bank)
        {
            Account account = FindAccount(bank);

            if (account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            Console.Write("Enter withdrawal amount: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                return; 
            }

            WithdrawTransaction withdrawTransaction = new WithdrawTransaction(account, amount);
            bank.ExecuteTransaction(withdrawTransaction);
            withdrawTransaction.Print();
        }

        public static void DoPrint(Bank bank)
        {
            Account account = FindAccount(bank);

            if (account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            account.Print(); 
        }

        public static void DoTransfer(Bank bank)
        {
            Console.WriteLine("*** Debit Account ***");
            Account fromAccount = FindAccount(bank);

            Console.WriteLine("*** Credit Account ***");
            Account toAccount = FindAccount(bank);

            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            Console.Write("Enter transfer amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                return;
            }

            TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, amount);

            bank.ExecuteTransaction(transferTransaction);
            transferTransaction.Print();
        }

        public static void DoRollBack(Bank bank)
        {
           
            Console.WriteLine("Which transaction would you like to rollback?");

            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            List<Transaction> transactions = bank.GetTransaction();

            if (index >= 1 && index <= transactions.Count)
            {
                Transaction transaction = transactions[index - 1];
                bank.RollBackTransaction(transaction);
            }
            else
            {
                Console.WriteLine($"Invalid index selected. Please enter an index between 1 and {transactions.Count}.");
            }
        }


        static void Main(string[] args)
        {
            Bank bank = new Bank();
            string confirm;
            bool loop = true;

            while (loop == true)
            {
                Console.WriteLine("Welcome to the bank!");
                MenuOption userOption = ReadUserOption();
                Console.WriteLine("You selected " + userOption + ". \nIs this correct? Enter Y to continue. Enter N to revisit menu options.");
                confirm = Console.ReadLine() ?? "";
                
                if (confirm == "Y")
                {
                    switch (userOption) 
                    {
                        case MenuOption.Add:
                            {
                                Console.WriteLine("Enter the name of account holder:");
                                string name = Console.ReadLine() ?? "";

                                Console.WriteLine("Enter the starting balance:");

                                decimal balance;

                                if (!decimal.TryParse(Console.ReadLine(), out balance))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid decimal number for the balance.");
                                    break;
                                }
                                else if(balance < 0)
                                {
                                    Console.WriteLine("Cannot create an account with a negative balance.");
                                    break;
                                }

                                Account newAccount = new Account(name, balance);

                                bank.AddAccount(newAccount);

                                Console.WriteLine("Account added: " + name + "\nStarting balance: " + balance.ToString("C"));
                                break;
                            }
                        case MenuOption.Withdraw:
                            {
                                DoWithdraw(bank);
                                break;
                            }

                        case MenuOption.Deposit:
                            {
                                DoDeposit(bank);
                                break;
                            }
                        case MenuOption.Transfer:
                            {
                                DoTransfer(bank);
                                break;
                            }
                        case MenuOption.Print:
                            {
                                DoPrint(bank);
                                break;
                            }
                        case MenuOption.TransactionHistory:
                            {
                                bank.PrintTransactionHistory();
                                DoRollBack(bank);
                                break;
                            }
                        case MenuOption.Quit:
                            {
                                Console.WriteLine("Thank you for using the bank!");
                                loop = false; 
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Option. Please Try Again");
                                break;
                            }
                    }
                }

                else if (confirm == "N")
                {
                    Console.WriteLine("You are being taken back to the menu.");
                }
                else 
                {
                    Console.WriteLine("Error. Please select a valid option");
                }
                

            }

        }
    }
}