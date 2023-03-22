using NeobisTask.Repositories;
using NeobisTask.Repositories.IRepositories;

namespace NeobisTask.Controllers
{
    /// <summary>
    /// Класс банкомат содержит все основные операции,
    /// которые были в задании(Снятие, поплнение, проверка баланса).
    /// </summary>
    public class AccountController
    {
        private readonly IAccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }

        public bool IsAccess(int id)
        {
            var response = _service.GetFirstOrDefault(id);
            return response.Status == StatusResponse.Ok;
        }

        //Get
        public void PrintBalanceOfClient(int id)
        {
            var response = _service.GetFirstOrDefault(id);
            if (response.Status == StatusResponse.NotFound)
                Console.WriteLine("Клиент не найден!");
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"Проверка баланса.");
            Console.WriteLine($"Фамилия: {response.Account!.LastName}");
            Console.WriteLine($"Имя: {response.Account!.Name}");
            Console.WriteLine($"Баланс: {response.Account!.Balance}");
            Console.WriteLine($"-------------------------");
        }

        //PUT 
        public string PutMoneyToBalance(int id, decimal moneyToPut)
        {
            var response = _service.AddSum(id, moneyToPut);
            if (response.Status == StatusResponse.NotFound)
                return "Клиент не найден!";
            if (response.Status == StatusResponse.InvalidSum)
                return "Сумма неможет быть меньше или равна нулю.";
            return $"Баланс был пополнен на {moneyToPut}. Ваш текущий баланс {response.Account!.Balance}.";
        }

        //PUT 
        public string WithdrawMoneyFromBalance(int id, decimal moneyToWithdraw)
        {
            var response = _service.MinusSum(id, moneyToWithdraw);
            if (response.Status == StatusResponse.NotFound)
                return "Клиент не найден!";
            if (response.Status == StatusResponse.InvalidSum)
                return "Сумма снятия не может быть меньше нуля или ноль!";
            if (response.Status == StatusResponse.InsufficientFunds)
                return "Недостаточно денег на балансе счёта!";
            return $"Вы сняли {moneyToWithdraw}. Ваш текущий баланс {response.Account!.Balance}.";
        }
    }
}
