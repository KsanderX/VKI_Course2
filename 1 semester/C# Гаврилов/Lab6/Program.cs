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
            person.Print();

            person.Sort();

            Console.WriteLine("После сортировки: ");
            person.Print();

            Stack<Product> product = new Stack<Product>(4);
            product.Push(new Product("Ноутбук", (decimal)75999.9));
            product.Push(new Product("Рюкзак", (decimal)5499.9));
            product.Push(new Product("Зарядка", (decimal)999.9));
            product.Push(new Product("Мышь", (decimal)3299.9));

            Console.WriteLine("До сортировки:");
            product.Print();

            product.Sort();

            Console.WriteLine("После сортировки:");
            product.Print();

            var person1 = new Person("Иван", 35);
            var person2 = new Person("Артем", 35);


            int result = person1.CompareTo(person2);
            Console.WriteLine(result);

        }

        public class Stack<T> where T : IComparable<T>
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
                    throw new ExceptionOverflow("Переполнение стека: невозможно добавить эелемент в стек.");
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
                return $"{Name} {Age}";
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
                return $"{Name}: {Price}";
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
}

