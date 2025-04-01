using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class ExpressionConverter
    {
        //Метод для получение приоритета оператора
        private static int GetPrecedence(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            if (op == "!") return 3;//добавить приоритет ! и чтобы вычилял 30-50
            return 0; //скобка или неизвестный символ            
        }
        //Метод преобразования инфиксного выражения в постфиксное
        public static string InfixToPostfix(string infix)
        {
            var tokens = Tokenize(infix); // Разбиваем строку на токены
            var operators = new Stack<string>(); // Стек для операторов
            var output = new List<string>(); // Список для постфиксного выражения

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _)) // Если токен — число
                {
                    output.Add(token);
                }
                else if (token == "(") // Открывающая скобка
                {
                    operators.Push(token);
                }
                else if (token == ")") // Закрывающая скобка
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }
                    if (operators.Count == 0 || operators.Pop() != "(")
                    {
                        throw new InvalidOperationException("Несоответствие скобок");
                    }
                }               
                else // Если токен — оператор
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(token))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
            }
            // Переносим оставшиеся операторы из стека
            while (operators.Count > 0)
            {
                var op = operators.Pop();
                if (op == "(")
                {
                    throw new InvalidOperationException("Несоответствие скобок");
                }
                output.Add(op);
            }
            return string.Join(" ", output);
        }
        //для разбиения инф. строки на отдельные токены (числа, операторы, скобки)
        private static List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            int i = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                if (char.IsDigit(c) || (c == '-' && (i == 0 || "+-*/(".Contains(tokens.Count > 0 ? tokens[tokens.Count - 1]: "(")))) //Отрицательное число
                {
                    string number = "";
                    if(c == '-')
                    {
                        number += c;
                        i++;
                    }
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number += expression[i];
                        i++;
                    }
                    tokens.Add(number);
                }
                else if (c == '!')
                {
                    //Если оператор факториал стоит перед числом 
                    if (tokens.Count == 0 || (!char.IsDigit(tokens[tokens.Count - 1][0]) && tokens[tokens.Count - 1] != ")"))
                    {
                        throw new InvalidOperationException("Факториал должен следовать за числом или за закрывающейся скобкой");
                    }
                    tokens.Add("!");
                    i++;
                }
                else if ("+-*/()".Contains(c)) // Если оператор или скобка
                {
                    tokens.Add(c.ToString());
                    i++;
                }
                else
                {
                    throw new InvalidOperationException($"Некорректный символ в выражении: {c}");
                }
            }
            return tokens;
        }
    }
}
