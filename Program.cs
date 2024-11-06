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
            Console.WriteLine("Accounts created:");
            bankingSystem.ListAccounts();

            bankingSystem.PerformDeposit(0, 1000);

            Console.WriteLine();
            Console.WriteLine("Now performing transactions on Ben's account");
            bankingSystem.PerformDeposit(2, 500);
            bankingSystem.ListTransactions(2);
            Console.WriteLine();
            bankingSystem.PerformWithdrawal(2, 1500);
            bankingSystem.ListTransactions(2);
            Console.WriteLine();
            bankingSystem.PerformWithdrawal(2, 900);
            bankingSystem.ListTransactions(2);
            Console.WriteLine();
            bankingSystem.PerformWithdrawal(2, 100);
            bankingSystem.ListTransactions(2);

            Console.WriteLine();
            Console.WriteLine("Current accounts status:");
            bankingSystem.ListAccounts();

            Console.WriteLine();
            Console.WriteLine("Now performing transactions on Ben's account");
            bankingSystem.PerformDeposit(2, 1);
            bankingSystem.ListTransactions(2);
            Console.WriteLine();
            bankingSystem.PerformWithdrawal(2, 2);
            bankingSystem.ListTransactions(2);

            Console.WriteLine();
            Console.WriteLine("Current accounts status:");
            bankingSystem.ListAccounts();

            Console.WriteLine();
            Console.WriteLine("Large transaction notifications:");
            bankingSystem.ListLargeTransactions();

            Console.WriteLine();
            Console.WriteLine("Interest rate example:");
            bankingSystem.ListAccounts();
            bankingSystem.AddInterestToAccounts();
            bankingSystem.ListAccounts();
            bankingSystem.InterestRate = 0.05f;
            bankingSystem.AddInterestToAccounts();
            bankingSystem.ListAccounts();


        }
    }
}
