using System;
using System.Text;

class MyClass
{
    public int num;
}

class Program
{
    static void Main()
    #region 0
    {

        Console.WriteLine("enter text:");
        string x = Console.ReadLine();

        try
        {
            int y = int.Parse(x);
            Console.WriteLine("the parse is : " + y);

            int z = Convert.ToInt32(x);
            Console.WriteLine("the convert is : " + z);
        }
        catch (Exception e)
        {
            Console.WriteLine("error");
        }
        #endregion 0

        #region 1
        Console.WriteLine("enter num:");
        string s = Console.ReadLine();

        int n;
        bool check = int.TryParse(s, out n);

        if (check == true)
        {
            Console.WriteLine("number is " + n);
        }
        else
        {
            Console.WriteLine("bad input");
        }
        #endregion 1

        #region 2
        object obj;

        obj = 10;
        Console.WriteLine("int hash: " + obj.GetHashCode());

        obj = "ahmed";
        Console.WriteLine("string hash: " + obj.GetHashCode());

        obj = 10.5;
        Console.WriteLine("double hash: " + obj.GetHashCode());

        #endregion 2

        #region 3

        MyClass a = new MyClass();
        a.num = 10;

        MyClass b = a;

        b.num = 50;

        Console.WriteLine("value of a is : " + a.num);

        #endregion 3


        #region 4

        {
            string text = "Hello ";
            Console.WriteLine("hash before: " + text.GetHashCode());

            text = text + "Hi Willy";
            Console.WriteLine("hash after: " + text.GetHashCode());
        }

        #endregion 4

        #region 5
        {
            StringBuilder S = new StringBuilder("test ");
            Console.WriteLine("before: " + S.GetHashCode());

            S.Append("Hi Willy");
            Console.WriteLine("after: " + S.GetHashCode());
        }

        #endregion 5

        #region 6

        {
            Console.WriteLine("enter first number:");
            int l = int.Parse(Console.ReadLine());

            Console.WriteLine("enter second number:");
            int y = int.Parse(Console.ReadLine());

            int sum = l + y;

            Console.WriteLine("Sum is " + sum);

            Console.WriteLine(string.Format("Sum is {0}", sum));

            Console.WriteLine($"Sum is {sum}");
        }

        #endregion 6

        #region 7
        {
            StringBuilder r = new StringBuilder("hello ");

            r.Append("world");
            Console.WriteLine("after append: " + r);

            r.Replace("world", "C#");
            Console.WriteLine("after replace: " + r);

            r.Insert(0, "hi ");
            Console.WriteLine("after insert: " + r);

            r.Remove(0, 3);
            Console.WriteLine("after remove: " + r);
        }

        #endregion 7

    }
}
