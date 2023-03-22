namespace NeobisTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm();
            atm.PrintAll();
            atm.PrintBalanceOfClient("Talantbekov");
            atm.PutMoneyToBalance("Talantbekov", 100);
            atm.PrintBalanceOfClient("Talantbekov");
            atm.WithdrawMoneyFromBalance("Talantbekov", 500);
            atm.PrintBalanceOfClient("Talantbekov");
            atm.PrintBalanceOfClient("Aidova");
            atm.PutMoneyToBalance("Aidova", 10_000);
            atm.PrintBalanceOfClient("Aidova");
            atm.WithdrawMoneyFromBalance("Aidova", 500);
            atm.PrintBalanceOfClient("Aidova");
            atm.PrintAll();
        }
    }
}