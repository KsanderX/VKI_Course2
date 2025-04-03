namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVL tree = new AVL();
            AVL tree2 = new AVL();
            tree.Add(5);
            tree.Add(3);
            tree.Add(11);
            tree.Add(8);
            tree.Add(1);
            tree.OutpOnConsoleTree();

            tree2.Add(3);
            tree2.Add(3);
            tree2.Add(2);
            tree2.Add(10);
            tree2.Add(8);
            tree2.Add(9);
            tree2.OutpOnConsoleTree();

            int num = 4;
            AVL result = tree2 + num;
            Console.WriteLine($"Сложение числа {num} и дерева:");
            result.OutpOnConsoleTree();


            AVL result2 = tree + tree2;
            Console.WriteLine("Сложение деревьев:");
            result2.OutpOnConsoleTree(); 
            
           

            // Пример для Л-Дерево + Р-Дерево
            
            AVL leftTree = new AVL();
            leftTree.Add(1);
            leftTree.Add(3);
            leftTree.Add(4);
            leftTree.Add(5);
            leftTree.OutpOnConsoleTree();

            AVL rightTree = new AVL();
            rightTree.Add(7);
            rightTree.Add(8);
            rightTree.Add(10);
            rightTree.Add(15);    
            rightTree.OutpOnConsoleTree();

            AVL sortedMerge = leftTree + rightTree;
            Console.WriteLine("Результат сложения Л-Дерева и Р-Дерева:");
            sortedMerge.OutpOnConsoleTree(); 
        }
    }

    class AVL
    {
        public void OutpOnConsoleTree()
        {
            Console.Write("AVL дерево: ");
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
        public Node root;
        public AVL() // инициализирует корень дерева как null
        {
        }


        //метод для сложения дерева и числа
        public static AVL operator +(AVL tree, int number)
        {
            tree.Add(number);
            return tree;
            //AVL result = new AVL(); сложение дерева и числа, создавая копию дерева
            //foreach (var value in tree.Traverse())
            //{
            //    result.Add(value);
            //}
            //result.Add(number);
            //return result;
        }

        // Перегрузка оператора для сложения двух деревьев
        public static AVL operator +(AVL leftTree, AVL rightTree)
        {
            if (leftTree.root == null) return rightTree; //Если левоедерево пустое
            if (rightTree.root == null) return leftTree;//Если правое дерево пустое

            // Проверка на выполнение условия: все ключи leftTree <= все ключи rightTree
            int maxLeft = leftTree.Traverse().Max();
            int minRight = rightTree.Traverse().Min();

            if (maxLeft <= minRight)
            {
                //Выполнение алгоритма слияния
                return MergeSortedTrees(leftTree, rightTree);
            }
            else
            { 
                //Условие не выполняется, используем общий алгоритм слияния
                return MergeTrees(leftTree, rightTree);
            }
        }

        // Алгоритм слияния Л-Дерева и Р-Дерева
        private static AVL MergeSortedTrees(AVL t1, AVL t2)
        {
            if (t1.root == null) return t2;
            if (t2.root == null) return t1;

            //AVL result = new AVL();

            // В дереве T1 находим самый правый(наибольший) узел.
            int maxNodeT1 = t1.Traverse().Max();
            t1.Delete(maxNodeT1); // Отделяем узел x (наибольший) от дерева T1.

            // В дереве T2 находим левое поддерево, высота которого равна высоте T1.
            AVL.Node leftSubTreeT2 = FindSubtreeWithHeight(t2.root, GetHeight(t1.root));

            //Формируем новое дерево 
            AVL.Node newRoot = new AVL.Node(maxNodeT1)
            {
                left = t1.root, //левое поддерево - остаток Л-дерева
                right = leftSubTreeT2 // Правое поддерево - ннайденное подерево Р-дерева
            };
           

            //Подключаем новое дерево на место удаленного поддерева
            t2.root = AttachSubtree(t2.root, newRoot, GetHeight(newRoot));

           
            return t2;
        }
        // Метод нахождения поддерева с заданной высотой
        private static AVL.Node FindSubtreeWithHeight(AVL.Node node, int targetHeight)
        {
            if (node == null) return null;

            int currentHeight = GetHeight(node.left);
            if(currentHeight == targetHeight)
            {
                return node.left;
            }
            else if (currentHeight > targetHeight)
            {
                return FindSubtreeWithHeight(node.left, targetHeight);
            }
            else
            {
                return FindSubtreeWithHeight(node.right, targetHeight - currentHeight - 1); 
            }          
        }

        // Общий метод слияния деревьев
        private static AVL MergeTrees(AVL t1, AVL t2)
        {
            AVL result = new AVL();

            //Добавляем все элементы из обоих деревьев
            foreach (var value in t1.Traverse())
            {
                result.Add(value);
            }
            foreach (var value in t2.Traverse())
            {
                result.Add(value);
            }
            return result;
        }
        //Подключение нового дерева S в Р-дерево
        private static AVL.Node AttachSubtree(AVL.Node node, AVL.Node newSubtree, int targetHeight)
        {
            if (node == null) return newSubtree;
            int leftHeight = GetHeight(node.left);
            if(leftHeight == targetHeight)
            {
                node.left = newSubtree;
            }
            else if (leftHeight > targetHeight)
            {
                node.left = AttachSubtree(node.left, newSubtree, targetHeight);
            }
            else
            {
                node.right = AttachSubtree(node.right, newSubtree, targetHeight - leftHeight -1);
            }
            return node;
        }

        // Метод для вычисления высоты дерева
        private static int GetHeight(AVL.Node node)
        {
            if (node == null) return 0;
            return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }           

        //метод для обхода дерева и получение значений в инфиксном порядке
        public IEnumerable<int> Traverse()
        {
            return Traverse(root);// вызывает корень root в качестве аргумента
        }
        private IEnumerable<int> Traverse(Node current)
        {
            if (current != null) // в этом случае просто закан. работу
            {
                foreach (var leftValue in Traverse(current.left)) //рекурс. обход лев части дерева
                {
                    yield return leftValue; //yield не возвращает сразу, а создает итератор
                } /*возвращает элементы по одному*/
                yield return current.data; // возвращает элемент
                foreach (var rightValue in Traverse(current.right))
                {
                    yield return rightValue;
                }
            }
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
            else if (data.data < current.data)
            {
                current.left = Insert(current.left, data); //вставка происходит в левое поддерево               
            }
            else if (data.data > current.data)
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