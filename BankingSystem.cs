using System.Security.Cryptography.X509Certificates;

namespace NcBankingSystem
{
    internal class BankingSystem
    {

        private List<BankAccount> accounts;
        private Dictionary<int, List<BankTransaction>> accountTransactionLog;
        private BankingNotificationLog notificationLog;

        public BankingSystem()
        {
            accounts = new List<BankAccount>();
            accountTransactionLog = new Dictionary<int, List<BankTransaction>>();
            notificationLog = new BankingNotificationLog();
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
        public void PerformDeposit(int accountNumber, int amount)
        {

            accounts[accountNumber].Deposit(amount);
            NewTransaction(accountNumber, "Deposit", amount);

        }

        /// <summary>
        /// Carry out a withdrawal on the account with the specified account number
        /// </summary>
        /// <param name="accountNumber">The number of the account to withdraw from</param>
        /// <param name="amount">The amount to withdraw</param>
        public void PerformWithdrawal(int accountNumber, int amount)
        {
            bool success = accounts[accountNumber].Withdraw(amount);

            if (success)
            {
                NewTransaction(accountNumber, "Withdrawal", amount);
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

        private void NewTransaction(int accountNumber, string type, int amount)
        {
            // create a new transaction list if no transactions have been logged for this account
            if (!accountTransactionLog.ContainsKey(accountNumber))
            {
                accountTransactionLog.Add(accountNumber, new List<BankTransaction>());
            }

            // use the current length of the transaction list to populate account numbers
            int transactionId = accountTransactionLog[accountNumber].Count;

            BankTransaction transaction = new BankTransaction(transactionId, type, amount, DateTime.Now.ToString());
            accountTransactionLog[accountNumber].Add(transaction);

            if (amount >= notificationLog.LargeTransactionThreshhold)
            {
                notificationLog.LogLargeTransaction(accountNumber, transaction);
            }
        }
    }
}
