using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandReverseInteger : CommandBase
    {
        public CommandReverseInteger(): base(2)
        {

        }

        public string Execute()
        {
            HandShake();

            uint val = ReadUInt32();
            uint calc = ReverseUInt32(val);
            WriteUInt32(calc);

            byte result = ReadByte();

            string ret = "Received: 0x" + val.ToString("X") 
                + " Sent: 0x" + calc.ToString("X") 
                + " Result: 0x" + result.ToString("X");
            return ret;
        }

        private static uint ReverseUInt32(uint hostOrder)
        {
            byte[] hostBytes = BitConverter.GetBytes(hostOrder);
            Array.Reverse(hostBytes);
            uint res = BitConverter.ToUInt32(hostBytes, 0);
            return res;
        }
    }
}
