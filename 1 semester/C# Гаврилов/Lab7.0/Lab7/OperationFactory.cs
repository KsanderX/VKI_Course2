using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class OperationFactory
    {
        public static IOperation CreateOperator(string symbol)
        {
            return symbol switch
            {
                "+" => new Addition(),
                "-" => new Subtraction(),
                "*" => new Multiplication(),
                "/" => new Division(),
                "!" => new Factorial(),            
                _ => throw new ArgumentException("Неизвестный оператор")
            }; 
        }
    }

}
