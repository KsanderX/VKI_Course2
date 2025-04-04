using Lab7.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class OperatorFactory
    {
        public static IOperator CreateOperator(string symbol)
        {
            return symbol switch
            {
                "+" => new Addition(),
                "-" => new Subtraction(),
                "*" => new Multiplication(),
                "/" => new Division(),
                _ => throw new ArgumentException("Неизвестный оператор")
            }; 
        }
    }
}
