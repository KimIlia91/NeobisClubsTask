﻿using NeobisTask.Controllers;

namespace NeobisTask
{
    public class AtmDisplay
    {
        private readonly AccountController _account;

        public AtmDisplay()
        {
            _account = new AccountController();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Write("Укажите ID счёта для выхода нажмите клавишу \"e\": ");
                var input = Console.ReadLine();
                if (input == "e" || input == "у" || input == "е" || input == "t") break;
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("ID не найден!");
                    continue;
                }
                var id = number;
                if (_account.IsAccess(id)) InPersonalAccount(id);
            }
        }

        private void InPersonalAccount(int id)
        {
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Выписка по счёту \t 2. Снять средства со счёта  \t 3. Добавить на счет");
                Console.WriteLine("4. Выйти из программы");
                Console.Write("Введите номер пункта: ");
                Console.ForegroundColor = color;
                int command = Convert.ToInt32(Console.ReadLine());
                if (command == 1) AccountInfo(id);
                else if (command == 2) Withdraw(id);
                else if (command == 3) Put(id);
                else if (command == 4) alive = false;
            }
        }

        private void AccountInfo(int id) => _account.PrintBalanceOfClient(id);

        private void Put(int id)
        {
            Console.Write("Укажите сумму, чтобы положить на счет: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal number))
            {
                var sum = number;
                Console.WriteLine(_account.PutMoneyToBalance(id, sum));
                return;
            }
            Console.WriteLine("Укажите число!");
        }

        private void Withdraw(int id)
        {
            Console.WriteLine("Укажите сумму для вывода со счета:");
            if (decimal.TryParse(Console.ReadLine(), out decimal number))
            {
                var sum = number;
                Console.WriteLine(_account.WithdrawMoneyFromBalance(id, sum));
                return;
            }
            Console.WriteLine("Укажите число!");
        }
    }
}