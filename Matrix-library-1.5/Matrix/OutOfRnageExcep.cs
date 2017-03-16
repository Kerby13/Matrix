using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class OutOfRangeExcep : Exception
    {
        public OutOfRangeExcep(string message)
            : base(message)
        { }
    }
}
