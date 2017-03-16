using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DifferentSizeException : Exception
    {
        public DifferentSizeException(string message)
            : base(message)
        { }
    }
}
