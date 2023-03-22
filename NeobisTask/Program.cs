namespace NeobisTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm();
            var answer = string.Empty;
            atm.PrintAll();

            atm.PrintBalanceOfClient(1);
            answer = atm.PutMoneyToBalance(1, 100);
            Console.WriteLine(answer);
            answer = atm.WithdrawMoneyFromBalance(1, 500);
            Console.WriteLine(answer);
            atm.PrintBalanceOfClient(1);

            atm.PrintBalanceOfClient(3);
            answer = atm.PutMoneyToBalance(3, 10_000);
            Console.WriteLine(answer);
            answer = atm.WithdrawMoneyFromBalance(3, 500);
            Console.WriteLine(answer);
            atm.PrintBalanceOfClient(3);
            
            atm.PrintAll();
        }
    }
}