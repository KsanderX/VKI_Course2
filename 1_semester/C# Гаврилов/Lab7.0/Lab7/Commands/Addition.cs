using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Commands
{
    public class Addition : IOperator
    {
        public double Apply(double a, double b) => a + b;
    }
}
