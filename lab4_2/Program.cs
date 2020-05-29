using System;
using System.Runtime.InteropServices;

namespace lab4_2
{
    class Program
    {
        [DllImport("D:\\Projects\\isp\\Slns\\Debug\\lab4_dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool IsEven(int num);

        static void Main()
        {
            Console.Write("Введите число : ");
            int number;
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неправильный ввод. Попробуйте снова");
            }
            if (IsEven(number)) Console.WriteLine("Число является чётным");
            else Console.WriteLine("Число является нечётным");
            Console.ReadKey(true);           
        }
    }}