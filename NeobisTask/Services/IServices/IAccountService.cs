using NeobisTask.Models;

namespace NeobisTask.Services.IServices
{
    public interface IAccountService
    {
        OperationResponse GetFirstOrDefault(int id);

        OperationResponse AddSum(int id, decimal sum);

        OperationResponse MinusSum(int id, decimal sum);
    }
}
