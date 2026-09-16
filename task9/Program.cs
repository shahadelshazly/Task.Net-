using System;
namespace task9

{
    // For Problem 1
    public enum Weekdays
    {
        Monday = 1, Tuesday, Wednesday, Thursday, Friday
    }

    // For Problem 2
    public enum Grades : short
    {
        A = 5, B = 4, C = 3, D = 2, F = 1
    }

    // For Problem 3 & 14
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Department other)
            {
                return DeptId == other.DeptId && DeptName == other.DeptName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeptId, DeptName);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Department PersonDept { get; set; }
    }

    // For Problem 4
    public class Parent
    {
        public virtual double Salary { get; set; }
    }

    public class Child : Parent
    {
        // Sealing the property so no further derived class can override it
        public sealed override double Salary { get; set; }

        public void DisplaySalary()
        {
            Console.WriteLine("Child Salary is: " + Salary);
        }
    }

    // For Problem 5 & 8
    public static class Utility
    {
        public static double PerimeterOfRectangle(double length, double width)
        {
            return 2 * (length + width);
        }

        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }

    // For Problem 6
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber
            {
                Real = (c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary),
                Imaginary = (c1.Real * c2.Imaginary) + (c1.Imaginary * c2.Real)
            };
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    // For Problem 7
    public enum Gender : byte
    {
        Male, Female
    }

    // For Problem 10 & 14
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public Department EmpDept { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return EmpId == other.EmpId && Name == other.Name && object.Equals(EmpDept, other.EmpDept);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmpId, Name, EmpDept);
        }

        public override string ToString()
        {
            return $"Emp: {Name}, Dept: {EmpDept?.DeptName}";
        }
    }

    // For Problem 11
    public class Helper
    {
        public static T Max<T>(T Value1, T Value2) where T : IComparable<T>
        {
            return Value1.CompareTo(Value2) > 0 ? Value1 : Value2;
        }
    }

    // For Problem 10 & 12
    public class Helper2<T>
    {
        public static int SearchArray(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value)) return i;
            }
            return -1; // Not found
        }

        public static void ReplaceArray(T[] array, T oldValue, T newValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(oldValue))
                {
                    array[i] = newValue;
                }
            }
        }
    }

    // For Problem 13
    public struct RectangleStruct
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override string ToString()
        {
            return $"L: {Length}, W: {Width}";
        }
    }

    // For Problem 15
    public struct CircleStruct
    {
        public double Radius { get; set; }
        public string Color { get; set; }
    }

    public class CircleClass
    {
        public double Radius { get; set; }
        public string Color { get; set; }
    }

    // --- Part 02: Generic Problems Definitions ---

    // Generic Stack
    public class GenericStack<T>
    {
        private T[] Elements;
        private int Top;

        public GenericStack(int size)
        {
            Elements = new T[size];
            Top = -1;
        }

        public void Push(T item)
        {
            if (Top == Elements.Length - 1) throw new StackOverflowException();
            Elements[++Top] = item;
        }

        public T Pop()
        {
            if (Top == -1) throw new InvalidOperationException("Stack is empty");
            return Elements[Top--];
        }

        public T Peek()
        {
            if (Top == -1) throw new InvalidOperationException("Stack is empty");
            return Elements[Top];
        }
    }

    public class GenericUtility
    {
        public static T[] ReverseArray<T>(T[] array)
        {
            T[] Reversed = new T[array.Length];
            for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--)
            {
                Reversed[i] = array[j];
            }
            return Reversed;
        }

        public static void SwapElements<T>(T[] array, int Index1, int Index2)
        {
            T Temp = array[Index1];
            array[Index1] = array[Index2];
            array[Index2] = Temp;
        }

        public static T FindMaxElement<T>(T[] array) where T : IComparable<T>
        {
            T Max = array[0];
            foreach (T item in array)
            {
                if (item.CompareTo(Max) > 0)
                {
                    Max = item;
                }
            }
            return Max;
        }
    }

    internal class Program
    {
        static void SwapRectangle(ref RectangleStruct R1, ref RectangleStruct R2)
        {
            RectangleStruct Temp = R1;
            R1 = R2;
            R2 = Temp;
        }

        static void Main(string[] args)
        {
            #region problem1
            Console.WriteLine("--- Problem 1: Enum Weekdays ---");
            foreach (Weekdays Day in Enum.GetValues(typeof(Weekdays)))
            {
                Console.WriteLine($"{Day} = {(int)Day}");
            }
            #endregion

            #region problem2
            Console.WriteLine("\n--- Problem 2: Enum Grades ---");
            foreach (Grades Grade in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine($"{Grade} = {(short)Grade}");
            }
            #endregion

            #region problem3
            Console.WriteLine("\n--- Problem 3: Person & Department ---");
            Person P1 = new Person { Id = 1, Name = "Shaban", PersonDept = new Department { DeptName = "IT" } };
            Person P2 = new Person { Id = 2, Name = "Ali", PersonDept = new Department { DeptName = "HR" } };
            Console.WriteLine($"Person: {P1.Name}, Dept: {P1.PersonDept.DeptName}");
            #endregion

            #region problem4
            Console.WriteLine("\n--- Problem 4: Sealed Property ---");
            Child C1 = new Child();
            C1.Salary = 5000;
            C1.DisplaySalary();
            #endregion

            #region problem5
            Console.WriteLine("\n--- Problem 5: Static Utility Method ---");
            double Perimeter = Utility.PerimeterOfRectangle(10, 5);
            Console.WriteLine("Rectangle Perimeter: " + Perimeter);
            #endregion

            #region problem6
            Console.WriteLine("\n--- Problem 6: Operator Overloading ---");
            ComplexNumber CNum1 = new ComplexNumber { Real = 2, Imaginary = 3 };
            ComplexNumber CNum2 = new ComplexNumber { Real = 4, Imaginary = 5 };
            ComplexNumber CNumResult = CNum1 * CNum2;
            Console.WriteLine("Complex Multiplication Result: " + CNumResult.ToString());
            #endregion

            #region problem7
            Console.WriteLine("\n--- Problem 7: Enum Gender Underlying Type ---");
            Console.WriteLine($"Type of Gender.Male is: {Enum.GetUnderlyingType(typeof(Gender))}");
            #endregion

            #region problem8
            Console.WriteLine("\n--- Problem 8: Static Temp Converter ---");
            Console.WriteLine("30 Celsius to Fahrenheit: " + Utility.CelsiusToFahrenheit(30));
            #endregion

            #region problem9
            Console.WriteLine("\n--- Problem 9: Enum.TryParse ---");
            string UserInput = "A";
            if (Enum.TryParse(UserInput, out Grades ParsedGrade))
            {
                Console.WriteLine("Successfully parsed grade: " + ParsedGrade);
            }
            else
            {
                Console.WriteLine("Invalid grade input.");
            }
            #endregion

            #region problem10 & 14
            Console.WriteLine("\n--- Problem 10 & 14: Employee Search ---");
            Department DeptIT = new Department { DeptId = 1, DeptName = "IT" };
            Employee[] EmpArray = {
                new Employee { EmpId = 1, Name = "Shaban", EmpDept = DeptIT },
                new Employee { EmpId = 2, Name = "Omar", EmpDept = new Department { DeptId = 2, DeptName = "HR" } }
            };

            Employee TargetEmp = new Employee { EmpId = 1, Name = "Shaban", EmpDept = DeptIT };
            int FoundIndex = Helper2<Employee>.SearchArray(EmpArray, TargetEmp);
            Console.WriteLine($"Employee found at index: {FoundIndex} -> {TargetEmp}");
            #endregion

            #region problem11
            Console.WriteLine("\n--- Problem 11: Generic Max ---");
            Console.WriteLine("Max Integer: " + Helper.Max(10, 20));
            Console.WriteLine("Max Double: " + Helper.Max(10.5, 9.5));
            Console.WriteLine("Max String: " + Helper.Max("Apple", "Zebra"));
            #endregion

            #region problem12
            Console.WriteLine("\n--- Problem 12: Generic ReplaceArray ---");
            int[] Numbers = { 1, 2, 3, 2, 5 };
            Helper2<int>.ReplaceArray(Numbers, 2, 99);
            Console.WriteLine("Array after replace: " + string.Join(", ", Numbers));
            #endregion

            #region problem13
            Console.WriteLine("\n--- Problem 13: Non-Generic Swap ---");
            RectangleStruct Rect1 = new RectangleStruct { Length = 10, Width = 5 };
            RectangleStruct Rect2 = new RectangleStruct { Length = 20, Width = 15 };
            SwapRectangle(ref Rect1, ref Rect2);
            Console.WriteLine("Rect1 after swap: " + Rect1.ToString());
            #endregion

            #region problem15
            Console.WriteLine("\n--- Problem 15: Struct vs Class Equals ---");
            CircleStruct CS1 = new CircleStruct { Radius = 5, Color = "Red" };
            CircleStruct CS2 = new CircleStruct { Radius = 5, Color = "Red" };
            // CS1 == CS2 will cause compile error unless overloaded.
            Console.WriteLine("Struct Equals: " + CS1.Equals(CS2)); // True (Value comparison)

            CircleClass CC1 = new CircleClass { Radius = 5, Color = "Red" };
            CircleClass CC2 = new CircleClass { Radius = 5, Color = "Red" };
            Console.WriteLine("Class Equals: " + CC1.Equals(CC2)); // False (Reference comparison)
            #endregion

            #region Part02_Generics
            Console.WriteLine("\n--- Part 02: Generics Problems ---");
            // Reverse Array
            string[] Words = { "One", "Two", "Three" };
            string[] ReversedWords = GenericUtility.ReverseArray(Words);
            Console.WriteLine("Reversed: " + string.Join(", ", ReversedWords));

            // Generic Stack
            GenericStack<int> NumberStack = new GenericStack<int>(5);
            NumberStack.Push(10);
            NumberStack.Push(20);
            Console.WriteLine("Stack Pop: " + NumberStack.Pop());

            // Generic Swap
            int[] SwapArr = { 1, 2, 3 };
            GenericUtility.SwapElements(SwapArr, 0, 2);
            Console.WriteLine("Array after Swap: " + string.Join(", ", SwapArr));

            // Find Max
            double[] DoubleArr = { 1.5, 9.9, 3.4 };
            Console.WriteLine("Max in Array: " + GenericUtility.FindMaxElement(DoubleArr));
            #endregion
        }
    }
}
