using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6;

namespace lab8
{
    class Prog
    {
        public delegate void Del2();
        public static event Del2 ReadData;


        static void Main()
        {
            string name = "D:\\Projects\\isp\\slns\\lab8\\data.txt";
            Student st1 = new Student("name1", "male", DateTime.Now, Program.GetIitpSchedule());
            st1.DataGot += delegate (string info)
            {
                if (!File.Exists(name))
                {
                    File.Create(name);
                }
                if (File.Exists(name))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(name, true))
                    {
                        file.WriteLine(info);
                    }
                    Console.WriteLine("Data saved");
                }
            };
            ReadData += () =>
            {
                Console.WriteLine("Data succesfully read from file");
            };
            Console.WriteLine(st1.GetInfo() + "\n\n\n");

            using (System.IO.StreamReader file = new System.IO.StreamReader(name))
            {
                try
                {
                    Console.WriteLine("Data from file : " + System.IO.File.ReadAllText(name));
                    ReadData?.Invoke();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error while trying to read file");
                    return;
                }
            }

            Console.ReadKey(true);
        }
    }
}
