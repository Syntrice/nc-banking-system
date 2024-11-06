namespace NcBankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BankingSystem bankingSystem = new BankingSystem();
            bankingSystem.CreateAccount("John", 1000);
            bankingSystem.CreateAccount("Kate", 1000);
            bankingSystem.CreateAccount("Ben", 1000);
            bankingSystem.CreateAccount("Jack", 1000);
            bankingSystem.PerformDeposit(0, 1000);
            bankingSystem.PerformDeposit(0, 100);
            bankingSystem.PerformWithdrawel(0, 1000);
            bankingSystem.PerformDeposit(0, 250);
            bankingSystem.ListAccounts();
            bankingSystem.ListTransactions(0);
        }
    }
}
