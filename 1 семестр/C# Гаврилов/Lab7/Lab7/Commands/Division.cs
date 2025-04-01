using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Commands
{
    public class Division : IOperator
    {
        public double Apply(double a,  double b)
        {
            if (b == 0) throw new DivisionByZeroException();
            return a / b;
        }
    }
}
