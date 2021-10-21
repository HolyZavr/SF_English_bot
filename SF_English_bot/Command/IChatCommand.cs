using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_English_bot.Command
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
