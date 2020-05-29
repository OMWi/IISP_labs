using System;
using System.Text;

namespace lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str1 = new StringBuilder(Console.ReadLine());
            StringBuilder str2 = new StringBuilder(str1.Length);
            str1.Append(' ');
            for (int i = str1.Length - 1, j = i; i >= 0; i--)
            {
                if (str1[i] == ' ')
                {
                    str2.Append(str1.ToString(), i + 1, j - i);
                    j = i;
                }
                else if (i == 0)
                {
                    str2.Append(str1.ToString(), i, j - i);
                }
            }
            Console.WriteLine(str2);
            Console.ReadLine();
        }
    }
}
