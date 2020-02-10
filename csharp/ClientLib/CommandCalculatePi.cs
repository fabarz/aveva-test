using BackgWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandCalculatePi : CommandBase
    {
        private int decimalPlaces;

        public CommandCalculatePi(ITransportMedium medium, int nDecimalPlaces) : base(medium, 3)
        {
            if (nDecimalPlaces < 0 || nDecimalPlaces > 255)
            {
                throw new ArgumentException("Decimal Places must be bebetween 0 and 255.");
            }
            decimalPlaces = nDecimalPlaces;
        }

        protected override string ExecuteInternal()
        {
            HandShake();

            Medium.WriteByte((byte)decimalPlaces);

            string ret = Medium.ReadString(2 + decimalPlaces + 1);

            return ret;
        }
    }
}
