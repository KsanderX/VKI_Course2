namespace _1_пара
{
    class Node <T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data;
        public Node<T>? Next;

    }
    internal class Program
    {
        public T Pop<T>(T elements, Node<T> top)
        {
            Node<T> temp = top;
            top = top.Next;
            return temp.Data;
        }
        static void Main()
        {
          
        }
    }
}
