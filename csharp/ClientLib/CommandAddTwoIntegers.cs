using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandAddTwoIntegers : CommandBase
    {
        public CommandAddTwoIntegers(): base(4)
        {

        }

        public uint Execute(ushort val1, ushort val2)
        {
            HandShake();
            //short sval1 = IPAddress.HostToNetworkOrder((short) val1);
            byte[] msg = BitConverter.GetBytes(val1);
            int i = Sock.Send(msg);
            if (i != 2)
            {
                throw Error("Failed sending 2 bytes.");
            }
            //short sval2 = IPAddress.HostToNetworkOrder((short)val2);
            msg = BitConverter.GetBytes(val2);
            i = Sock.Send(msg);
            if (i != 2)
            {
                throw Error("Failed sending 2 bytes.");
            }
            byte[] res = new byte[4];
            i = Sock.Receive(res);
            if (i != 4)
            {
                throw Error("Did not receive 4 bytes.");
            }
            int ret = BitConverter.ToInt32(res, 0);
            int hostRet = IPAddress.NetworkToHostOrder(ret);
            return (uint)hostRet;
        }
    }
}
