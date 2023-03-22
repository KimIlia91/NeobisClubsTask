namespace NeobisTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm();
            atm.PrintAll();

            atm.PrintBalanceOfClient(1);
            Console.WriteLine(atm.PutMoneyToBalance(1, 100));
            Console.WriteLine(atm.WithdrawMoneyFromBalance(1, 500));
            atm.PrintBalanceOfClient(1);

            atm.PrintBalanceOfClient(3);
            Console.WriteLine(atm.PutMoneyToBalance(3, 10_000));
            Console.WriteLine(atm.WithdrawMoneyFromBalance(3, 500));
            atm.PrintBalanceOfClient(3);
            
            atm.PrintAll();
        }
    }
}