using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandReverseString: CommandBase
    {
        public CommandReverseString(): base(1)
        {

        }

        public string Execute(string text)
        {
            HandShake();
            byte[] msg = Encoding.UTF8.GetBytes(text + Environment.NewLine);
            int i = Sock.Send(msg);
            if (i != msg.Length)
            {
                throw Error($"Failed sending {msg.Length} bytes.");
            }
            i = Sock.Receive(msg);
            if (i != msg.Length - 1)
            {
                throw Error($"Failed receiving {msg.Length - 1} bytes.");
            }
            return Encoding.UTF8.GetString(msg);
        }
    }
}
