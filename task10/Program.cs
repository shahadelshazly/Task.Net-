using System;
using System.Collections.Generic;
using System.Linq;
namespace task10

{
    public class Employee : ICloneable
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public object Clone()
        {
            return new Employee { Name = this.Name, Salary = this.Salary };
        }

        public override string ToString()
        {
            return $"Emp: {Name}, Salary: {Salary}";
        }
    }
    public class Manager : Employee, IComparable<Manager>
    {
        public int CompareTo(Manager other)
        {
            if (other == null) return 1;
            return this.Salary.CompareTo(other.Salary);
        }

        public override string ToString()
        {
            return $"Manager: {Name}, Salary: {Salary}";
        }
    }
    public class SortingAlgorithm<T>
    {
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static void Sort(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
    public class CloneableSorting<T> where T : ICloneable, IComparable<T>
    {
        public static T[] CloneAndSort(T[] array)
        {
            T[] clonedArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                clonedArray[i] = (T)array[i].Clone();
            }
            SortingAlgorithm<T>.Sort(clonedArray);
            return clonedArray;
        }
    }
    public class SortingTwo<T>
    {
        public static void Sort(T[] array, Func<T, T, bool> compareMethod)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (compareMethod(array[j], array[j + 1]))
                    {
                        SortingAlgorithm<T>.Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }

    public delegate string StringTransformDelegate(string input);
    public delegate int MathDelegate(int a, int b);
    public delegate R GenericTransformDelegate<T, R>(T input);

    internal class Program
    {
        static T GetDefault<T>()
        {
            return default(T);
        }

        static void Main(string[] args)
        {
            #region problem1 & 4
            Console.WriteLine("--- Problem 1 & 4: Sorting Employees/Managers ---");
            Manager[] managers = {
                new Manager { Name = "Shaban", Salary = 9000 },
                new Manager { Name = "Ali", Salary = 5000 },
                new Manager { Name = "Omar", Salary = 12000 }
            };
            SortingAlgorithm<Manager>.Sort(managers);
            Console.WriteLine(string.Join("\n", (IEnumerable<Manager>)managers));
            #endregion

            #region problem2
            Console.WriteLine("\n--- Problem 2: Descending Sort with Lambda ---");
            int[] nums = { 5, 1, 9, 3 };
            SortingTwo<int>.Sort(nums, (a, b) => a < b); // Swap if a < b (Descending)
            Console.WriteLine("Sorted Desc: " + string.Join(", ", nums));
            #endregion

            #region problem3
            Console.WriteLine("\n--- Problem 3: Sort Strings by Length ---");
            string[] words = { "Apple", "Pie", "Banana", "Kiwi" };
            SortingTwo<string>.Sort(words, (a, b) => a.Length > b.Length); // ASC by length
            Console.WriteLine("Sorted by Length: " + string.Join(", ", words));
            #endregion

            #region problem5
            Console.WriteLine("\n--- Problem 5: Func Delegate to Sort by Name Length ---");
            Employee[] emps = {
                new Employee { Name = "ShabanSayed", Salary = 5000 },
                new Employee { Name = "Ali", Salary = 6000 }
            };
            Func<Employee, Employee, bool> compareByNameLen = (e1, e2) => e1.Name.Length > e2.Name.Length;
            SortingTwo<Employee>.Sort(emps, compareByNameLen);
            Console.WriteLine(string.Join("\n", (IEnumerable<Employee>)emps));
            #endregion

            #region problem6
            Console.WriteLine("\n--- Problem 6: Anonymous Function vs Lambda ---");
            int[] arr2 = { 4, 2, 7 };
            // Anonymous Method
            SortingTwo<int>.Sort(arr2, delegate (int a, int b) { return a > b; });
            Console.WriteLine("ASC (Anon): " + string.Join(", ", arr2));

            // Lambda
            SortingTwo<int>.Sort(arr2, (a, b) => a > b);
            Console.WriteLine("ASC (Lambda): " + string.Join(", ", arr2));
            #endregion

            #region problem7
            Console.WriteLine("\n--- Problem 7: Generic Swap ---");
            int x = 10, y = 20;
            SortingAlgorithm<int>.Swap(ref x, ref y);
            Console.WriteLine($"Swapped: x={x}, y={y}");
            #endregion

            #region problem8
            Console.WriteLine("\n--- Problem 8: Multi-criteria Sorting ---");
            Employee[] multiEmps = {
                new Employee { Name = "Ziad", Salary = 5000 },
                new Employee { Name = "Ali", Salary = 5000 },
                new Employee { Name = "Shaban", Salary = 8000 }
            };
            SortingTwo<Employee>.Sort(multiEmps, (a, b) =>
            {
                if (a.Salary == b.Salary) return string.Compare(a.Name, b.Name) > 0;
                return a.Salary > b.Salary;
            });
            Console.WriteLine(string.Join("\n", (IEnumerable<Employee>)multiEmps));
            #endregion

            #region problem9
            Console.WriteLine("\n--- Problem 9: GetDefault<T> ---");
            Console.WriteLine("Default int: " + GetDefault<int>()); // 0
            Console.WriteLine("Default string: " + (GetDefault<string>() == null ? "null" : GetDefault<string>())); // null
            #endregion

            #region problem10
            Console.WriteLine("\n--- Problem 10: ICloneable Constraint ---");
            Manager[] orig = { new Manager { Name = "Shaban", Salary = 9000 }, new Manager { Name = "Ali", Salary = 3000 } };
            Manager[] cloned = CloneableSorting<Manager>.CloneAndSort(orig);
            Console.WriteLine("Original 1st item: " + orig[0].Salary); // Unchanged (9000)
            Console.WriteLine("Cloned & Sorted 1st item: " + cloned[0].Salary); // Sorted (3000)
            #endregion

            #region problem11
            Console.WriteLine("\n--- Problem 11: String Delegate Transform ---");
            StringTransformDelegate toUpper = s => s.ToUpper();
            List<string> strList = new List<string> { "hello", "world" };
            var upperList = strList.Select(s => toUpper(s)).ToList();
            Console.WriteLine(string.Join(", ", upperList));
            #endregion

            #region problem12
            Console.WriteLine("\n--- Problem 12: Math Delegate ---");
            MathDelegate add = (a, b) => a + b;
            MathDelegate mult = (a, b) => a * b;
            Console.WriteLine("Add (5,3): " + add(5, 3));
            Console.WriteLine("Mult (5,3): " + mult(5, 3));
            #endregion

            #region problem13
            Console.WriteLine("\n--- Problem 13: Generic Delegate Transform ---");
            GenericTransformDelegate<int, string> intToStr = num => $"Number: {num}";
            List<int> intList = new List<int> { 1, 2, 3 };
            var transformed = intList.Select(i => intToStr(i)).ToList();
            Console.WriteLine(string.Join(", ", transformed));
            #endregion

            #region problem14
            Console.WriteLine("\n--- Problem 14: Func for Square ---");
            Func<int, int> square = n => n * n;
            var squaredList = intList.Select(square).ToList();
            Console.WriteLine("Squared: " + string.Join(", ", squaredList));
            #endregion

            #region problem15
            Console.WriteLine("\n--- Problem 15: Action Delegate ---");
            Action<string> printStr = s => Console.Write(s + " ");
            strList.ForEach(printStr);
            Console.WriteLine();
            #endregion

            #region problem16
            Console.WriteLine("\n--- Problem 16: Predicate Delegate ---");
            Predicate<int> isEven = n => n % 2 == 0;
            List<int> mixed = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evens = mixed.FindAll(isEven);
            Console.WriteLine("Evens: " + string.Join(", ", evens));
            #endregion

            #region problem17 & 18
            Console.WriteLine("\n--- Problem 17 & 18: Anonymous Functions ---");
            var startsWithH = strList.FindAll(delegate (string s) { return s.StartsWith("h"); });
            Console.WriteLine("Starts with h: " + string.Join(", ", startsWithH));

            Func<int, int, int> sub = delegate (int a, int b) { return a - b; };
            Console.WriteLine("Subtract via Anon (10-4): " + sub(10, 4));
            #endregion

            #region problem19 & 20
            Console.WriteLine("\n--- Problem 19 & 20: Lambda Expressions ---");
            var lambdaFiltered = strList.FindAll(s => s.Length > 3 || s.Contains("e"));
            Console.WriteLine("Filtered (Len>3 or 'e'): " + string.Join(", ", lambdaFiltered));

            Func<double, double, double> power = (baseNum, exp) => Math.Pow(baseNum, exp);
            Console.WriteLine("Power (2^3): " + power(2, 3));
            #endregion
        }
    }
}
