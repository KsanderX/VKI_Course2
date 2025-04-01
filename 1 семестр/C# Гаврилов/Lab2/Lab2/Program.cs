namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class AVL
    {
        public class Node
        {
            public int data;
            public byte height;
            public Node left;
            public Node right;
            public Node(int data)
            {
                this.data = data;
                this.height = 1;
            }
        }
        Node root;
        public AVL() // инициализирует корень дерева как null
        {
        }
        public void Add(int data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = Insert(root, newItem);
            }
        }
        public Node Insert(Node current, Node data)//рекурсивно вставляет нов узел data, начиная с узла current
        {
            if (current == null)
            {
                current = data;//новый узел становится текущим узлом
            }
            else if(data.data < current.data)
            {
                current.left = Insert(current.left, data); //вставка происходит в левое поддерево
                current = Balance_tree(current);// балансировка дерева
            } 
            else if (data.data > current.data)
            {
                current.right = Insert(current.right, data);//вставка происходит в правое поддерево
                current = Balance_tree(current);//балансировка дерева
            }
        }
        private Node Balance_tree(Node current)
        {
            int b_factor = Balance_factor
        }

    }
    

}
