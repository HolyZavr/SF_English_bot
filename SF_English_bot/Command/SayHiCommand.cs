using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_English_bot.Command
{
    class SayHiCommand : AbstractCommand, IChatCommand
    {
        public SayHiCommand()
        {
            CommandText = "/saymehi";
        }

        public string ReturnText()
        {
            return "hello!";
        }
    }
}
