using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    /// <summary>
    /// Transport medium used for communication.
    /// We have only a socket currently.
    /// But this can be another medium. For example CAN or BITBUS or others.
    /// </summary>
    public interface ITransportMedium
    {
        bool Connected { get; }

        void Connect(string host, int port);
        void Disconnect();
        void WriteBytes(byte[] msg);
        byte[] ReadBytes(int num);
        void WriteByte(byte val);
        byte ReadByte();
        void WriteUInt16(ushort val);
        void WriteUInt32(uint val);
        uint ReadUInt32();
        void WriteString(string text);
        string ReadString(int length);
    }
}
