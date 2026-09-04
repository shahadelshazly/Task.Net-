using System;

namespace task6
{
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x)
        {
            X = x;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class TypeA
    {
        private int F = 10;
        internal int G = 20;
        public int H = 30;
        public void PrintF()
        {
            Console.WriteLine("Private F :" + F);
        }
    }
    struct Employee
    {
        private int EmpId;
        private string Name;
        private double Salary;
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public int ID
        {
            get { return EmpId; }
            set { EmpId = value; }
        }
        public double EmployeeSalary
        {
            get { return Salary; }
            set { Salary = value; }
        }
    }
    class EmployeeClass
    {
        public string Name;
    }
    internal class Program
    {
        static void ModifyStruct(Point p)
        {
            p.X = 500;
        }
        static void ModifyClass(EmployeeClass e)
        {
            e.Name = "Omar";
        }
        static void Main(string[] args)
        {
            #region problem1
            Point P1 = new Point();
            Point P2 = new Point(5, 10);
            Console.WriteLine("Default :" + P1.ToString());
            Console.WriteLine("Parameterized :" + P2.ToString());
            #endregion

            #region problem2
            TypeA ObjA = new TypeA();
            ObjA.PrintF();
            Console.WriteLine("Internal G :" + ObjA.G);
            Console.WriteLine("Public H :" + ObjA.H);
            #endregion

            #region problem3
            Employee Emp = new Employee();
            Emp.ID = 1;
            Emp.SetName("Shaban");
            Emp.EmployeeSalary = 5000;
            Console.WriteLine("ID :" + Emp.ID);
            Console.WriteLine("Name :" + Emp.GetName());
            Console.WriteLine("Salary :" + Emp.EmployeeSalary);
            #endregion

            #region problem4
            Point P3 = new Point(7);
            Point P4 = new Point(15, 25);
            Console.WriteLine("X only :" + P3.ToString());
            Console.WriteLine("X and Y :" + P4.ToString());
            #endregion

            #region problem5
            Point P5 = new Point(99, 100);
            Console.WriteLine("Custom Format :" + P5.ToString());
            #endregion

            #region problem6
            Point ValPoint = new Point(10, 10);
            ModifyStruct(ValPoint);
            Console.WriteLine("Struct Value :" + ValPoint.X);

            EmployeeClass RefEmp = new EmployeeClass();
            RefEmp.Name = "Ali";
            ModifyClass(RefEmp);
            Console.WriteLine("Class Value :" + RefEmp.Name);
            #endregion
        }
    }
}


