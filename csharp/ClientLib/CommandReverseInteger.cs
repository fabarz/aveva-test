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
            //Needs refactoring.

            string ret = string.Empty;
            HandShake();

            byte[] msg = ReadBytes(4);
            ret += "Received: " + BitConverter.ToString(msg);

            ReverseInteger(msg);

            WriteBytes(msg);
            ret += " Sent: " + BitConverter.ToString(msg);

            byte[] result = ReadBytes(1);

            ret += " Result: " + BitConverter.ToString(result);
            return ret;
        }

        private void ReverseInteger(byte[] msg)
        {
            uint res = BitConverter.ToUInt32(msg, 0);
            int hostOrder = IPAddress.NetworkToHostOrder((int) res);

            res = ReverseUInt32((uint) hostOrder);

            int netOrder = IPAddress.HostToNetworkOrder((int) res);
            byte[] netBytes = BitConverter.GetBytes(netOrder);
            Array.Copy(netBytes, 0, msg, 0, 4);
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
