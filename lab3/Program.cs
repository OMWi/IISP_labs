using System;
using System.Text;

//TODO: доделать функционал программы, добавить класс контейнер для human и сделать индексирование
//ограничение на ввод даты рождения (в случае если больше текущего datetime то ничего не делать(мб возвр false))
//на вывод не забыть id

namespace lab3
{
    class Program
    {
        static Human AddHuman()
        {
            Human human = new Human();
            Console.WriteLine("Введите имя");
            human.Name = Console.ReadLine();
            Console.WriteLine("Введите пол");
            human.Sex = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (в формате ДД.ММ.ГГГГ)");
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Неправильный дата. Повторите ввод");
            }
            human.Birthday = birthday;
            return human;
        }

        static void PrintOptionMenu()
        {
            Console.WriteLine("1.Совершеннолетний?");
            Console.WriteLine("2.Старше х лет");
            Console.WriteLine("3.Вывести возраст");
            Console.WriteLine("4.Вывести инфо");
            Console.WriteLine("5.Продолжить");
        }

        static void Main()
        {
            Human human1 = AddHuman();
            Console.Clear();
            PrintOptionMenu();
            bool skip = false;
            while (!skip)
            {                
                ConsoleKey key = Console.ReadKey(true).Key;
                while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 &&
                    key != ConsoleKey.D4 && key != ConsoleKey.D5)
                {
                    key = Console.ReadKey(true).Key;
                }
                if(key != ConsoleKey.D5) Console.Write(key.ToString().Substring(1) + ") ");
                switch (key)
                {
                    case ConsoleKey.D1:
                        if (human1.IsAdult()) Console.WriteLine("Да");
                        else Console.WriteLine("Нет");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Введите x ");
                        int age;
                        while (!int.TryParse(Console.ReadLine(), out age))
                        {
                            Console.WriteLine("Неправильный х. Повторите ввод");
                        }
                        if (human1.IsOlder(age)) Console.WriteLine("Старше");
                        else Console.WriteLine("Не старше");
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine(human1.GetAge());
                        break;
                    case ConsoleKey.D4:
                        Console.Write(human1.GetInfo());
                        Console.WriteLine("id : " + human1.Id);
                        break;
                    case ConsoleKey.D5:
                        skip = true;
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Добавление еще одного человека");
            Human human2 = AddHuman();
            Console.Clear();
            Console.WriteLine("Инфо:\n" + human2.GetInfo() + "id : " + human2.Id);
            Console.ReadLine();
        }
    }

    public class Human
    {
        static int size = 0;
        int id;
        string name;
        string sex;
        DateTime birthday;
        public int Size
        {
            get
            {
                return size;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public Human()
        {
            size++;
            id = size;
        }
        public Human(string name, string sex, DateTime birthday) : this()
        {
            this.name = name;
            this.sex = sex;
            this.birthday = birthday;
        }
        public void SetBirthday(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            birthday = date;
        }
        public int GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age)) age--;
            return age;
        }
        public bool IsAdult()
        {
            const int adultAge = 18;
            return GetAge() >= adultAge;
        }
        public bool IsOlder(int age)
        {
            return GetAge() > age;
        }
        public virtual void Say()
        {
            Console.WriteLine("Says something");
        }
        public virtual string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("Имя : " + name);
            info.AppendLine("Пол : " + sex);
            info.AppendLine("Дата рождения : " + birthday.ToShortDateString());
            return info.ToString();
        }
    }
}