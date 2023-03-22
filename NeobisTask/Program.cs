using NeobisTask.Controllers;
using NeobisTask.Models;

namespace NeobisTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new AtmDisplay();
            atm.MainMenu();
        }
    }
}