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

            WriteUInt16(val1);
            WriteUInt16(val2);

            uint res = ReadUInt32();

            return res;
        }
    }
}
