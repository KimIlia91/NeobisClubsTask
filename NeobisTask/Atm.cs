using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeobisTask
{
    /// <summary>
    /// Класс банкомат содержит все основные операции,
    /// которые были в задании(Снятие, поплнение, проверка баланса).
    /// Также Добавил функцию получить всех клиентов для инфы, чтобы смотреть 
    /// инфу по тестовым клиентам которые создаются по умолчанию.
    /// </summary>
    public class Atm
    {
        private readonly ApplicationDbContext _db;

        public Atm()
        {
            _db = new ApplicationDbContext();
        }

        //Get
        public void PrintBalanceOfClient(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
                Console.WriteLine("Клиент не найден!");
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"Проверка баланса.");
            Console.WriteLine($"Фамилия: {user!.LastName}");
            Console.WriteLine($"Имя: {user!.Name}");
            Console.WriteLine($"Баланс: {user!.Balance}");
            Console.WriteLine($"-------------------------");
        }

        //PUT 
        public string PutMoneyToBalance(int id, double moneyToPut)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user is null)
                return "Клиент не найден!";
            var newBalance = user!.Balance + moneyToPut;
            var userToUpdate = new User
            {
                LastName = user!.LastName,
                Name = user!.Name,
                Balance = newBalance
            };

            _db.Users.Remove(user);
            _db.Users.Add(userToUpdate);
            return $"Баланс был пополнен на {moneyToPut}. Ваш текущий баланс {newBalance}.";
        }

        //PUT 
        public string WithdrawMoneyFromBalance(int id, double moneyToWithdraw)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user is null)
                Console.WriteLine("Клиент не найден!");
            if (user!.Balance < moneyToWithdraw)
                return "Недостаточно денег на балансе счёта!";
            var balance = user!.Balance - moneyToWithdraw;
            var userToUpdate = new User
            {
                LastName = user!.LastName,
                Name = user!.Name,
                Balance = balance
            };

            _db.Users.Remove(user);
            _db.Users.Add(userToUpdate);
            return $"Вы сняли {moneyToWithdraw}. Ваш текущий баланс {balance}.";
        }

        //Get
        public void PrintAll()
        {
            var users = _db.Users.ToList();
            Console.WriteLine($"***************************");
            Console.WriteLine($"Список всех клиентов.");
            foreach (var user in users.OrderBy(u => u.LastName))
            {
                Console.WriteLine($"-------------------------");
                Console.WriteLine($"Фамилия: {user.LastName}");
                Console.WriteLine($"Имя: {user.Name}");
                Console.WriteLine($"Баланс: {user.Balance}");
                Console.WriteLine($"-------------------------");
            }
            Console.WriteLine($"***************************");
        }
    }
}
