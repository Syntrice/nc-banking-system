using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcBankingSystem
{
    internal class BankingNotificationLog
    {
        private List<String> largeTransactionNotifications;

        public int LargeTransactionThreshhold { get; set; }

        public BankingNotificationLog(int largeTransactionThreshhold = 250)
        { 
            largeTransactionNotifications = new List<string>();
            LargeTransactionThreshhold = largeTransactionThreshhold;
        }

        /// <summary>
        /// Log a large transaction notification.
        /// </summary>
        /// <param name="accountNumber">The account number associated with the transaction</param>
        /// <param name="transaction">The transaction to log</param>
        public void LogLargeTransaction(int accountNumber, BankTransaction transaction)
        {
            string notification = $"A large transaction was recorded for account number {accountNumber}:\n{transaction.ToString()}";
            largeTransactionNotifications.Add(notification);
        }

        /// <summary>
        /// Prints all large transaction notifications stored in this log instance.
        /// </summary>
        public void PrintLargeTransactionNotifications()
        {
            foreach (string notification in largeTransactionNotifications)
            {
                System.Console.WriteLine(notification);
            }
        }
    }
}
