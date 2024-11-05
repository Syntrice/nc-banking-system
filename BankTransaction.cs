using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcBankingSystem
{
    internal class BankTransaction
    {

        private int transactionId;
        private string type;
        private int amount;
        private string timestamp;

        public int TransactionId { get { return transactionId; } }
        public string Type { get { return type; } } 
            
        public int Amount { get { return amount; } }

        public string Timestamp { get { return timestamp; } }

    }
}
