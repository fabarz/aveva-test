using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandCalculatePi : CommandBase
    {
        public CommandCalculatePi(): base(3)
        {

        }

        public string Execute(int nDecimalPlaces)
        {
            if (nDecimalPlaces < 0 || nDecimalPlaces > 255)
            {
                throw new ArgumentException("Decimal Places must be bebetween 0 and 255.");
            }

            HandShake();

            WriteByte((byte)nDecimalPlaces);

            string ret = ReadString(2 + nDecimalPlaces + 1);

            return ret;
        }
    }
}
