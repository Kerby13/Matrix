using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   class MathCalculator<T> : IMathCalculator<T>
    {
        //public delegate T MathOperation(T n1, T n2);

        //public class Calculator
        //{
        //    public static Dictionary<string, MathOperation> numberCalculator = new Dictionary<string, MathOperation>
        //    {
        //        {"+", Sum },
        //        {"-", Div },
        //        {"*", Mul },
        //        {"/", Sub }
        //    };

        //    public static Dictionary<string, MathOperation> symbolsCalculator = new Dictionary<string, MathOperation>
        //    {
        //        {"+", Sum }
        //    };
        //}

        public T Add(T n1, T n2)
        {
            throw new NotImplementedException();
        }

        public T Div(T n1, T n2)
        {
            throw new NotImplementedException();
        }

        public T Mul(T n1, T n2)
        {
            throw new NotImplementedException();
        }

        public T Sub(T n1, T n2)
        {
            throw new NotImplementedException();
        }
    }
}
