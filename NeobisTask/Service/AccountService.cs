using NeobisTask.Data;
using NeobisTask.Models;
using NeobisTask.Repositories.IRepositories;

namespace NeobisTask.Repositories
{
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
                var accountToUpdate = new Account()
                {
                    Id = account.Id,
                    LastName = account.LastName,
                    Name = account.Name,
                    Balance = account.Balance + sum
                };
                _db.Accounts.Remove(account);
                _db.Accounts.Add(accountToUpdate);
                _response.Account = accountToUpdate;
                _response.Status = StatusResponse.Ok;
            }
            
            return _response;
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
                var accountToUpdate = new Account()
                {
                    Id = account.Id,
                    LastName = account.LastName,
                    Name = account.Name,
                    Balance = account.Balance - sum
                };
                _db.Accounts.Remove(account);
                _db.Accounts.Add(accountToUpdate);
                _response.Account = accountToUpdate;
                _response.Status = StatusResponse.Ok;
            }

            return _response;
        }
    }
}
