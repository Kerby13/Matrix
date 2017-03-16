using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class WrongOperationException : Exception
    {
        public WrongOperationException(string message)
            : base(message)
        { }
    }
}
