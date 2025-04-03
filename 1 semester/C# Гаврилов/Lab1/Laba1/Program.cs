using System;
using System.Numerics;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace Laba1
{
    public class Program
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            stack.Push(10);
            stack.Push(11);
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
    public class Stack<T> where T : INumber<T> // Ограничение INumber
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
            if (list.Count < maxSize) // Проверка на переполнение
            {
                list.Add(item);
                sum += Convert.ToDouble(item); // Обновляем sum при добавлении
                count++; // Обновляем count при добавлении
            }
            else
            {
                Console.WriteLine("Stack переполнен"); // Выводим сообщение
            }
        }
        // Метод для извлечения элемента (pop)
        public T Pop()
        {
            if (list.Count > 0) // Проверка на пустоту
            {
                T removedItem = list.Remove();
                sum -= Convert.ToDouble(removedItem); // Обновляем sum при удалении
                count--; // Обновляем count при удалении
                return removedItem;
            }
            else
            {
                Console.WriteLine("Stack пустой"); // Выводим сообщение
                return default(T); // Возвращаем значение по умолчанию
            }
        }
        // Метод для возврата элемента без его удаления (peek)
        public T Peek()
        {
            if (list.Count > 0) // Проверка на пустоту
            {
                return list.Peek();
            }
            else
            {
                Console.WriteLine("Stack пустой"); // Выводим сообщение
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
            if (count > 0) // Проверка на пустоту
            {
                return sum / count; // Возвращаем среднее, используя sum и count
            }
            else
            {
                Console.WriteLine("Stack пустой"); // Выводим сообщение
                return 0; // Возвращаем 0 в случае ошибки
            }
        }
    }
}



