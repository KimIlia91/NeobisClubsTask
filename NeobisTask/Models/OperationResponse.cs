namespace NeobisTask.Models
{
    public class OperationResponse
    {
        public StatusResponse Status { get; set; }

        public Account? Account { get; set; }

        public List<Account>? Accounts { get; set; }
    }
}
