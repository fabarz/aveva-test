using System;

namespace ClientLib
{
    internal class ErrorCode
    {
        public bool ErrorBit { get; private set; }
        public int Code { get; private set; }
        public int Address { get; private set; }

        public ErrorCode(byte b)
        {
            Code = b & 0x03;
            Address = (b & 0x7F) >> 2;
            ErrorBit = (b & 0x80) != 0;  
        }

        public override string ToString()
        {
            string ret = ErrorBit ? "ERROR" : "SUCCESS";
            ret += Environment.NewLine;
            if (ErrorBit)
            {
                ret += "CODE: " + CodeToString();
                ret += Environment.NewLine;
                ret += "ADDRESS: " + AddressToString();
                ret += Environment.NewLine;
            }
            return ret;
        }

        private string AddressToString()
        {
            return Address.ToString();
        }

        private string CodeToString()
        {
            switch(Code)
            {
                case (0): return "Out Of Memory";
                case (1): return "Invalid Argument";
                case (2): return "Communication Failure";
                case (3): return "Unsupported Command";
                default: return "Unknown Error";
            }
        }
    }
}