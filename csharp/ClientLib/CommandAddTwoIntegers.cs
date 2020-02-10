using BackgWorker;
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
        private ushort val1, val2;

        public CommandAddTwoIntegers(ITransportMedium medium, ushort value1, ushort value2): base(medium, 4)
        {
            val1 = value1;
            val2 = value2;
        }

        protected override string ExecuteInternal()
        {
            HandShake();

            Medium.WriteUInt16(val1);
            Medium.WriteUInt16(val2);

            uint res = Medium.ReadUInt32();

            return res.ToString();
        }
    }
}
