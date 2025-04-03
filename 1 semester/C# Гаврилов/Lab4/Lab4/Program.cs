using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Threading.Channels;
class Program
{
    static void Main(string[] args)
    {
        Point point1 = new Point(1, 3);
        Point point2 = new Point(4, 7);
        Point point3 = new Point(3, 1);


        Figure point = new Point(1,1);

        Circle circle = new Circle(5, 1, 2);

        Figure line = new Line(point1, point2);

        Triangle triangle = new Triangle(point1, point2, point3);

        Figure[] collection = new Figure[5];
        collection[0] = line;
        collection[1] = point;
        collection[2] = circle;
        collection[3] = triangle;
        for (int i = 0; i < collection.Length -1; i++)
        {
            Console.WriteLine($"Имя: {collection[i].name}");
            collection[i].GetSize();
            collection[i].CoordinatesToConsoleOutput();
            Console.WriteLine();
        }
        
        Figure figure = triangle;
        figure.GetSize();
    }
}
public abstract class Figure
{
    public string? name;
    public virtual double GetSize() //для переопределения
    {
        return 0;
    }
    public abstract void CoordinatesToConsoleOutput();
}
public class Point : Figure
{
    protected double x;
    protected double y;
    public Point(double x, double y)
    {
        name = "Точка";
        this.x = x;
        this.y = y;
    }
    public double GetX
    {
        get { return x; }
    }
    public double GetY
    {
        get { return y; }
    }
    public override double GetSize()
    {
        return 0;
    }
    public override void CoordinatesToConsoleOutput()
    {
        Console.WriteLine($"Координаты точки: {x}, {y}");
    }
}

public class Line : Figure
{
    public Point point1; // первая точка
    public Point point2; // вторая точка
    public Line(Point start, Point end) 
    {
        name = "Линия";
        point1 = start;
        point2 = end;
    }
    public override double GetSize() //AB = √(x2 - x1)2 + (y2 - y1)2
    {
        double result = Math.Sqrt(Math.Pow(point2.GetX - point1.GetX, 2) + Math.Pow(point2.GetY - point1.GetY, 2));
        Console.WriteLine($"Длина линии: {result} ");
        return result;
    }
    public override void CoordinatesToConsoleOutput()
    {
        Console.WriteLine($"Координаты точек линии: "
        + $"({point1.GetX}, {point1.GetY}),"
        + $"({point2.GetX}, {point2.GetY})");
    }
}
public class Circle : Point  //метод который называется по имени класса, который может иметь параметры
{
    private double radius; 
    public Circle(double radius, double x, double y) : base(x, y)//констр circle вызыв. констр base class Point
    {                                                //передавая x и y для инициализации координат круга
        name = "Круг";                          
        this.radius = radius; //конструктор принимает радиус и координаты круга из базового класса Point
    }
    public override double GetSize()
    {
        double result = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine($"Площадь: {result} ");
        return result;
    }
    public override void CoordinatesToConsoleOutput()
    {
        Console.WriteLine($"Координаты круга: {GetX}, {GetY}");
    }
}

public class Triangle : Figure
{
    private Point vertex1;
    private Point vertex2;
    private Point vertex3;

    public Triangle(Point point1, Point point2, Point point3)
    {
        name = "Треугольник";
        vertex1 = point1;//вершины
        vertex2 = point2;
        vertex3 = point3;
    }
    public override double GetSize()
    {
        double side1 = Math.Sqrt(Math.Pow(vertex2.GetX - vertex1.GetX, 2) + Math.Pow(vertex2.GetY - vertex1.GetY, 2));
        double side2 = Math.Sqrt(Math.Pow(vertex3.GetX - vertex2.GetX, 2) + Math.Pow(vertex3.GetY - vertex2.GetY, 2));
        double side3 = Math.Sqrt(Math.Pow(vertex1.GetX - vertex3.GetX, 2) + Math.Pow(vertex1.GetY - vertex3.GetY, 2));
        double result = side1 + side2 + side3; //Периметр треугольника
        Console.WriteLine($"Периметр: {result} ");
        return result;
    }
    public override void CoordinatesToConsoleOutput()
    {
        Console.WriteLine($"Координаты: "
        + $"({vertex1.GetX}, {vertex1.GetY}), "
        + $"({vertex2.GetX}, {vertex2.GetY}), "
        + $"({vertex3.GetX}, {vertex3.GetY})");
    }
}