using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandBase: IDisposable
    {
        public string Host { get; private set; }
        public int Port { get; private set; }
        protected byte CommandType { get; set; }

        protected Socket Sock = null;

        public CommandBase(int commandType)
        {
            CommandType = (byte) commandType;
            if (CommandType < 1 || CommandType > 4)
            {
                throw new ArgumentException($@"Invalid command type [ {CommandType} ]");
            }
            Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string host, int port)
        {
            Host = host;
            Port = port;
            Sock.Connect(Host, Port);
        }

        public void HandShake()
        {
            WriteByte(CommandType);
            byte errCode = ReadByte();
            if (errCode != 0)
            {
                ErrorCode ec = new ErrorCode(errCode);
                throw Error("Exception: " + ec.ToString());
            }
        }

        public byte[] ReadBytes(int num)
        {
            byte[] msg = new byte[num];
            int i = Sock.Receive(msg);
            if (i != num)
            {
                throw Error($@"Did not receive {num} bytes.");
            }
            return msg;
        }

        public void WriteByte(byte val)
        {
            byte[] byteArr = { val };
            int nBytes = Sock.Send(byteArr);
            if (nBytes != 1)
            {
                throw Error("Failed sending first byte to server.");
            }
        }

        public byte ReadByte()
        {
            byte[] byteArr = { 0xFF };
            int nBytes = Sock.Receive(byteArr);
            if (nBytes != 1)
            {
                throw Error("Server did not reply with a byte");
            }
            return byteArr[0];
        }

        public void WriteUInt16(ushort val)
        {
            //short sval1 = IPAddress.HostToNetworkOrder((short) val1);
            byte[] msg = BitConverter.GetBytes(val);
            int i = Sock.Send(msg);
            if (i != 2)
            {
                throw Error("Failed sending 2 bytes.");
            }
        }

        public uint ReadUInt32()
        {
            byte[] res = new byte[4];
            int i = Sock.Receive(res);
            if (i != 4)
            {
                throw Error("Did not receive 4 bytes.");
            }
            int ret = BitConverter.ToInt32(res, 0);
            int hostRet = IPAddress.NetworkToHostOrder(ret);
            return (uint)hostRet;
        }

        protected CommunicationException Error(string msg)
        {
            return new CommunicationException(msg);
        }

        public void Dispose()
        {
            try
            {
                Sock.Dispose();
            }
            catch { }
        }
    }
}
