using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot.SF_English_bot
{
    /// <summary>
    /// Base bot operations. Initialize. Start. Stop.
    /// </summary>
    class BotWorker
    {
        private ITelegramBotClient client;
        private BotMessageLogic logic;

        public void Inizailze ()
        {
            client = new TelegramBotClient(BotToken.token);
            logic = new BotMessageLogic();
        }

        public void Start()
        {
            client.OnMessage += Bot_OnMessage;
            client.StartReceiving();
        }

        private async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                await client.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Вы написали:\n" + e.Message.Text);
            }
        }

        public void Stop()
        {
            client.StopReceiving();
        }

        

    }
}
