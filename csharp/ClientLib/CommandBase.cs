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
    public abstract class CommandBase: IWorkElement
    {
        //TODO: Seperate Socket from Command. To be able to read and write to different medium.

        public string Host { get; private set; }
        public int Port { get; private set; }
        protected byte CommandType { get; set; }
        protected ITransportMedium Medium { get; set; }

        //IElement
        public Exception Error { get; set; }
        public string Result { get; protected set; }
        public object ResultContainer { get; set; }

        public CommandBase(ITransportMedium medium, int commandType)
        {
            CommandType = (byte) commandType;
            if (CommandType < 1 || CommandType > 4)
            {
                throw new ArgumentException($@"Invalid command type [ {CommandType} ]");
            }
            Medium = medium;
        }

        public void HandShake()
        {
            Medium.WriteByte(CommandType);
            byte errCode = Medium.ReadByte();
            if (errCode != 0)
            {
                ErrorCode ec = new ErrorCode(errCode);
                throw new CommunicationException(ec.ToString());
            }
        }

        //IElement
        public void Execute()
        {
            try
            {
                Error = null;
                Result = ExecuteInternal();
            }
            catch (Exception ex)
            {
                Error = ex;
            }
        }

        protected virtual string ExecuteInternal()
        {
            throw new NotImplementedException();
        }
    }
}
