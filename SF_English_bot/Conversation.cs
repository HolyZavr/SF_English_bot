using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.SF_English_bot
{
    /// <summary>
    /// Class for chat's object.
    /// </summary>
    class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        public Conversation(Chat chat)
        {
            this.telegramChat = chat;
            telegramMessages = new List<Message>();
        }
    }
}
