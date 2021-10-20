using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF_English_bot
{
    class BotWorker
    {
        private ITelegramBotClient client;
        private BotMessageLogic logic;
        public void Inizalize()
        {
            client = new TelegramBotClient(BotToken.token);
            logic = new BotMessageLogic(client);
        }

        public void Start()
        {
            client.StartReceiving();
            client.OnMessage += TelegramMessageHandler;
        }

        private async void TelegramMessageHandler(object sender, MessageEventArgs e) //это метод, в уроке, Bot_OnMessage
        {
            

            if (e.Message != null)
            {
                await logic.Response(e);
            }
        }

        public void Stop()
        {
            client.StopReceiving();
        }
    }
}
