using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class DivedeByZeroExcep : Exception
    {
        public DivedeByZeroExcep(string message)
            : base(message)
        { }
    }
}
