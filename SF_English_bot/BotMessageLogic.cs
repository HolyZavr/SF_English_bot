using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF_English_bot
{
    /// <summary>
    /// Class for message logic.
    /// </summary>
    class BotMessageLogic
    {
        private Messanger messanger;
        private Dictionary<long, Conversation> chatList;
        private ITelegramBotClient client;

        public BotMessageLogic(ITelegramBotClient client)
        {
            this.client = client;
            chatList = new Dictionary<long, Conversation>();
            messanger = new Messanger();
        }
        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);

            await SendTextMessage(chat);
        }
    }
}
