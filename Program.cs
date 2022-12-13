using System;
using System.IO;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Security.AccessControl;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Net.Security;
using System.Data.Common;

namespace SFModule9
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Exceptions = new List<Exception>
            {
                new ArgumentOutOfRangeException(),
                new FormatException(),
                new IndexOutOfRangeException(),
                new NotImplementedException(),
                new MyOwnException("Мое собственное исключение.")
            };

            List<string> team = new List<string>
            {
                "Иванов",
                "Петров",
                "Сидоров",
                "Кузнецов"
            };

            ///Анкетирование
            Console.WriteLine("Добро пожаловать в нашу команду. Назовите вашу фамилию.");

            string newMember = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(newMember))
            {
                Console.WriteLine("Ничего не введено или введеное неверное значение. Фамилия не может быть пустым полем. Мы будем звать вас Хитрец.");
                newMember = "Хитрец";
            }

            Console.WriteLine();

            TryCatch(Exceptions);

            team.Add(newMember);

            ///Выбор метода сортировки
            Console.WriteLine("Вы приняты. Сейчас мы вам всех представим - как хотете отсортировать список команды?");
            Console.WriteLine("1. От А до Я");
            Console.WriteLine("2. От Я до А");

            int sortType;

            while (!int.TryParse(Console.ReadLine(), out sortType) || sortType < 1 || sortType > 2)
            {
                try
                {
                    throw new MyOwnException();
                }
                catch (MyOwnException ex)
                {
                    Console.WriteLine("{0} Пользователь ввел не цифру 1 или 2.", ex.Message);
                    Console.WriteLine();
                }

                Console.WriteLine("Вы ввели неверное значение. Ответ должен быть целым числом больше нуля и меньше трех. Введите правильное значение: ");
            }

            Console.Write("Отсортированный состав команды: ");
            Console.WriteLine();

            foreach (string i in Sorting(sortType, team))
            {
                Console.WriteLine("{0}", i);
            }

            Console.ReadKey();

        }

        public static List<string> Sorting(int sortType, List<string> team)
        {
            team.Sort();

            if (sortType == 1)
            {
                return team;
            }
            else
            {
                team.Reverse();
                return team;
            }
        }

        public static void TryCatch(List<Exception> Exceptions)
        {
            foreach (Exception item in Exceptions)
            {
                try
                {
                    throw item;
                }
                catch (MyOwnException ex)
                {
                    Console.WriteLine("Исключение возникло в {0}.", DateTime.Now);
                    Console.WriteLine("{0}", ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Исключение возникло в {0}.", DateTime.Now);
                    Console.WriteLine("{0}", ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Исключение возникло в {0}.", DateTime.Now);
                    Console.WriteLine("{0}", ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Исключение возникло в {0}.", DateTime.Now);
                    Console.WriteLine("{0}", ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                catch (NotImplementedException ex)
                {
                    Console.WriteLine("Исключение возникло в {0}.", DateTime.Now);
                    Console.WriteLine("{0}", ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
        }
    }

    public class MyOwnException : FormatException
    {
        public MyOwnException()
        {

        }

        public MyOwnException(string message) : base(message)
        {

        }
    }
}