using NeobisTask.Data;
using NeobisTask.Models;
using NeobisTask.Services.IServices;

namespace NeobisTask.Services
{
    /// <summary>
    /// Класс сервис для обработки данных из БД
    /// И передачи ответа в контроллер
    /// Инъекция через интерфейс IAccountService
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly OperationResponse _response;

        public AccountService()
        {
            _db = new ApplicationDbContext();
            _response = new OperationResponse();
        }

        public OperationResponse GetFirstOrDefault(int id)
        {
            var account = _db.Accounts.FirstOrDefault(x => x.Id == id);
            if (account is null)
            {
                _response.Status = StatusResponse.NotFound;
                return _response;
            }
            _response.Status = StatusResponse.Ok;
            _response.Account = account;
            return _response;
        }

        public OperationResponse AddSum(int id, decimal sum)
        {
            var account = _db.Accounts.FirstOrDefault(a => a.Id == id);
            if (account is null)
                _response.Status = StatusResponse.NotFound;
            else if (sum <= 0) 
                _response.Status = StatusResponse.InvalidSum;
            else
            {
                Account accountToUpdate = CreateAccountToAddSum(sum, account);
                _db.Accounts.Remove(account);
                _db.Accounts.Add(accountToUpdate);
                _response.Account = accountToUpdate;
                _response.Status = StatusResponse.Ok;
            }
            return _response;
        }

        private static Account CreateAccountToAddSum(decimal sum, Account? account)
        {
            return new Account()
            {
                Id = account.Id,
                LastName = account.LastName,
                Name = account.Name,
                Balance = account.Balance + sum
            };
        }

        public OperationResponse MinusSum(int id, decimal sum)
        {
            var account = _db.Accounts.FirstOrDefault(a => a.Id == id);
            if (account is null)
                _response.Status = StatusResponse.NotFound;
            else if (sum <= 0)
                _response.Status = StatusResponse.InvalidSum;
            else if (sum > account.Balance)
                _response.Status = StatusResponse.InsufficientFunds;
            else
            {
                var accountToUpdate = CreateAccountForMinusSum(sum, account);
                _db.Accounts.Remove(account);
                _db.Accounts.Add(accountToUpdate);
                _response.Account = accountToUpdate;
                _response.Status = StatusResponse.Ok;
            }
            return _response;
        }

        private static Account CreateAccountForMinusSum(decimal sum, Account account)
        {
            return new Account()
            {
                Id = account.Id,
                LastName = account.LastName,
                Name = account.Name,
                Balance = account.Balance - sum
            };
        }
    }
}
