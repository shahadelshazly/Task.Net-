using System;
using System.Collections.Generic;

namespace Task8
{
    public interface IVehicle
    {
        void StartEngine();
        void StopEngine();
    }

    public class Car : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Car engine started.");
        }
        public void StopEngine()
        {
            Console.WriteLine("Car engine stopped.");
        }
    }

    public class Bike : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Bike engine started.");
        }
        public void StopEngine()
        {
            Console.WriteLine("Bike engine stopped.");
        }
    }
    public abstract class ShapeAbstract
    {
        public abstract double GetArea();
        public void Display()
        {
            Console.WriteLine("Displaying shape details.");
        }
    }

    public class RectangleShape : ShapeAbstract
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double GetArea()
        {
            return Width * Height;
        }
    }

    public class CircleShape : ShapeAbstract
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}";
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }

        public Student(int id, string name, string grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
        public Student(Student other)
        {
            Id = other.Id;
            Name = (string)other.Name.Clone();
            Grade = (string)other.Grade.Clone();
        }
    }
    public interface IWalkable
    {
        void Walk();
    }

    public class Robot : IWalkable
    {
        public void Walk()
        {
            Console.WriteLine("Robot walking using standard method.");
        }
        void IWalkable.Walk()
        {
            Console.WriteLine("Robot walking via IWalkable explicit interface.");
        }
    }
    public struct Account
    {
        private int AccountId;
        private string AccountHolder;
        private double Balance;

        public int ID
        {
            get { return AccountId; }
            set { AccountId = value; }
        }

        public string Holder
        {
            get { return AccountHolder; }
            set { AccountHolder = value; }
        }

        public double AccountBalance
        {
            get { return Balance; }
            set { if (value >= 0) Balance = value; }
        }

        public void DisplayAccount()
        {
            Console.WriteLine($"Acc ID: {AccountId}, Holder: {AccountHolder}, Balance: {Balance}");
        }
    }
    public interface ILogger
    {
        void Log()
        {
            Console.WriteLine("Default Logger Implementation.");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Overridden Console Logger Implementation.");
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book()
        {
            Title = "Unknown";
            Author = "Unknown";
        }

        public Book(string title)
        {
            Title = title;
            Author = "Unknown";
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public void DisplayBook()
        {
            Console.WriteLine($"Book Title: {Title}, Author: {Author}");
        }
    }

    public interface IShapeSeries
    {
        int CurrentShapeArea { get; set; }
        void GetNextArea();
        void ResetSeries();
    }

    public class SquareSeries : IShapeSeries
    {
        private int side = 1;
        public int CurrentShapeArea { get; set; }

        public void GetNextArea()
        {
            CurrentShapeArea = side * side;
            side++;
        }

        public void ResetSeries()
        {
            side = 1;
            CurrentShapeArea = 0;
        }
    }

    public class CircleSeries : IShapeSeries
    {
        private int radius = 1;
        public int CurrentShapeArea { get; set; } 

        public void GetNextArea()
        {
            CurrentShapeArea = (int)(Math.PI * radius * radius);
            radius++;
        }

        public void ResetSeries()
        {
            radius = 1;
            CurrentShapeArea = 0;
        }
    }

    public class ShapeSortable : IComparable<ShapeSortable>
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public int CompareTo(ShapeSortable other)
        {
            return Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return $"{Name} with Area: {Area}";
        }
    }

    public abstract class GeometricShape
    {
        public double Dimension1 { get; set; }
        public double Dimension2 { get; set; }

        public abstract double CalculateArea();
        public abstract double Perimeter { get; }
    }

    public class Triangle : GeometricShape
    {
        public override double CalculateArea()
        {
            return 0.5 * Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get { return Dimension1 + Dimension2 + Math.Sqrt((Dimension1 * Dimension1) + (Dimension2 * Dimension2)); }
        }
    }

    public class RectangleGeo : GeometricShape
    {
        public override double CalculateArea()
        {
            return Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get { return 2 * (Dimension1 + Dimension2); }
        }
    }

    public class ShapeFactory
    {
        public static GeometricShape CreateShape(string shapeType, double dim1, double dim2)
        {
            if (shapeType.ToLower() == "triangle")
            {
                return new Triangle { Dimension1 = dim1, Dimension2 = dim2 };
            }
            else if (shapeType.ToLower() == "rectangle")
            {
                return new RectangleGeo { Dimension1 = dim1, Dimension2 = dim2 };
            }
            return null;
        }
    }

    internal class Program
    {
        static void PrintTenShapes(IShapeSeries series)
        {
            series.ResetSeries();
            for (int i = 0; i < 10; i++)
            {
                series.GetNextArea();
                Console.WriteLine("Shape Area in Series: " + series.CurrentShapeArea);
            }
        }

        public static void SelectionSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }
        }

        static void Main(string[] args)
        {
            #region problem1
            Console.WriteLine("--- Problem 1: Interface IVehicle ---");
            IVehicle myCar = new Car();
            myCar.StartEngine();
            myCar.StopEngine();
            #endregion

            #region problem2
            Console.WriteLine("\n--- Problem 2: Abstract Class Shape ---");
            RectangleShape rect = new RectangleShape { Width = 5, Height = 4 };
            rect.Display();
            Console.WriteLine("Rectangle Area: " + rect.GetArea());
            #endregion

            #region problem3
            Console.WriteLine("\n--- Problem 3: IComparable Product ---");
            Product[] products = {
                new Product { Id = 1, Name = "Laptop", Price = 1200 },
                new Product { Id = 2, Name = "Mouse", Price = 25 }
            };
            Array.Sort(products);
            Console.WriteLine("Sorted Product: " + products[0].Name);
            #endregion

            #region problem4
            Console.WriteLine("\n--- Problem 4: Copy Constructor ---");
            Student s1 = new Student(1, "Shaban", "A");
            Student s2 = new Student(s1); // Deep copy
            Console.WriteLine("Copied Student Name: " + s2.Name);
            #endregion

            #region problem5
            Console.WriteLine("\n--- Problem 5: Explicit Interface Implementation ---");
            Robot bot = new Robot();
            bot.Walk(); // Calls class method
            IWalkable walkableBot = bot;
            walkableBot.Walk(); // Calls explicit interface method
            #endregion

            #region problem6
            Console.WriteLine("\n--- Problem 6: Encapsulation in Struct ---");
            Account acc = new Account();
            acc.ID = 1001;
            acc.Holder = "Shaban Sayed";
            acc.AccountBalance = 5000;
            acc.DisplayAccount();
            #endregion

            #region problem7
            Console.WriteLine("\n--- Problem 7: Default Interface Implementation ---");
            ILogger logger = new ConsoleLogger();
            logger.Log();
            #endregion

            #region problem8
            Console.WriteLine("\n--- Problem 8: Constructor Overloading in Book ---");
            Book b1 = new Book();
            Book b2 = new Book("C# Programming");
            Book b3 = new Book("Advanced C#", "John Doe");
            b3.DisplayBook();
            #endregion

            #region Part02_ShapeSeries
            Console.WriteLine("\n--- Part 02: Shape Series Test ---");
            IShapeSeries squareSeries = new SquareSeries();
            PrintTenShapes(squareSeries);
            #endregion

            #region Part02_SortingShapes
            Console.WriteLine("\n--- Part 02: Sorting Shapes ---");
            ShapeSortable[] shapeList = {
                new ShapeSortable { Name = "Square", Area = 25.5 },
                new ShapeSortable { Name = "Circle", Area = 12.3 }
            };
            Array.Sort(shapeList);
            Console.WriteLine("Sorted Shape 1: " + shapeList[0]);
            #endregion

            #region Part02_SelectionSort
            Console.WriteLine("\n--- Part 02: Custom Selection Sort ---");
            int[] nums = { 45, 12, 78, 3 };
            SelectionSort(nums);
            Console.WriteLine("Sorted array first element: " + nums[0]);
            #endregion
        }
    }
}



