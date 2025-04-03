namespace Lab5
{
    internal class Program
    {
        static void Main()
        {
            Stack stack = new Stack(5, 1, 10); // равзмер стека, мин значение, макс значение.

            try
            {
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(5);
                stack.Push(6);
                stack.Push(7);

                stack.Print();
            }
            catch (ExceptionUnderflow ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ExceptionOverflow ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (VolumeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stack.Print();
            }
           
            try
            {
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();

            }
            catch (ExceptionOverflow ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ExceptionUnderflow ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (VolumeException ex) // Барбарa Лискофф
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stack.Print();
            }
            try
            {
                stack.Find(13);
            }
            catch (ExceptionInvalidIndex ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine(stack[6]);
            }
            catch (ExceptionInvalidIndex ex)
            {
                Console.WriteLine(ex.Message);
            }           

            try
            {
                Stack invalidStack = new Stack(-1, 1, 10);
            }
            catch (ExceptionSize ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Stack invalidStack2 = new Stack(5, 10, 1);
            }
            catch (ExceptionRange ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public class Stack 
        {
            private int[] list;
            private int size;
            private int currentSize = 0;
            private int minValue, maxValue;

            public Stack(int size, int minValue, int maxValue)
            {
                if (size <= 0)
                {
                    throw new ExceptionSize("Недопустимый размер: размер стека должен быть больше нуля.");
                }

                if (minValue >= maxValue)
                {
                    throw new ExceptionRange("Недопустимый диапазон: минимальное значение должно быть меньше максимального.");
                }

                this.minValue = minValue;
                this.maxValue = maxValue;
                this.size = size;
                list = new int[size];
            }

            public void Push(int value)
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
                list[currentSize] = 0;
            }

            public int Find(int index)
            {
                if (index < 0 || index >= currentSize)
                {
                    throw new ExceptionInvalidIndex("Неверный индекс: индекс выходит за пределы.");
                }

                return list[index];
            }

            public void Print()
            {
                Console.Write("Элементы стека: ");
                for (int i = 0; i < currentSize; i++)
                {
                    Console.Write($"{list[i]} ");
                }

                Console.WriteLine();
            }

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= currentSize)
                    {
                        throw new ExceptionInvalidIndex("Неверный индекс: индекс выходит за пределы.");
                    }

                    return list[index];
                }
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
