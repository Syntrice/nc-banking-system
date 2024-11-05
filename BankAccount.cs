using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcBankingSystem
{
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        public int Balance { get; set; }
        public string OwnerName { get; set; }
        public int AgreedOverdraft { get; set; }

        public void Deposit(int amount)
        {

        }

        public void Withdraw(int amount) 
        { 
        
        }

        public BankAccount(int accountNumber, string o)
        {

        }

    }
}
