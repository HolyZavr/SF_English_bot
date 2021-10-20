using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF_English_bot
{
    /// <summary>
    /// Base class. Some simple operations.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BotWorker();

            bot.Inizalize();
            bot.Start();

            Console.WriteLine("Print 'stop' for stop bot.");

            string command;

            do
            {
                command = Console.ReadLine();
            } while (command != "stop");

            bot.Stop();
        }


    }
}