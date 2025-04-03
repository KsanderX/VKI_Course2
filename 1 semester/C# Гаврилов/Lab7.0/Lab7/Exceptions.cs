using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class CalculatorExceptions : Exception
    {
        public CalculatorExceptions(string messege) : base(messege) { }
    }
    public class InvalidExpressionException : CalculatorExceptions 
    {
        public InvalidExpressionException() : base("Некорректное выражение") { }
    }
    public class DivisionByZeroException : CalculatorExceptions
    {
        public DivisionByZeroException() : base("Делить на нуль нельзя") { }
    }

}
