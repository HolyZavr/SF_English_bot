using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF_English_bot
{
    class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            // chat.GetTextMessages().ToArray();
            // string delimiter = ",";
            //string text = "Your history:" + string.Join(delimiter, chat.GetTextMessages().ToArray());


            var text = "";

            switch (chat.GetLastMessage())
            {
                case "/saymehi":
                    text = "Привет";
                    break;

                case "/askme":
                    text = "Как дела?";
                    break;

                default:
                    string delimiter = ",";
                    text = "Your history:" + string.Join(delimiter, chat.GetTextMessages().ToArray());
                    break;
            }

            return text;

        }
    }
}
