using System;
using SendMessages;

namespace SenderTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sender!");
            var sender = new Send();
            sender.Act();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}