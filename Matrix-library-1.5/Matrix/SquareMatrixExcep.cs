using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrixExcep : Exception
    {
        public SquareMatrixExcep(string message)
            : base(message)
        { }
    }
}
