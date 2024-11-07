using System.Security.Cryptography.X509Certificates;

namespace NcBankingSystem
{
    internal class BankingSystem
    {

        private List<BankAccount> accounts;
        private Dictionary<int, List<BankTransaction>> accountTransactionLog;
        private BankingNotificationLog notificationLog;

        public float InterestRate { get; set; }

        public BankingSystem()
        {
            accounts = new List<BankAccount>();
            accountTransactionLog = new Dictionary<int, List<BankTransaction>>();
            notificationLog = new BankingNotificationLog();
            InterestRate = 0.00f; 
        }

        /// <summary>
        /// Create a new bank account with the specified owner name and overdraft. The account will be 
        /// added to this banking system's database of accounts, and given an account number automatically.
        /// </summary>
        /// <param name="ownerName">The name of the account owner</param>
        /// <param name="arrangedOverdraft">The maximum allowed overdraft for withdrawals</param>
        public void CreateAccount(string ownerName, int arrangedOverdraft)
        {
            // use the current length of the accounts list to populate account numbers
            int accountNumber = accounts.Count;
            BankAccount account = new BankAccount(this.accounts.Count, ownerName, arrangedOverdraft);
            accounts.Add(account);
        }

        /// <summary>
        /// Carry out a deposit on the account in the database with the specified account number.
        /// </summary>
        /// <param name="accountNumber">The number of the account to add a deposit to</param>
        /// <param name="amount">The deposit amount</param>
        /// <param name="category">The category of the transaction</param>
        public void PerformDeposit(int accountNumber, int amount, TransactionCategory category = TransactionCategory.Misc)
        {

            accounts[accountNumber].Deposit(amount);
            NewTransaction(accountNumber, TransactionType.Deposit, category, amount);

        }

        /// <summary>
        /// Carry out a withdrawal on the account with the specified account number
        /// </summary>
        /// <param name="accountNumber">The number of the account to withdraw from</param>
        /// <param name="amount">The amount to withdraw</param>
        /// <param name="category">The category of the transaction</param>
        public void PerformWithdrawal(int accountNumber, int amount, TransactionCategory category = TransactionCategory.Misc)
        {
            bool success = accounts[accountNumber].Withdraw(amount);

            if (success)
            {
                NewTransaction(accountNumber, TransactionType.Deposit, category, amount);
            }
        }

        /// <summary>
        /// Adds interest to all accounts according to the currently set
        /// Interest rate.
        /// </summary>
        public void AddInterestToAccounts()
        {
            foreach (BankAccount account in accounts)
            {
                int interest = (int)Math.Round(account.Balance * InterestRate, 0);
                PerformDeposit(account.AccountNumber, interest);
            }
        }

        /// <summary>
        /// Print out the information of all accounts stored in this BankingSystem
        /// </summary>
        public void ListAccounts()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine(accounts[i].ToString());
            }
        }

        /// <summary>
        /// For the specified account number, print out all transactions accociated with that
        /// account.
        /// </summary>
        /// <param name="accountNumber">The number of the account to read transactions from</param>
        public void ListTransactions(int accountNumber)
        {
            List<BankTransaction> transaction;
            if (accountTransactionLog.TryGetValue(accountNumber, out transaction))
            {
                for (int i = 0; i < transaction.Count; i++)
                {
                    Console.WriteLine(transaction[i]);
                }
            }
        }

        /// <summary>
        /// Print all large transaction notifications
        /// </summary>
        public void ListLargeTransactions()
        {
            notificationLog.PrintLargeTransactionNotifications();
        }

        private void NewTransaction(int accountNumber, TransactionType type, TransactionCategory category, int amount)
        {
            // create a new transaction list if no transactions have been logged for this account
            if (!accountTransactionLog.ContainsKey(accountNumber))
            {
                accountTransactionLog.Add(accountNumber, new List<BankTransaction>());
            }

            // use the current length of the transaction list to populate account numbers
            int transactionId = accountTransactionLog[accountNumber].Count;

            BankTransaction transaction = new BankTransaction(transactionId, type, category, amount, DateTime.Now.ToString());
            accountTransactionLog[accountNumber].Add(transaction);

            if (amount >= notificationLog.LargeTransactionThreshhold)
            {
                notificationLog.LogLargeTransaction(accountNumber, transaction);
            }
        }
    }
}
