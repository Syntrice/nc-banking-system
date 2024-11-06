namespace NcBankingSystem
{
    internal class BankAccount
    {
        public int AccountNumber { get; private set; }
        public int Balance { get; private set; }
        public string OwnerName { get; private set; }

        public int ArrangedOverdraft { get; private set; }


        public BankAccount(int accountNumber, string ownerName, int arrangedOverdraft)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = 0;
            ArrangedOverdraft = arrangedOverdraft;
        }

        /// <summary>
        /// Deposit a specified value into the account
        /// </summary>
        /// <param name="amount">The amount to deposit</param>
        public void Deposit(int amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Withdraw a specified amount from the account. 
        /// This is only carried out should the withdrawal not result in the 
        /// account balance falling below the arranged overdraft
        /// </summary>
        /// <param name="amount">The amount to withdraw</param>
        /// <returns>A boolean value indicating whether the amount was 
        /// succesfully withdrawn</returns>
        public bool Withdraw(int amount)
        {

            int newBalance = Balance - amount;
            if (newBalance >= ArrangedOverdraft * -1)
            {
                Balance = newBalance;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Owner Name: {OwnerName}, Balance: {Balance}, Arranged Overdraft: {ArrangedOverdraft}";
        }
    }
}
