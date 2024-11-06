using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcBankingSystem
{
    internal class BankTransaction
    {
        public int Id { get; }
        public string Type { get; }
        public int Amount { get; }
        public string Timestamp { get; }
             

        public BankTransaction(int id, string type, int amount, string timestamp)
        {
            Id = id;
            Type = type;
            Amount = amount;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"Transaction Id: {Id}, Type: {Type}, Amount: {Amount}, Timestamp: {Timestamp}";
        }
    }
}
