using System;

enum DayOfWeek
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
class Program
{
    static void Main()
    {
        #region 1
        int[] firstArray = new int[3];
        firstArray[0] = 10;
        firstArray[1] = 20;
        firstArray[2] = 30;
        int[] secondArray = new int[] { 40, 50, 60 };
        int[] thirdArray = { 70, 80, 90 };
        foreach (int item in firstArray)
        {
            Console.WriteLine(item);
        }

        try
        {
            int errorTest = firstArray[5];
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        #endregion

        #region 2
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = arr1;
        arr2[0] = 99;
        Console.WriteLine(arr1[0]);
        Console.WriteLine(arr2[0]);
        int[] arr3 = { 10, 20, 30 };
        int[] arr4 = (int[])arr3.Clone();
        arr4[0] = 88;
        Console.WriteLine(arr3[0]);
        Console.WriteLine(arr4[0]);
        #endregion

        #region 3
        int[,] grades = new int[3, 3];
        for (int i = 0; i < grades.GetLength(0); i++)
        {
            for (int j = 0; j < grades.GetLength(1); j++)
            {
                Console.Write("Student " + (i + 1) + " - Subject " + (j + 1) + ": ");
                grades[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine();

        for (int i = 0; i < grades.GetLength(0); i++)
        {
            Console.Write("Student " + (i + 1) + " grades: ");
            for (int j = 0; j < grades.GetLength(1); j++)
            {
                Console.Write(grades[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 4
        int[] numbers = { 50, 10, 40, 20, 30 };
        Console.WriteLine("Original Array:");
        foreach (int n in numbers) Console.Write(n + " ");
        Console.WriteLine("\n");
        Array.Sort(numbers);
        Console.WriteLine("After Sort:");
        foreach (int n in numbers) Console.Write(n + " ");
        Console.WriteLine("\n");
        Array.Reverse(numbers);
        Console.WriteLine("After Reverse:");
        foreach (int n in numbers) Console.Write(n + " ");
        Console.WriteLine("\n");
        int index = Array.IndexOf(numbers, 40);
        Console.WriteLine("Index of number 40: " + index + "\n");
        int[] copiedArray = new int[3];
        Array.Copy(numbers, copiedArray, 3);
        Console.WriteLine("After Copy (first 3 elements to a new array):");
        foreach (int n in copiedArray) Console.Write(n + " ");
        Console.WriteLine("\n");
        Array.Clear(numbers, 0, 2);
        Console.WriteLine("After Clear (first 2 elements):");
        foreach (int n in numbers) Console.Write(n + " ");
        Console.WriteLine();
        #endregion

        #region 5
        {
            int[] numbers1 = { 10, 20, 30, 40, 50 };

            for (int i = 0; i < numbers1.Length; i++)
            {
                Console.WriteLine(numbers1[i]);
            }

            Console.WriteLine();

            foreach (int num in numbers1)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();

            int j = numbers1.Length - 1;
            while (j >= 0)
            {
                Console.WriteLine(numbers1[j]);
                j--;
            }
        #endregion

            #region 6
            {
                int number;
                bool isValid;
                do
                {
                    Console.Write("Please enter a positive odd number: ");
                    string input2 = Console.ReadLine();
                    isValid = int.TryParse(input2, out number);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    else if (number <= 0)
                    {
                        Console.WriteLine("The number must be positive.");
                        isValid = false;
                    }
                    else if (number % 2 == 0)
                    {
                        Console.WriteLine("The number must be odd.");
                        isValid = false;
                    }
                } while (!isValid);
                Console.WriteLine("Thank you! You entered: " + number);
            }
            #endregion

            #region 7
            {
                int[,] matrix1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j1 = 0; j1 < matrix1.GetLength(1); j++)
                    {
                        Console.Write(matrix1[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            #region 8
            {
                Console.Write("Enter a month number (1-12): ");
                int month = int.Parse(Console.ReadLine());
                if (month == 1) Console.WriteLine("If-Else: January");
                else if (month == 2) Console.WriteLine("If-Else: February");
                else if (month == 3) Console.WriteLine("If-Else: March");
                else if (month == 4) Console.WriteLine("If-Else: April");
                else if (month == 5) Console.WriteLine("If-Else: May");
                else if (month == 6) Console.WriteLine("If-Else: June");
                else if (month == 7) Console.WriteLine("If-Else: July");
                else if (month == 8) Console.WriteLine("If-Else: August");
                else if (month == 9) Console.WriteLine("If-Else: September");
                else if (month == 10) Console.WriteLine("If-Else: October");
                else if (month == 11) Console.WriteLine("If-Else: November");
                else if (month == 12) Console.WriteLine("If-Else: December");
                else Console.WriteLine("If-Else: Invalid month");
                switch (month)
                {
                    case 1: Console.WriteLine("Switch: January"); break;
                    case 2: Console.WriteLine("Switch: February"); break;
                    case 3: Console.WriteLine("Switch: March"); break;
                    case 4: Console.WriteLine("Switch: April"); break;
                    case 5: Console.WriteLine("Switch: May"); break;
                    case 6: Console.WriteLine("Switch: June"); break;
                    case 7: Console.WriteLine("Switch: July"); break;
                    case 8: Console.WriteLine("Switch: August"); break;
                    case 9: Console.WriteLine("Switch: September"); break;
                    case 10: Console.WriteLine("Switch: October"); break;
                    case 11: Console.WriteLine("Switch: November"); break;
                    case 12: Console.WriteLine("Switch: December"); break;
                    default: Console.WriteLine("Switch: Invalid month"); break;
                }
            }
            #endregion

            #region 9
            {
                int[] numbers2 = { 50, 20, 10, 40, 20, 30 };

                Array.Sort(numbers2);

                foreach (int num in numbers2)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();

                int firstIndex = Array.IndexOf(numbers2, 20);
                int lastIndex = Array.LastIndexOf(numbers2, 20);

                Console.WriteLine(firstIndex);
                Console.WriteLine(lastIndex);
            }
            #endregion

            #region 10
            {
                int[] numbers3 = { 10, 20, 30, 40, 50 };
                int sumFor = 0;
                for (int i = 0; i < numbers3.Length; i++)
                {
                    sumFor += numbers3[i];
                }
                Console.WriteLine(sumFor);

                int sumForeach = 0;
                foreach (int num in numbers3)
                {
                    sumForeach += num;
                }
                Console.WriteLine(sumForeach);
            }
            #endregion

            #region 11
            string input = Console.ReadLine();
            DayOfWeek selectedDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input);
            Console.WriteLine(selectedDay);
            #endregion

            #region 12
            string input1 = Console.ReadLine();
            DayOfWeek selectedDay1 = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input);
            Console.WriteLine(selectedDay);
            #endregion


        }
    }
    }
