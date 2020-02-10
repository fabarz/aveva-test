using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgWorker
{
    /// <summary>
    /// Work element used for putting into the input queue of the thread worker.
    /// </summary>
    public interface IWorkElement
    {
        Exception Error { get; set; }
        string Result { get; }

        /// <summary>
        /// The form's control that receives the result of this operation.
        /// </summary>
        object ResultContainer { get; set; }

        /// <summary>
        /// Work is done in this method.
        /// </summary>
        void Execute();
    }
}
