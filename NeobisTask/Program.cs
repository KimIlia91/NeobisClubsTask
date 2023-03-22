namespace NeobisTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm();
            var answer = string.Empty;
            atm.PrintAll();

            atm.PrintBalanceOfClient("Talantbekov");
            answer = atm.PutMoneyToBalance("Talantbekov", 100);
            Console.WriteLine(answer);
            answer = atm.WithdrawMoneyFromBalance("Talantbekov", 500);
            Console.WriteLine(answer);
            atm.PrintBalanceOfClient("Talantbekov");


            atm.PrintBalanceOfClient("Aidova");
            answer = atm.PutMoneyToBalance("Aidova", 10_000);
            Console.WriteLine(answer);
            answer = atm.WithdrawMoneyFromBalance("Aidova", 500);
            Console.WriteLine(answer);
            atm.PrintBalanceOfClient("Aidova");
            
            atm.PrintAll();
        }
    }
}