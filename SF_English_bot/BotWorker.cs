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
            logic = new BotMessageLogic();
        }

        public void Start()
        {
            client.StartReceiving();
            client.OnMessage += TelegramMessageHandler;
        }

        private async void TelegramMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение: {msg.Text}");
                await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
            }
        }

        public void Stop()
        {
            client.StopReceiving();
        }
    }
}
