namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVL tree = new AVL();
            tree.Add(5);
            tree.Add(3);
            tree.Add(5);
            tree.Add(8);
            tree.Add(1);
            tree.Add(7);
            tree.Add(2);
            tree.Add(9);
            tree.OutpOnConsoleTree();
            tree.Find(7);
            tree.Find(6);
            tree.Delete(7);
            tree.OutpOnConsoleTree();
        }
    }

    class AVL
    {
        public void OutpOnConsoleTree()
        {
            if (root == null)
            {
                Console.WriteLine("");
                return;
            }
            InOrderConsoleTree(root);
            Console.WriteLine();
        }
        private void InOrderConsoleTree(Node current) //инфиксный обход
        {
            if (current != null)
            {
                InOrderConsoleTree(current.left);
                Console.Write("{0} ", current.data);
                InOrderConsoleTree(current.right);
            }
        }
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
                root = newItem; // Если дерево пустое, установим корень
            }
            else
            {
                root = Insert(root, newItem); //иначе вставка в дерево
            }
        }
       
        public Node Insert(Node current, Node data)//рекурсивно вставляет нов узел data, начиная с узла current
        {
            if (current == null)
            {
                return data; 
            }
            else if (data.data <= current.data)
            {
                current.left = Insert(current.left, data); //вставка происходит в левое поддерево               
            }
            else if (data.data >= current.data)
            {
                current.right = Insert(current.right, data);//вставка происходит в правое поддерево               
            }
            return Balance_tree(current);
        }
        private Node Balance_tree(Node current)
        {
            int b_factor = Balance_factor(current);
            if (b_factor > 1)
            {
                if (Balance_factor(current.left) > 0)
                {
                    current = RotateLL(current); //вращение налево
                }
                else
                {
                    current = RotateLR(current); 
                }
            }
            else if (b_factor < -1)
            {
                if (Balance_factor(current.right) > 0)
                {
                    current = RotateRL(current); 
                }
                else
                {
                    current = RotateRR(current);  //вращение вправо
                }
            }
            return current;
        }
        public void Delete(int target) //вызывает рекурсивный метод для
                                       //удаления узла данными target
        {
            root = Delete(root, target); //передает корень и значение для удаления
        }
        private Node Delete(Node current, int target)
        {
            if (current == null)
            {
                return null; // Узел не найден
            }

            if (target < current.data) //поиск в лев поддереве
            {
                current.left = Delete(current.left, target); // Удаление в левом поддереве
            }
            else if (target > current.data) //поиск в прав поддереве
            {
                current.right = Delete(current.right, target); // Удаление в правом поддереве
            }
            else // Узел найден
            {
                // 1. Удаление узла без потомков
                if (current.left == null && current.right == null)
                {
                    return null; // Просто удаляем узел
                }

                // 2. Удаление узла с одним потомком
                if (current.right == null)
                {
                    return current.left; // Заменяем узел его потомком
                }
                if (current.left == null)
                {
                    return current.right; // Заменяем узел его потомком
                }

                // 3. Удаление узла с двумя потомками
                Node parent = current.right;
                while (parent.left != null)
                {
                    parent = parent.left; // Находим inorder-предшественника
                }
                current.data = parent.data; // Копируем значение предшественника
                current.right = Delete(current.right, parent.data); // Удаляем предшественника
            }

            // Балансировка после удаления
            return Balance_tree(current);
        }
        public void Find(int key) //для поиска узла с заданным ключом
        {
            var result = Find(key, root);
            if (result != null)
            {
                Console.WriteLine($"Элемент {key} был найден.");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }
        }
        public Node Find(int target, Node current)
        {
            if (current == null)
            {
                return null;
            }
            if (target < current.data)
            {
                return Find(target, current.left);//продолжаем искать в левом поддереве
            }
            else if (target > current.data)
            {
                return Find(target, current.right);//продолжаем искать в правом поддереве
            }
            else
            {
                return current; //узел найден
            }
        }

        private int max(int l, int r) //для вращения большего элемента
        {
            return l > r ? l : r;
        }
        private int getHeight(Node current)
        {
            if (current == null)
            {
                return 0;
            }
            int l = getHeight(current.left); //высота левого поддерева
            int r = getHeight(current.right); //высота правого поддерева
            return max(l, r) + 1;         //возвр макс высота между r и l поддер. +1 для тек узла   
        }
        private int Balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r; //balance коэффициент
            return b_factor; // положительное значение означает, что лев поддерево выше
        }
        private Node RotateRR(Node parent) //вращение направо
        {
            Node pivot = parent.right;// правый дочерний узел
            parent.right = pivot.left; // перенаправляем правое поддерево
            pivot.left = parent; // текущий родитель становится левым дочерним узлом
            return pivot; // ново созданный корень
        }
        private Node RotateLL(Node parent) //вращение налево
        {
            Node pivot = parent.left; // левый дочерний узел
            parent.left = pivot.right; // перенаправляем левое поддерево
            pivot.right = parent; // текущий родитель становится правым дочерним узлом
            return pivot; // ново созданный корень
        }
        /*применяется когда новый узел добавляется в правое поддерево левого узла */
        private Node RotateLR(Node parent) // большой лев поворот. вращение направо, затем налево
        {
            Node pivot = parent.left; // сначала поворачиваем Левый правый
            parent.left = RotateRR(pivot);
            return RotateLL(parent); // затем обычный левый поворот
        }

        /* применяется когда новый узел добавляется в левое поддерево правого узла*/
        private Node RotateRL(Node parent) //больой прав поворот. вращение налево, затем направо
        {
            Node pivot = parent.right; // сначала поворачиваем правый левый
            parent.right = RotateLL(pivot);
            return RotateRR(parent); // затем обычный правый поворот
        }
    }
}