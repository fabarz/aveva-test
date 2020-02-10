using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandBase: IDisposable
    {
        public string Host { get; private set; }
        public int Port { get; private set; }
        protected int CommandType { get; set; }

        protected Socket Sock = null;

        public CommandBase(int commandType)
        {
            CommandType = commandType;
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
            byte[] byteArr = { (byte)CommandType };
            int nBytes = Sock.Send(byteArr);
            if (nBytes != 1)
            {
                throw Error("Failed sending first byte to server.");
            }
            nBytes = Sock.Receive(byteArr);
            if (nBytes != 1)
            {
                throw Error("Server did not reply with a byte");
            }
            if (byteArr[0] != 0)
            {
                ErrorCode ec = new ErrorCode(byteArr[0]);
                throw Error("Exception: " + ec.ToString());
            }
        }

        protected CommunicationException Error(string msg)
        {
            return new CommunicationException(msg);
        }

        public void Dispose()
        {
            try
            {
                Sock.Disconnect(reuseSocket: false);
            }
            catch { }
        }
    }
}
