using CodingTracker.Controllers;
using CodingTracker.Data;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbConnection.StartConnection();
            UserInterface.MainMenu();
        }
    }
}