using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgWorker
{
    public interface IWorkElement
    {
        Exception Error { get; set; }
        string Result { get; }
        object ResultContainer { get; set; }

        void Execute();
    }
}
