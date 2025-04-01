using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6
{
    internal class Program
    {
        static void Main()
        {
            Stack<Person> person = new Stack<Person>(4);
            person.Push(new Person("Артем", 26));
            person.Push(new Person("Иван", 27));
            person.Push(new Person("Кристина", 20));
            person.Push(new Person("Марина", 21));

            Console.WriteLine("До сортировки: ");
            foreach (var p in person)
            {
                Console.WriteLine(p);
            }

            person.Sort();

            Console.WriteLine("\nПосле сортировки: ");
            //foreach (var p in person)
            //{
            //    Console.WriteLine(p);
            //}
          
            for (IEnumerator i = person.GetEnumerator(); i.MoveNext();)
            {
                Console.WriteLine(i.Current);
            }

          

            Stack<Product> product = new Stack<Product>(4);
            product.Push(new Product("Ноутбук", (decimal)75999.9));
            product.Push(new Product("Рюкзак", (decimal)5499.9));
            product.Push(new Product("Зарядка", (decimal)999.9));
            product.Push(new Product("Мышь", (decimal)3299.9));

            Console.WriteLine("\nДо сортировки:");
            foreach (var p in product)
            {
                Console.WriteLine(p);
            }

            product.Sort();

            Console.WriteLine("\nПосле сортировки:");
            foreach (var p in product)
            {
                Console.WriteLine(p);
            }

            var person1 = new Person("Иван", 35);
            var person2 = new Person("Артем", 25);


            int result = person1.CompareTo(person2);
            Console.WriteLine(result);

        }

    }

    //Реализация IEnumerable в классе Stack
    public class Stack<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] list;
        private int size;
        private int currentSize = 0;

        public Stack(int size)
        {
            if (size <= 0)
            {
                throw new ExceptionSize("Недопустимый размер: размер стека должен быть больше нуля.");
            }

            this.size = size;
            list = new T[size];
        }

        public void Push(T value)
        {
            if (currentSize >= size)
            {
                throw new ExceptionOverflow("Переполнение стека: невозможно добавить элемент в стек.");
            }

            list[currentSize] = value;
            currentSize++;
        }

        public void Pop()
        {
            if (currentSize <= 0)
            {
                throw new ExceptionUnderflow("Стек пуст: невозможно извлечь из пустого стека.");
            }

            currentSize--;
            list[currentSize] = default(T);
        }

        public T Find(int index)
        {
            if (index < 0 || index >= currentSize)
            {
                throw new ExceptionInvalidIndex("Неверный индекс: индекс выходит за пределы.");
            }

            return list[index];
        }

        public void Print()
        {
            for (int i = 0; i < currentSize; i++)
            {
                Console.WriteLine($"{list[i]}, ");
            }
            Console.WriteLine();
        }
        public void Sort()
        {
            Array.Sort(list, 0, currentSize); // метод Array.Sort сортирует массив list, начиная с 0 индекса.
        }
        public IEnumerator<T> GetEnumerator()// Класс, реализующий интерфейс IEnumerable(а именно – метод
                                            // IEnumerator GetEnumerator() ) может быть поэлементно обработан внутри цикла foreach.
        {
            return new StackEnumerator<T>(list, currentSize);
        }
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator(); // возвращает экз класса StackEnumerator
        }
    }
    public class StackEnumerator<T> : IEnumerator<T> //Для перебора эл. коллекции
    {
        private T[] list;
        private int currentSize;
        private int position = -1;

        public StackEnumerator(T[] list, int currentSize)
        {
            this.list = list;
            this.currentSize = currentSize;
        }
        public T Current
        {
            get
            {
                if (position < 0 || position >= currentSize)
                    throw new InvalidOperationException();
                return list[position];
            }
        }
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            position++; //True если есть след. элемент
            return (position < currentSize); //False если достигли конца коллекции
        }
        public void Reset()
        {
            position = -1; //сбрасывает итератор на начальное положение
        }
        public void Dispose() { } //Этот метод используется для освобождения
                                  //ресурсов, если они есть

    }
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"{Name} {Age} y.o.";
        }
    }
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(Product other)
        {
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Name}: {Price}$";
        }
    }

    // Базовый класс
    public class VolumeException : Exception
    {
        public VolumeException(string message) : base(message) { }
    }

    // Исключение при попытке положить в переполненный стек
    public class ExceptionOverflow : VolumeException
    {
        public ExceptionOverflow(string message) : base(message) { }
    }

    // Исключение при попытке достать из пустого стека
    public class ExceptionUnderflow : VolumeException
    {
        public ExceptionUnderflow(string message) : base(message) { }
    }

    // Исключение при попытке обратиться по неверному индексу
    public class ExceptionInvalidIndex : Exception
    {
        public ExceptionInvalidIndex(string message) : base(message) { }
    }

    // Базовый класс иcключения, возникающего в конструкторе 
    public class ExceptionConstructor : Exception
    {
        public ExceptionConstructor(string message) : base(message) { }
    }

    // Исключение при попытке задать неверный размер контейнерного класса
    public class ExceptionSize : ExceptionConstructor
    {
        public ExceptionSize(string message) : base(message) { }
    }

    // Исключения при неверном диапазоне цифр, входящий в стек
    public class ExceptionRange : ExceptionConstructor
    {
        public ExceptionRange(string message) : base(message) { }
    }

}