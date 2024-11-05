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
        public string Name { get; private set; }

        public int ArrangedOverdraft { get; private set; }

        public BankAccount(int accountNumber, string name, int arrangedOverdraft)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = 0;
            ArrangedOverdraft = arrangedOverdraft;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            int newBalance = Balance - amount;
            if (newBalance >= ArrangedOverdraft * -1)
            {
                Balance = newBalance;
            }
        }
    }
}
