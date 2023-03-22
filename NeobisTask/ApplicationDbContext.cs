using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeobisTask
{
    /// <summary>
    /// Класс имитирует контекст для работы с СУБД
    /// </summary>
    public class ApplicationDbContext
    {
        public List<User> Users { get; set; }

        public ApplicationDbContext()
        {
            Users = ModelsCreating();
        }

        private static List<User> ModelsCreating()
        {
            return new List<User>()
            {
                new User { Id = 1, Name = "Талант", LastName = "Талантов", Balance = 5000 },
                new User { Id = 2, Name = "Руслан", LastName = "Русланов", Balance = 1000 },
                new User { Id = 3, Name = "Аида", LastName = "Аидова", Balance = 800 }
            };
        }
    }
}
