using System;

namespace solidarity_bond
{
    class ConnectionComptoir
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lancement application");
            Service service = new Service();
            service.StartListening();
        }
    }
}
