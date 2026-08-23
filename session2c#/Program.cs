using System;
using System.Diagnostics;

namespace session2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region problem 1
            // Declare variable x and initialize it to 10
            /* Declare variable y and initialize it to 20 */
            // Calculate the sum of x and y, then print the result to the console
            int x = 10;
            int y = 20;
            int sum = x + y;
            Console.WriteLine(sum);
            #endregion

            #region problem 2
            /*Error 1: "10" is a string. Removed double quotes to assign an integer value
            Error 2: The variable 'y' was not declared. Declared and initialized 'y'.
            Error 3: C# is case-sensitive. Changed 'console' to 'Console' with a capital 'C'*/
            int x2 = 35;
            int y2 = 15;
            Console.WriteLine(x2 + y2);
            #endregion

            #region problem3
            string FullName = "Shahad Elshazly Bader";
            Console.WriteLine(FullName);
            int Age = 19;
            Console.WriteLine(Age);
            decimal MonthlySalary = 6000m;
            Console.WriteLine(MonthlySalary);
            bool isStudent = true;
            Console.WriteLine(isStudent);
            #endregion

            #region problem4
            int[] array1 = { 10, 20, 30 };
            int[] array2 = array1;
            array1[0] = 55;
            Console.WriteLine(array2[0]);
            #endregion

            #region problem5
            int x3 = 15;
            int y3 = 4;
            Console.WriteLine(x3 + y3);
            Console.WriteLine(x3 - y3);
            Console.WriteLine(x3 * y3);
            Console.WriteLine(x3 / y3);
            Console.WriteLine(x3 % y3);
            #endregion

            #region problem6
            int x4 = 12;
            Console.WriteLine(x4 > 10);
            Console.WriteLine(x4 % 2 == 0);
            #endregion

            #region problem7
            double myDouble = 6.75;
            /* int myInt1 = myDouble;*/
            int myInt2 = (int)myDouble;
            Console.WriteLine("Original double: " + myDouble);
            Console.WriteLine("Casted int: " + myInt2);
            #endregion

            #region problem8
            Console.WriteLine("Enter Your Age ");
            string AgeString = Console.ReadLine();
            int Age2 = int.Parse(AgeString);
            if (Age2 > 0)
            {
                Console.WriteLine("Valid age.");
            }
            else
            {
                Console.WriteLine("Invalid age.");
            }
            #endregion

            #region problem9
            int x5 = 15;
            Console.WriteLine(x5++);
            Console.WriteLine(++x5);
            #endregion


        }
    }
}