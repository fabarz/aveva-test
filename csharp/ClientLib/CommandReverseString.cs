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
            WriteString(text + Environment.NewLine);
            string ret = ReadString(text.Length + 1);
            return ret;
        }
    }
}
