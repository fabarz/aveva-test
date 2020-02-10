using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandCalculatePi : CommandBase
    {
        public CommandCalculatePi(): base(3)
        {

        }

        public string Execute(int nDecimalPlaces)
        {
            if (nDecimalPlaces < 0 || nDecimalPlaces > 255)
            {
                throw new ArgumentException("Decimal Places must be bebetween 0 and 255.");
            }
            HandShake();
            string ret = string.Empty;
            byte[] msg = { (byte) nDecimalPlaces };
            int i = Sock.Send(msg);
            if (i != msg.Length)
            {
                throw Error($"Failed sending {msg.Length} bytes.");
            }
            do
            {
                i = Sock.Receive(msg);
                if (i != 1)
                {
                    throw Error($"Failed receiving {msg.Length} bytes.");
                }
                ret += (char) msg[0];
            } while (msg[0] != 10);

            return ret;
        }
    }
}
