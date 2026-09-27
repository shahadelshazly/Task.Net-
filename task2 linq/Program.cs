

using System;
using System.Linq;
using static linq1.ListGenerators;
namespace linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Arrays used in the assignment ---
            string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] wordsArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            string[] dictWords = { "apple", "cherry", "believe", "receive", "weight" }; // Dummy array for dictionary
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            #region Restriction Operators
            Console.WriteLine("=== Restriction Operators ===");

            // Q1
            var res1 = ProductList.Where(p => p.UnitsInStock == 0);
            Console.WriteLine("\n-- Q1: Out of Stock --");
            foreach (var item in res1) { Console.WriteLine(item.ProductName); }

            // Q2
            var res2 = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);
            Console.WriteLine("\n-- Q2: In Stock & Price > 3 --");
            foreach (var item in res2) { Console.WriteLine(item.ProductName); }

            // Q3
            var res3 = digitsArr.Where((name, index) => name.Length < index);
            Console.WriteLine("\n-- Q3: Digits shorter than value --");
            foreach (var item in res3) { Console.WriteLine(item); }
            #endregion

            #region Element Operators
            Console.WriteLine("\n=== Element Operators ===");

            // Q1
            var elem1 = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine("\n-- Q1: First Out of Stock --\n" + elem1?.ProductName);

            // Q2
            var elem2 = ProductList.FirstOrDefault(p => p.UnitPrice > 1000m);
            Console.WriteLine("\n-- Q2: First Price > 1000 --\n" + (elem2?.ProductName ?? "Null"));

            // Q3
            var elem3 = Arr.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine("\n-- Q3: Second number > 5 --\n" + elem3);
            #endregion

            #region Aggregate Operators
            Console.WriteLine("\n=== Aggregate Operators ===");

            // Q1
            var agg1 = Arr.Count(n => n % 2 != 0);
            Console.WriteLine("\n-- Q1: Odd Numbers Count --\n" + agg1);

            // Q2
            var agg2 = CustomerList.Select(c => new { c.CustomerName, OrderCount = c.Orders.Length });
            Console.WriteLine("\n-- Q2: Customers & Order Count --");
            foreach (var item in agg2) { Console.WriteLine(item); }

            // Q3
            var agg3 = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() });
            Console.WriteLine("\n-- Q3: Categories & Product Count --");
            foreach (var item in agg3) { Console.WriteLine(item); }

            // Q4
            var agg4 = Arr.Sum();
            Console.WriteLine("\n-- Q4: Total of numbers --\n" + agg4);

            // Q5
            var agg5 = dictWords.Sum(w => w.Length);
            Console.WriteLine("\n-- Q5: Total chars in dictionary --\n" + agg5);

            // Q6
            var agg6 = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, TotalStock = g.Sum(p => p.UnitsInStock) });
            Console.WriteLine("\n-- Q6: Total units in stock per category --");
            foreach (var item in agg6) { Console.WriteLine(item); }

            // Q8 (Cheapest Price)
            var agg8 = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, MinPrice = g.Min(p => p.UnitPrice) });
            Console.WriteLine("\n-- Q8: Cheapest price per category --");
            foreach (var item in agg8) { Console.WriteLine(item); }
            #endregion

            #region Ordering Operators
            Console.WriteLine("\n=== Ordering Operators ===");

            // Q1
            var ord1 = ProductList.OrderBy(p => p.ProductName);
            Console.WriteLine("\n-- Q1: Sort by name --");
            foreach (var item in ord1.Take(5)) { Console.WriteLine(item.ProductName); } // Taking 5 just to keep console clean

            // Q2
            var ord2 = wordsArr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n-- Q2: Case-insensitive sort --");
            foreach (var item in ord2) { Console.WriteLine(item); }

            // Q3
            var ord3 = ProductList.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("\n-- Q3: Sort by units in stock DESC --");
            foreach (var item in ord3.Take(5)) { Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}"); }

            // Q4
            var ord4 = digitsArr.OrderBy(d => d.Length).ThenBy(d => d);
            Console.WriteLine("\n-- Q4: Sort digits by length then alphabetically --");
            foreach (var item in ord4) { Console.WriteLine(item); }

            // Q6
            var ord6 = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("\n-- Q6: Sort by category then price DESC --");
            foreach (var item in ord6.Take(5)) { Console.WriteLine($"{item.Category} - {item.UnitPrice}"); }

            // Q8
            var ord8 = digitsArr.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            Console.WriteLine("\n-- Q8: Digits with 2nd letter 'i' reversed --");
            foreach (var item in ord8) { Console.WriteLine(item); }
            #endregion

            #region Transformation Operators
            Console.WriteLine("\n=== Transformation Operators ===");

            // Q1
            var trans1 = ProductList.Select(p => p.ProductName);
            Console.WriteLine("\n-- Q1: Product Names Only --");
            foreach (var item in trans1.Take(5)) { Console.WriteLine(item); }

            // Q2
            string[] shortWords = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var trans2 = shortWords.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            Console.WriteLine("\n-- Q2: Upper and Lower --");
            foreach (var item in trans2) { Console.WriteLine(item); }

            // Q4
            var trans4 = Arr.Select((num, index) => new { Number = num, InPlace = (num == index) });
            Console.WriteLine("\n-- Q4: Match position --");
            foreach (var item in trans4) { Console.WriteLine(item); }

            // Q5
            var trans5 = numbersA.SelectMany(a => numbersB.Where(b => a < b).Select(b => new { A = a, B = b }));
            Console.WriteLine("\n-- Q5: Pairs where a < b --");
            foreach (var item in trans5) { Console.WriteLine($"{item.A} is less than {item.B}"); }

            // Q6
            var trans6 = CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500.00m);
            Console.WriteLine("\n-- Q6: Orders less than 500 --");
            foreach (var item in trans6.Take(5)) { Console.WriteLine(item.Total); }
            #endregion

            #region Partitioning Operators
            Console.WriteLine("\n=== Partitioning Operators ===");

            // Q1
            var part1 = CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Take(3);
            Console.WriteLine("\n-- Q1: First 3 WA Orders --");
            foreach (var item in part1) { Console.WriteLine(item.OrderID); }

            // Q3
            var part3 = Arr.TakeWhile((num, index) => num >= index);
            Console.WriteLine("\n-- Q3: Take while number >= index --");
            foreach (var item in part3) { Console.WriteLine(item); }

            // Q4
            var part4 = Arr.SkipWhile(num => num % 3 != 0);
            Console.WriteLine("\n-- Q4: Skip until divisible by 3 --");
            foreach (var item in part4) { Console.WriteLine(item); }
            #endregion

            #region Quantifiers
            Console.WriteLine("\n=== Quantifiers ===");

            // Q1
            var quant1 = dictWords.Any(w => w.Contains("ei"));
            Console.WriteLine("\n-- Q1: Any word contains 'ei' --\n" + quant1);

            // Q2
            var quant2 = ProductList.GroupBy(p => p.Category).Where(g => g.Any(p => p.UnitsInStock == 0));
            Console.WriteLine("\n-- Q2: Categories with at least one out of stock --");
            foreach (var group in quant2) { Console.WriteLine(group.Key); }

            // Q3
            var quant3 = ProductList.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0));
            Console.WriteLine("\n-- Q3: Categories with all in stock --");
            foreach (var group in quant3) { Console.WriteLine(group.Key); }
            #endregion
        }
    }
}