using System;
using basketball_stats.DAO;

namespace basketball_stats
{
    class Program
    {
        static void Main(string[] args)
        {
            IBasketballDAO basketballDao = new BasketballSQLDao(@"Server=.\SQLEXPRESS;Database=basketballreference;Trusted_Connection=True;");
            Console.WriteLine("Hello World!");
        }
    }
}
