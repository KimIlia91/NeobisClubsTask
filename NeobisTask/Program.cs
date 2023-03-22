using NeobisTask.Controllers;
using NeobisTask.Models;

namespace NeobisTask
{
    /// <summary>
    /// Создано три тестовых клиента.
    /// Id для теста 1, 2, 3
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new AtmDisplay();
            atm.MainMenu();
        }
    }
}