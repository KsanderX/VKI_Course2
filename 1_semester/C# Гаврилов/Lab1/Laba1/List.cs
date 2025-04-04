using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public class List<T> // объявляем обобщенный класс
    {
        private T[] items;
        private int count;

        public int Count => count; // свойство, возвращающее кол-во эл в списке       
        public List(int size) // для создания нового списка опр размера
        {
            items = new T[size];
            count = 0;
        }

        public void Add(T item)
        {
            items[count] = item;
            count++;
        }

        public T Remove()
        {
            count--;
            return items[count];
        }

        public T Peek()
        {
            return items[count - 1];
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }

        // Mетод для получения элемента по индексу (для использования в Stack)
        public T GetItem(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("index");
            return items[index];
        }
    }
}