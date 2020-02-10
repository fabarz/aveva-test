using BackgWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class SocketMedium : ITransportMedium, IDisposable
    {
        private Socket sock;
        public SocketMedium()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connected
        {
            get
            {
                return sock.Connected;
            }
        }

        public void Connect(string host, int port)
        {
            sock.Connect(host, port);
        }

        public void Disconnect()
        {
            sock.Disconnect(reuseSocket: false);
        }

        public void Dispose()
        {
            try
            {
                sock.Dispose();
            }
            catch { }
        }

        public byte ReadByte()
        {
            byte[] byteArr = { 0xFF };
            int nBytes = sock.Receive(byteArr);
            if (nBytes != 1)
            {
                throw new CommunicationException("Server did not reply with a byte");
            }
            return byteArr[0];
        }

        public byte[] ReadBytes(int num)
        {
            byte[] msg = new byte[num];
            int i = sock.Receive(msg);
            if (i != num)
            {
                throw new CommunicationException($@"Did not receive {num} bytes.");
            }
            return msg;
        }

        public string ReadString(int length)
        {
            byte[] msg = ReadBytes(length);
            return Encoding.UTF8.GetString(msg);
        }

        public uint ReadUInt32()
        {
            byte[] res = ReadBytes(4);
            int ret = BitConverter.ToInt32(res, 0);
            int hostRet = IPAddress.NetworkToHostOrder(ret);
            return (uint)hostRet;
        }

        public void WriteByte(byte val)
        {
            byte[] byteArr = { val };
            int nBytes = sock.Send(byteArr);
            if (nBytes != 1)
            {
                throw new CommunicationException("Failed sending first byte to server.");
            }
        }

        public void WriteBytes(byte[] msg)
        {
            int i = sock.Send(msg);
            if (i != msg.Length)
            {
                throw new CommunicationException($@"Could not send {msg.Length} bytes.");
            }
        }

        public void WriteString(string text)
        {
            byte[] msg = Encoding.UTF8.GetBytes(text);
            WriteBytes(msg);
        }

        public void WriteUInt16(ushort val)
        {
            //short sval1 = IPAddress.HostToNetworkOrder((short) val1);
            //TODO: Why is the above not necessary
            byte[] msg = BitConverter.GetBytes(val);
            int i = sock.Send(msg);
            if (i != 2)
            {
                throw new CommunicationException("Failed sending 2 bytes.");
            }
        }

        public void WriteUInt32(uint val)
        {
            int val1 = IPAddress.HostToNetworkOrder((int)val);
            byte[] msg = BitConverter.GetBytes(val1);
            WriteBytes(msg);
        }
    }
}
