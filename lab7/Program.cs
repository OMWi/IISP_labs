using System;

namespace lab7
{
    class Program
    {
        static void Main()
        {
            RNum num1 = RNum.Parse("10 / 7");
            RNum num2 = RNum.Parse("10 : 7");
            RNum num3 = RNum.Parse("7 / 10");
            Console.WriteLine("num1 = " + num1.ToString('d'));
            Console.WriteLine("num2 = " + num2.ToString('c'));
            Console.WriteLine("num3 = " + num3.ToString('d'));
            Console.WriteLine();
            Console.WriteLine(num1.ToString('c') + " + " + num3.ToString('c') + " = "
                + (num1 + num3).ToString('c'));
            Console.WriteLine("num1 * num2 = " + (num1 * num2).ToString('c'));
            Console.Write(num1.ToString('c') + " != " + num2.ToString('c') + ' ');
            Console.WriteLine(num1 != num2);
            Console.Write(num1.ToString('c') + " > " + num3.ToString('c') + ' ');
            Console.WriteLine(num1 > num3);
            int a = (int)num1;
            Console.WriteLine("a = " + a + "\t((int)num1)");
            double b = (double)num3;
            Console.WriteLine("b = " + b + "\t((double)num3");
            Console.ReadKey(true);
        }
    }
}
