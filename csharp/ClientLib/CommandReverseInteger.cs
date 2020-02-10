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
            string ret = string.Empty;
            HandShake();
            byte[] msg = new byte[4];
            int i = Sock.Receive(msg);
            if (i != 4)
            {
                throw Error("Did not receive 4 bytes.");
            }
            ret += "Received: " + BitConverter.ToString(msg);


            ReverseInteger(msg);


            i = Sock.Send(msg);
            if (i != 4)
            {
                throw Error("Could not send 4 bytes.");
            }
            ret += " Sent: " + BitConverter.ToString(msg);
            byte[] result = { 0xff };
            i = Sock.Receive(result);
            if (i != 1)
            {
                throw Error("Did not receive 1 byte result.");
            }

            ret += " Result: " + BitConverter.ToString(result);
            return ret;
        }

        private void ReverseInteger(byte[] msg)
        {
            int res = BitConverter.ToInt32(msg, 0);
            int hostOrder = IPAddress.NetworkToHostOrder(res);
            byte[] hostBytes = BitConverter.GetBytes(hostOrder);
            Array.Reverse(hostBytes);
            res = BitConverter.ToInt32(hostBytes, 0);
            int netOrder = IPAddress.HostToNetworkOrder(res);
            byte[] netBytes = BitConverter.GetBytes(netOrder);
            Array.Copy(netBytes, 0, msg, 0, 4);
        }
    }
}
