using System;

namespace solidarity_bond
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lancement application");
            Service service = new Service();
            service.StartListening();
        }
    }
}
