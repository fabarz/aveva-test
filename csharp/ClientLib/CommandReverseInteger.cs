using BackgWorker;
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
        private Func<uint, uint> ReverseFunction { get; set; }

        public CommandReverseInteger(ITransportMedium medium, Func<uint, uint> reverseFunction): base(medium, 2)
        {
            ReverseFunction = reverseFunction;
        }

        protected override string ExecuteInternal()
        {
            HandShake();

            uint val = Medium.ReadUInt32();
            uint calc = ReverseFunction(val);
            Medium.WriteUInt32(calc);

            byte result = Medium.ReadByte();

            string ret = "Received: 0x" + val.ToString("X") 
                + " Sent: 0x" + calc.ToString("X") 
                + " Result: 0x" + result.ToString("X");
            return ret;
        }
    }
}
