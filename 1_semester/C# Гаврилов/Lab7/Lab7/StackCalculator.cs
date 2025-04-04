using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class StackCalculator
    {
        private static readonly StackCalculator instance = new StackCalculator();
        private readonly Stack<double> stack = new Stack<double>();
        private StackCalculator() { }
        public static StackCalculator Instance => instance;
        public double EvaluatePostfix(string expression)
        {
            stack.Clear(); //Ощищаем стек перед началом вычислений
            var tokens = expression.Split(' '); //разюиваем строку на токены

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    // Если токен — число, помещаем его в стек
                    stack.Push(number);
                }               
                else
                {             
                    // Выполняем операцию
                    var operation = OperationFactory.CreateOperator(token);
                    operation.Apply(stack);                 
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Ошибка в выражении. Проверьте корректность записи.");
            }
            return stack.Pop(); //Результат
        }
    }
}
