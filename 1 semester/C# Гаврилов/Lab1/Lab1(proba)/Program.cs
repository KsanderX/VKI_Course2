using System;
using System.Numerics;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            Console.WriteLine("Содержимое стека: "); stack.Print();
            Console.WriteLine("Извлечен элемент: " + stack.Pop());
            Console.WriteLine("Верхний элемент: " + stack.Peek());
            Console.WriteLine("Cреднее арифметическое стека: " + stack.GetAverage());
            Stack<int> stackcopy = new Stack<int>(stack);
            stack.Pop();
            Console.WriteLine("Копия стека: ");
            stackcopy.Print();
        }
    }
    public class Stack<T> where T : INumber<T>
    {
        private List<T> list; // для хранения эл стека
        private int maxSize; // для хранения макс размера стека
        private double sum; // Сумма элементов стека
        private int count; // Количество элементов в стеке

        // Конструктор для создания стека
        public Stack(int size)
        {
            maxSize = size;
            list = new List<T>(size); // задает максимальный размер стека
            sum = 0; // Инициализируем sum
            count = 0; // Инициализируем count
        }
        // Конструктор для создания копии другого стека
        public Stack(Stack<T> other)
        {
            maxSize = other.maxSize;
            list = new List<T>(other.maxSize);
            sum = other.sum; // Копируем sum
            count = other.count; // Копируем count
            // Инициализируем индекс для счётчика
            for (int i = 0; i < other.list.Count; i++)
            {
                this.Push(other.list.GetItem(i)); // Копируем элементы, используя метод
            }
        }
        // Метод для добавления элемента (push)
        public void Push(T item)
        {
            try
            {
                if (list.Count >= maxSize)
                {
                    throw new InvalidOperationException("Stack переполнен"); // проверка на переполненность
                }
                list.Add(item);
                sum += Convert.ToDouble(item); // Обновляем sum при добавлении
                count++; // Обновляем count при добавлении
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        // Метод для извлечения элемента (pop)
        public T Pop()
        {
            try
            {
                if (list.Count == 0)
                {
                    throw new InvalidOperationException("Stack пустой"); // проверка, не пуст ли
                }
                T removedItem = list.Remove();
                sum -= Convert.ToDouble(removedItem); // Обновляем sum при удалении
                count--; // Обновляем count при удалении
                return removedItem;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ошибка " + ex.Message);
                return default(T); // возвращаем значение по умолчанию
            }
        }
        // Метод для возврата элемента без его удаления (peek)
        public T Peek()
        {
            try
            {
                if (list.Count == 0)
                {
                    throw (new InvalidOperationException("Stack пустой"));
                }
                return list.Peek();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ошибка " + ex.Message);
                return default(T);
            }
        }
        // Метод для печати содержимого стека
        public void Print()
        {
            list.Print();
        }
        // Метод для вычисления среднего арифметического элементов стека
        public double GetAverage()
        {
            try
            {
                if (count == 0)
                {
                    throw new InvalidOperationException("Stack пустой");
                }
                return sum / count; // Возвращаем среднее, используя sum и count
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ошибка " + ex.Message);
                return 0; // Возвращаем 0 в случае ошибки
            }
        }    
    }  
}