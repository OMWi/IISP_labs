using System;
using System.Diagnostics;

namespace lab2_3
{
    class Program
    {
        static bool TryEnterData(out ulong num)
        {
            string str = Console.ReadLine();
            if (ulong.TryParse(str, out num))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Input error");
                return false;
            }
        }

        /*static ulong EnterData()
        {
            string str = Console.ReadLine();
            if (ulong.TryParse(str, out ulong num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Input error");
                return 1;
            }
        }*/

        static ulong GetDegree(ulong a, ulong b)
        {
            if (a == 0)
            {
                return 0;
            }
            ulong maxNumber = 1;
            int currentDegree = 0;
            while (maxNumber <= b)
            {
                maxNumber <<= 1;
                currentDegree++;
            }
            maxNumber >>= 1;
            currentDegree--;
            ulong now = maxNumber;
            while (now < a)
            {
                now += maxNumber;
                if (now > b)
                {
                    maxNumber >>= 1;
                    now = maxNumber;
                    currentDegree--;
                }
            }
            ulong degree = (ulong)currentDegree;
            maxNumber >>= 1;
            currentDegree--;
            for (; currentDegree > 0; currentDegree--, maxNumber >>= 1)
            {
                now = maxNumber;
                int mod = 1;
                while (now < a)
                {
                    now += maxNumber;
                    if (now == (ulong)mod * (maxNumber << 1))
                    {
                        mod++;
                    }
                }
                while (now < b)
                {
                    if (now == (ulong)mod * (maxNumber << 1))
                    {
                        mod++;
                    }
                    else
                    {
                        degree += (ulong)currentDegree;
                    }
                    now += maxNumber;
                }
            }
            return degree;
        }

        static void Main()
        {
            Console.Write("a = ");
            if (!TryEnterData(out ulong a))
            {
                return;
            }
            Console.Write("b = ");
            if (!TryEnterData(out ulong b))
            {
                return;
            }

            Stopwatch time = new Stopwatch();
            time.Start();

            Console.WriteLine("Degree " + GetDegree(a, b));

            time.Stop();
            Console.WriteLine("Elapsed time " + (float)time.ElapsedMilliseconds / 1000 + "s");
            Console.ReadLine();
        }
    }
}
