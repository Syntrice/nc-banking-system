using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcBankingSystem
{
    internal class BankingSystem
    {
        private int idCounter = 0;

        private List<BankAccount> accounts = new List<BankAccount>();

        public void CreateAccount(string ownerName, int agreedOverdraft)
        {
            BankAccount bankAccount = new BankAccount();
        }

        public string ListAccounts()
        {

        }

        public void PerformDeposit(int accountNumber, int amount)
        {

        }

        public void PerformWithdraw(int accountNumber, int amount)
        {

        }


    }
}
