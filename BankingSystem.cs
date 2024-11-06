namespace NcBankingSystem
{
    internal class BankingSystem
    {

        private List<BankAccount> accounts;
        private Dictionary<int, List<BankTransaction>> accountTransactionLog;

        public BankingSystem()
        {
            accounts = new List<BankAccount>();
            accountTransactionLog = new Dictionary<int, List<BankTransaction>>();
        }

        public void CreateAccount(string name, int arrangedOverdraft)
        {
            // use the current length of the accounts list to populate account numbers
            int accountNumber = accounts.Count; 
            BankAccount account = new BankAccount(this.accounts.Count, name, arrangedOverdraft);
            accounts.Add(account);
        }

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

        public void ListAccounts()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine(accounts[i].ToString());
            }
        }

        public void PerformDeposit(int accountNumber, int amount)
        {
            accounts[accountNumber].Deposit(amount);
            NewTransaction(accountNumber, "Deposit", amount);

            // use the current length of the transaction list to populate account numbers


        }

        public void PerformWithdrawel(int accountNumber, int amount)
        {
            bool success = accounts[accountNumber].Withdraw(amount);

            if (success)
            {
                NewTransaction(accountNumber, "Withdrawal", amount);
            }
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
        }
    }
}
