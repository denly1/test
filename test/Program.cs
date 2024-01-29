using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Data;
using Newtonsoft.Json;

namespace TestLetter
{
    internal class Inf
    {
        public string nik;
        public int simvsek;
        public int simvmin;

    }
    internal class Program
    {
        public static int sek = 60;
        public static int pos = 1;
        public static int b = 0;
        static void Main()
        {
            Base();
        }
        static void Timer1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(60000);
            stopwatch.Stop();
        }
        public static void Base()
        {
            sek = 60;
            pos = 0;
            b = 0;

            Console.Clear();
            Thread timer = new Thread(new ThreadStart(Timer1));
            Console.WriteLine("Введите ваш никнейм");
            Inf polz = new Inf();
            polz.nik = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("При готовности, нажмите \"Enter\"");
            ConsoleKeyInfo klavisha = Console.ReadKey();
            Thread timer2 = new Thread(_ =>
            {
                while (sek != 0)
                {
                    string del = new string(' ', 4);
                    Console.SetCursorPosition(1, 10);
                    Console.Write(sek);
                    Console.WriteLine(del);
                    Console.SetCursorPosition(pos, b);
                    Thread.Sleep(1000);
                    sek--;
                }
            });
            if (klavisha.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.SetCursorPosition(pos, 0);
                string text = ("Арбуз – однолетнее травянистое растение семейства тыквенные. Его признали ягодой и это справедливо: у него есть кожица, сочная мякоть и множество семечек внутри. Хотя он подходит и под описание фрукта – это ведь цветущее растение, которое приносит плоды после того, как распустятся его цветы.");
                Console.Write(text);
                timer2.Start();
                timer.Start();
                int a = 0;
                while (timer.IsAlive)
                {
                    if (pos == 116)
                    {
                        b++;
                        pos = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    klavisha = Console.ReadKey();

                    if (klavisha.Key == ConsoleKey.Backspace)
                    {
                        if (pos == 0)
                        {
                            b--;
                            pos = 116;
                        }
                        a--;
                        polz.simvmin--;
                        Console.ResetColor();
                        Console.SetCursorPosition(pos--, b);
                        Console.WriteLine(text[pos + 1]);
                    }
                    else
                    {
                        a++;
                        pos++;
                        polz.simvmin++;
                        Console.SetCursorPosition(pos, b);
                    }

                    if (klavisha.Key == ConsoleKey.Enter)
                    {
                        timer2.Abort();
                        timer.Abort();
                    }
                }
                polz.simvsek = polz.simvmin / 60;
                Console.SetCursorPosition(0, 15);
                Console.ResetColor();
                Console.WriteLine($"Введено символов {polz.simvmin}, введено символов в секунду {polz.simvsek}");
                Tabl.Tablicalid(polz);
            }
            Main();
        }
    }
    internal class Tabl
    {
        public static List<string> lider = new List<string>();
        public static List<Inf> hum = new List<Inf>();
        public static void Tablicalid(Inf user)
        {
            Console.Clear();
            string min = Convert.ToString(user.simvmin);
            string sek = Convert.ToString(user.simvsek);
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Таблица рекордов");
            lider.Add(user.nik);
            lider.Add(min);
            lider.Add(sek);
            hum.Add(user);
            foreach (string i in lider)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Для повтора нажмите Enter");
            ConsoleKeyInfo clavisha = Console.ReadKey();
            if (clavisha.Key == ConsoleKey.Escape)
                Environment.Exit(0);
            if (clavisha.Key == ConsoleKey.Enter)
                Program.Base();

            string json = JsonConvert.SerializeObject(hum);
        }
    }
}