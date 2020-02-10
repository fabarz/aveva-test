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
    /// <summary>
    /// Base class of all the commands to the TCP/IP server.
    /// </summary>
    public abstract class CommandBase: IWorkElement
    {
        public string Host { get; private set; }
        public int Port { get; private set; }
        protected byte CommandType { get; set; }

        /// <summary>
        /// The transport medium for messages to the server.
        /// </summary>
        protected ITransportMedium Medium { get; set; }
         
        //IWorkElement interface members
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

        /// <summary>
        /// Initial handshake with the server
        /// </summary>
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

        /// <summary>
        /// IWorkElement member
        /// </summary>
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

        /// <summary>
        /// Every command will do a different thing.
        /// The implementation of specific command actions goes here.
        /// </summary>
        /// <returns></returns>
        protected virtual string ExecuteInternal()
        {
            throw new NotImplementedException();
        }
    }
}
