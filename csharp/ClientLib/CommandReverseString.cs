using BackgWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommandReverseString: CommandBase
    {
        private string param;

        public CommandReverseString(ITransportMedium medium, string parameter): base(medium, 1)
        {
            param = parameter;
        }

        protected override string ExecuteInternal()
        {
            HandShake();
            Medium.WriteString(param + Environment.NewLine);
            string ret = Medium.ReadString(param.Length + 1);
            return ret;
        }
    }
}
