using Labb4IndividuelltDatabasProjekt.Models;

namespace Labb4IndividuelltDatabasProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolContext context = new SchoolContext();
            context.ShowMenu();
        }
    }
}
