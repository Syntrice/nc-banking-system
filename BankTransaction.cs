namespace NcBankingSystem
{
    internal class BankTransaction
    {
        public int Id { get; }
        public TransactionType Type { get; }
        public TransactionCategory Category { get; }
        public int Amount { get; }
        public string Timestamp { get; }

        public BankTransaction(int id, TransactionType type, TransactionCategory category, int amount, string timestamp)
        {
            Id = id;
            Type = type;
            Category = category;
            Amount = amount;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"Transaction Id: {Id}, Type: {Type}, Amount: {Amount}, Timestamp: {Timestamp}";
        }
    }

    internal enum TransactionType
    {
        Deposit = 0,
        Withdrawal = 1,
    }

    internal enum TransactionCategory
    {
        Misc = 0,
        Groceries = 1,
        Entertainment = 2,
    }
}
