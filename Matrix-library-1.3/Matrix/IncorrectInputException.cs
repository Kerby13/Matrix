using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class IncorrectInputException : Exception
    {
        public IncorrectInputException(string message)
            : base(message)
        { }
    }
}
