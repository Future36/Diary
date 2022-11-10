using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ежедневник
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            DateTime Nowdata = DateTime.Today;
            int k = 0;
            int position = 2;
            List<DateTime> DataListik = new List<DateTime>();
            List<string> NameListik = new List<string>();
            List<string> txtListik = new List<string>();
            List<string> TimeListik = new List<string>();
            Menu();
            while (true)
            {
                Console.SetCursorPosition(2, 1);
                Console.WriteLine(Nowdata);
                key = Console.ReadKey();
                UpDown();
                LeftTight();

                Console.Clear();
                Menu();
                zametki();
                zapis();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            void Menu()
            {
                Console.Clear();
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("  Добавить заметку");
            }
            void zametki()
            {
                for (int i = 0; i < k; ++i)
                {
                    if (DataListik.Count > 0)
                    {
                        if ((Nowdata.Year == DataListik[i].Year) && (Nowdata.Month == DataListik[i].Month) && (Nowdata.Day == DataListik[i].Day))
                        {
                            Console.SetCursorPosition(2, 3 + i);
                            Console.WriteLine(NameListik[i]);
                            if ((key.Key == ConsoleKey.Enter) && (position == 3 + i))
                            {
                                Console.Clear();
                                Console.SetCursorPosition(2, 3);
                                Console.WriteLine("Дата заметки" + DataListik[i]);
                                Console.SetCursorPosition(2, 4);
                                Console.WriteLine(NameListik[i]);
                                Console.SetCursorPosition(2, 5);
                                Console.WriteLine(txtListik[i]);
                                Console.SetCursorPosition(2, 6);
                                Console.WriteLine("Дата создания заметки" + TimeListik[i]);
                                Console.WriteLine("Нажмите Esc для выхода");
                                key = Console.ReadKey();
                                Console.Clear();
                            }
                        }
                    }
                }
            }
            void UpDown()
            {
                if (key.Key == ConsoleKey.UpArrow && position > 2)
                {
                    position--;
                }
                else if (key.Key == ConsoleKey.DownArrow && position > 1)
                {
                    position++;
                }
            }
            void LeftTight()
            {
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    Nowdata = Nowdata.AddDays(-1);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    Nowdata = Nowdata.AddDays(1);
                }
            }
            void zapis()
            {
                if ((key.Key == ConsoleKey.Enter) && (position == 2))
                {
                    Console.Clear();
                    DataListik.Add(Nowdata);

                    Console.WriteLine("Введите название заметки:");
                    NameListik.Add(Console.ReadLine());

                    Console.WriteLine("Введите описание заметки:");
                    txtListik.Add(Console.ReadLine());
                    DateTime Dz = DateTime.Now;
                    string Datezam = $"{Dz}";
                    TimeListik.Add(Datezam);
                    Console.Clear();
                    k += 1;
                    Menu();
                }
            }
        }
    }
}

