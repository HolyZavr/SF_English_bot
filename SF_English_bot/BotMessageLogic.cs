using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF_English_bot
{
    /// <summary>
    /// Class for message logic.
    /// </summary>
    class BotMessageLogic
    {
        private Messenger messanger;
        private Dictionary<long, Conversation> chatList;
        private ITelegramBotClient client;

        public BotMessageLogic(ITelegramBotClient client)
        {
            this.client = client;
            chatList = new Dictionary<long, Conversation>();
            messanger = new Messenger();
        }
        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id; /// получаем id чата, тип данных long, 1ый эллемент коллекции (ключ).

            if (!chatList.ContainsKey(Id)) // проверка на наличие чата в коллекции
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);

            await SendTextMessage(chat);
        }

        private async Task SendTextMessage(Conversation chat)
        {
            var text = messanger.CreateTextMessage(chat);

            await client.SendTextMessageAsync(chatId: chat.GetId(), text: text);
        }
    }
}
