using NeobisTask.Models;

namespace NeobisTask.Data
{
    /// <summary>
    /// Класс имитирует контекст для работы с СУБД
    /// </summary>
    public class ApplicationDbContext
    {
        public List<Account> Accounts { get; set; }

        public ApplicationDbContext()
        {
            Accounts = ModelsCreating();
        }

        private static List<Account> ModelsCreating()
        {
            return new List<Account>()
            {
                new Account { Id = 1, Name = "Талант", LastName = "Талантов", Balance = 5000 },
                new Account { Id = 2, Name = "Руслан", LastName = "Русланов", Balance = 1000 },
                new Account { Id = 3, Name = "Аида", LastName = "Аидова", Balance = 800 }
            };
        }
    }
}
