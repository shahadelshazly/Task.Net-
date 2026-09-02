
using System;
using System.Text;

namespace task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part1_Problem1
            {
                Console.WriteLine("Part 01: Problem 1");
                try
                {
                    Console.Write("Enter First Integer: ");
                    int Num1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Second Integer: ");
                    int Num2 = int.Parse(Console.ReadLine());

                    int Result = Num1 / Num2;
                    Console.WriteLine("Result: " + Result);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Error: Cannot divide by zero. " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Operation complete");
                }
            }
            #endregion

            #region Part01_Problem2
            {
                Console.WriteLine("Part 01: Problem 2");
                Console.Write("Enter a positive integer for X: ");
                if (int.TryParse(Console.ReadLine(), out int X) && X > 0)
                {
                    Console.Write("Enter an integer for Y (greater than 1): ");
                    if (int.TryParse(Console.ReadLine(), out int Y) && Y > 1)
                    {
                        Console.WriteLine($"Valid inputs! X: {X}, Y: {Y}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Y must be a number greater than 1.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. X must be a positive number.");
                }
            }
            #endregion

            #region Part01_Problem3
            {
                Console.WriteLine("Part 01: Problem 3");
                int? NullableInt = null;
                int DefaultInt = NullableInt ?? 100;
                Console.WriteLine("Assigned via Null-Coalescing: " + DefaultInt);

                if (NullableInt.HasValue)
                {
                    Console.WriteLine("Value is: " + NullableInt.Value);
                }
                else
                {
                    Console.WriteLine("NullableInt has no value.");
                }
            }
            #endregion

            #region Part01_Problem4
            {
                Console.WriteLine("Part 01: Problem 4");
                int[] Array1D = new int[5] { 10, 20, 30, 40, 50 };
                try
                {
                    Console.WriteLine("Attempting to access index 5...");
                    Console.WriteLine(Array1D[5]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Error: Array index is out of bounds. " + ex.Message);
                }
            }
            #endregion

            #region Part01_Problem5
            {
                Console.WriteLine("Part 01: Problem 5");
                int[,] Matrix = new int[3, 3];
                int Rows = Matrix.GetLength(0);
                int Cols = Matrix.GetLength(1);

                Console.WriteLine("Enter 9 values for the 3x3 array:");
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        Console.Write($"Element [{i},{j}]: ");
                        Matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                for (int i = 0; i < Rows; i++)
                {
                    int RowSum = 0;
                    for (int j = 0; j < Cols; j++) RowSum += Matrix[i, j];
                    Console.WriteLine($"Sum of Row {i}: {RowSum}");
                }

                for (int j = 0; j < Cols; j++)
                {
                    int ColSum = 0;
                    for (int i = 0; i < Rows; i++) ColSum += Matrix[i, j];
                    Console.WriteLine($"Sum of Column {j}: {ColSum}");
                }
            }
            #endregion

            #region Part01_Problem6
            {
                Console.WriteLine("Part 01: Problem 6");
                int[][] JaggedArray = new int[3][];
                JaggedArray[0] = new int[2];
                JaggedArray[1] = new int[3];
                JaggedArray[2] = new int[1];

                for (int i = 0; i < JaggedArray.Length; i++)
                {
                    Console.WriteLine($"Enter {JaggedArray[i].Length} values for Row {i}:");
                    for (int j = 0; j < JaggedArray[i].Length; j++)
                    {
                        JaggedArray[i][j] = int.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("Jagged Array Values:");
                for (int i = 0; i < JaggedArray.Length; i++)
                {
                    for (int j = 0; j < JaggedArray[i].Length; j++)
                    {
                        Console.Write(JaggedArray[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            #region Part01_Problem7
            {
                Console.WriteLine("Part 01: Problem 7");
                string? NullableString = null;
                Console.Write("Do you want to assign a value? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    NullableString = "Hello Developer!";
                }

                // Using null-forgiveness (!) assuming we are sure it's not null here
                if (NullableString != null)
                {
                    int Length = NullableString!.Length;
                    Console.WriteLine("String length: " + Length);
                }
            }
            #endregion

            #region Part01_Problem8
            {
                Console.WriteLine("Part 01: Problem 8");
                int ValueType = 100;
                object BoxedValue = ValueType; // Boxing
                Console.WriteLine("Boxed Value: " + BoxedValue);

                try
                {
                    double UnboxedInvalid = (double)BoxedValue; // Invalid Cast
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("Unboxing Error: " + ex.Message);
                }
            }
            #endregion

            #region Part01_Problem9,10,13
            {
                Console.WriteLine("Part 01: Problem 9");
                SumAndMultiply(5, 4, out int SumResult, out int ProductResult);
                Console.WriteLine($"Sum: {SumResult}, Product: {ProductResult}");

                Console.WriteLine("Part 01: Problem 10");
                PrintString(Text: "Hi Willy", Count: 2);

                Console.WriteLine("Part 01: Problem 13");
                Console.WriteLine("Sum with individual values: " + SumArray(1, 2, 3, 4));
                Console.WriteLine("Sum with array: " + SumArray(new int[] { 10, 20 }));
            }
            #endregion

            #region Part01_Problem11
            {
                Console.WriteLine("Part 01: Problem 11");
                int[]? NullableArr = null;
                int? ArrLength = NullableArr?.Length;
                Console.WriteLine("Array length safely accessed: " + (ArrLength.HasValue ? ArrLength.ToString() : "Null"));
            }
            #endregion

            #region Part01_Problem12
            {
                Console.WriteLine("Part 01: Problem 12");
                Console.Write("Enter a day of the week: ");
                string Day = Console.ReadLine();

                int DayNumber = Day.ToLower() switch
                {
                    "monday" => 1,
                    "tuesday" => 2,
                    "wednesday" => 3,
                    "thursday" => 4,
                    "friday" => 5,
                    "saturday" => 6,
                    "sunday" => 7,
                    _ => 0
                };
                Console.WriteLine(DayNumber != 0 ? $"Day Number: {DayNumber}" : "Invalid Day");
            }
            #endregion

            #region Part02_1
            {
                Console.WriteLine("Part 02: 1");
                Console.Write("Input: ");
                int MaxNum = int.Parse(Console.ReadLine());
                Console.Write("Output: ");
                for (int i = 1; i <= MaxNum; i++)
                {
                    Console.Write(i + (i < MaxNum ? ", " : ""));
                }
                Console.WriteLine();
            }
            #endregion

            #region Part02_2
            {
                Console.WriteLine("Part 02: 2");
                Console.Write("Input: ");
                int BaseNum = int.Parse(Console.ReadLine());
                Console.Write("Output: ");
                for (int i = 1; i <= 12; i++)
                {
                    Console.Write((BaseNum * i) + (i < 12 ? ", " : ""));
                }
                Console.WriteLine();
            }
            #endregion

            #region Part02_3
            {
                Console.WriteLine("Part 02: 3");
                Console.Write("Input: ");
                int MaxEven = int.Parse(Console.ReadLine());
                Console.Write("Output: ");
                bool IsFirst = true;
                for (int i = 2; i <= MaxEven; i += 2)
                {
                    if (!IsFirst) Console.Write(", ");
                    Console.Write(i);
                    IsFirst = false;
                }
                Console.WriteLine();
            }
            #endregion

            #region Part02_4
            {
                Console.WriteLine("Part 02: 4");
                Console.Write("Input Base: ");
                int Base = int.Parse(Console.ReadLine());
                Console.Write("Input Power: ");
                int Power = int.Parse(Console.ReadLine());

                long Result = 1;
                for (int i = 0; i < Power; i++)
                {
                    Result *= Base;
                }
                Console.WriteLine("Output: " + Result);
            }
            #endregion

            #region Part02_5
            {
                Console.WriteLine("Part 02: 5");
                Console.Write("Input: ");
                string InputStr = Console.ReadLine();
                Console.Write("Output: ");
                for (int i = InputStr.Length - 1; i >= 0; i--)
                {
                    Console.Write(InputStr[i]);
                }
                Console.WriteLine();
            }
            #endregion

            #region Part02_6
            {
                Console.WriteLine(" Part 02: 6");
                Console.Write("Input: ");
                int NumToReverse = int.Parse(Console.ReadLine());
                int ReversedNum = 0;

                while (NumToReverse > 0)
                {
                    ReversedNum = ReversedNum * 10 + (NumToReverse % 10);
                    NumToReverse /= 10;
                }
                Console.WriteLine("Output: " + ReversedNum);
            }
            #endregion

            #region Part02_7
            {
                Console.WriteLine("Part 02: 7");
                Console.Write("Enter array size: ");
                int Size = int.Parse(Console.ReadLine());
                int[] Elements = new int[Size];

                for (int i = 0; i < Size; i++)
                {
                    Console.Write($"Element {i}: ");
                    Elements[i] = int.Parse(Console.ReadLine());
                }

                int MaxDistance = 0;
                for (int i = 0; i < Size; i++)
                {
                    for (int j = i + 1; j < Size; j++)
                    {
                        if (Elements[i] == Elements[j])
                        {
                            int Distance = j - i - 1;
                            if (Distance > MaxDistance) MaxDistance = Distance;
                        }
                    }
                }
                Console.WriteLine("Max distance in cells between elements: " + MaxDistance);
            }
            #endregion

            #region Part02_8
            {
                Console.WriteLine("Part 02: 8");
                Console.Write("Input: ");
                string Sentence = Console.ReadLine();

                string[] Words = Sentence.Split(' ');
                Array.Reverse(Words);

                Console.WriteLine("Output: " + string.Join(" ", Words));
            }
            #endregion
        }

        static void SumAndMultiply(int Num1, int Num2, out int Sum, out int Product)
        {
            Sum = Num1 + Num2;
            Product = Num1 * Num2;
        }

        static void PrintString(string Text, int Count = 5)
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(Text);
            }
        }

        static int SumArray(params int[] Numbers)
        {
            int Total = 0;
            foreach (int num in Numbers) Total += num;
            return Total;
        }
    }
}


