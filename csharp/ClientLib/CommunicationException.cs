using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class CommunicationException: Exception
    {
        public CommunicationException(string msg): base(msg)
        {

        }
    }
}
