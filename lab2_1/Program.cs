using System;
using System.Globalization;

namespace lab2_1
{
    class Program
    {
        static void PrintDateNumbers(string date, short[,] numbers)
        {
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] >= '0' && date[i] <= '9')
                {
                    numbers[date[i] - '0', 1]++;
                }
            }
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                Console.WriteLine(numbers[i, 0] + " is included " + numbers[i, 1] + " times");
            }
        }

        static void ResetArray(short[,] numbers)
        {
            for (short i = 0; i < numbers.Length / 2; i++)
            {
                numbers[i, 1] = 0;
            }
        }

        static void Main(string[] args)
        {
            DateTime dateNow = DateTime.Now;
            string date = dateNow.ToString();
            Console.WriteLine(date + "\trussian\n");
            short[,] numbers = new short[10, 2] { { 0, 0 }, { 1, 0 }, { 2, 0 },
            { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 } };
            PrintDateNumbers(date, numbers);
            CultureInfo culture = new CultureInfo("en-US", true);
            date = dateNow.ToString(culture);
            Console.WriteLine("\n" + date + "\tamerican\n");
            ResetArray(numbers);
            PrintDateNumbers(date, numbers);
            Console.ReadLine();
        }
    }
}
