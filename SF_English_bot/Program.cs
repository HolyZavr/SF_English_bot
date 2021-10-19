using System;
using Telegram.Bot;
using TelegramBot.SF_English_bot;

namespace SF_English_bot.BaseBody
{
    /// <summary>
    /// Base class. Some simple operations.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BotWorker();

            bot.Inizailze();
            bot.Start();

            Console.WriteLine("Напишите 'stop' для преращения работы");

            string command;

            do
            {
                command = Console.ReadLine();
            } while (command != "stop") ;

            bot.Stop();
        }

        
    }
}