using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Deposit(int amount)
        {
            Balance += amount;
        }

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
