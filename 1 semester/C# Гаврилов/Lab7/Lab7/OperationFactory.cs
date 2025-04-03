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
        public interface IOperation
        {
            void Apply(Stack<double> stack);
        }
        public class Factorial : IOperation
        {
            public void Apply(Stack<double> stack)
            {
                double n = stack.Pop();
                if (n < 0 || n != Math.Floor(n))
                    throw new InvalidOperationException("Фаториал определен только для неотрицатлеьных чисел");

                double result = 1;
                for (int i = 1; i <= (int)n; i++)
                {
                    result *= i;
                }
                stack.Push(result);
            }
        }
        public class Addition : IOperation
        {
            public void Apply(Stack<double> stack)
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(a + b);
            }
        }
        public class Subtraction : IOperation
        {
            public void Apply(Stack<double> stack)
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(a - b);
            }
        }
        public class Multiplication : IOperation
        {
            public void Apply(Stack<double> stack)
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(a * b);
            }
        }
        public class Division : IOperation
        {
            public void Apply(Stack<double> stack)
            {
                double b = stack.Pop();
                double a = stack.Pop();

                if (b == 0) throw new DivisionByZeroException();

                stack.Push(a / b);

            }
        }
    }

}
