using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF_English_bot.Command
{
    class PoemButtonCommand
    {
        private ITelegramBotClient client;
        public InlineKeyboardMarkup ReturnKeBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton()
                {
                    Text = "Пушкин",
                    CallbackData = "pushkin"
                },

                new InlineKeyboardButton()
                {
                    Text = "Пушкин",
                    CallbackData = "pushkin"
                }
            };

            var keyboard = new InlineKeyboardMarkup(buttonList);

            return keyboard;
        }

        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await client.SendTextMessageAsync(
            chatId: chat.GetId(), text: text, replyMarkup: keyboard);
        }

        private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        {
            var text = "";

            switch (e.CallbackQuery.Data)
            {
                case "pushkin":
                    text = @"Я помню чудное мгновенье:
                             Передо мной явилась ты,
                             Как мимолетное виденье,
                             Как гений чистой красоты.";
                    break;

                case "esenin":
                    text = @"Не каждый умеет петь,
                             Не каждому дано яблоком
                             Падать к чужим ногам.";
                    break;
            }

            await client.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
            await client.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }
    }
}
