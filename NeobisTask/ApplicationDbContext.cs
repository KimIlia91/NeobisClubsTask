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
            Users = new List<User>()
            {
                new User { Name = "Talant", LastName = "Talantbekov", Balance = 5000 },
                new User { Name = "Ruslan", LastName = "Ruslanov", Balance = 1000 },
                new User { Name = "Aida", LastName = "Aidova", Balance = 800 }
            };
        }
    }
}
