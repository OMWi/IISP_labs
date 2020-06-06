using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6;
using System.Threading;

namespace lab8
{
    class Prog
    {

        static string GetName()
        {
            Console.Clear();
            Console.Write("Имя без расширения:");
            string name = Console.ReadLine() + ".txt";
            Console.WriteLine("Имя файла установлено");
            return name;
        }

        static string GetPath()
        {
            Console.Clear();
            Console.Write("Путь к файлу:");
            string path = Console.ReadLine();
            Console.WriteLine("Путь установлен");
            return path;
        }

        static void Main()
        {
            string path = "D:\\Projects\\isp\\slns\\lab8\\";
            string name = "dat.txt";
            Student st1 = new Student();
            st1.FOpenError += () =>
            {
                Console.WriteLine(
                  "Ошибка при открытии файла " + path + name +
                  "\nВведите \"name\" если хотите изменить имя файла.\nВведите \"path\" если хотите изменить путь к файлу");
                string option1 = Console.ReadLine();
                if (option1 == "name") name = GetName();
                else if (option1 == "path") path = GetPath();
                else return;
                Console.Clear();    
                st1.ReadFile(path, name);
            };
            st1.FOpen += delegate ()
            {
                Console.WriteLine("Файл считан");
                Thread.Sleep(820);
                Console.Clear();               
                Console.WriteLine("Инфо\n");
                Console.WriteLine(st1.GetInfo());
            };

            st1.ReadFile(path, name);
            Console.ReadKey(true);
        }
    }
}
