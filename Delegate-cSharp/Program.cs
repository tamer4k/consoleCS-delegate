﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate_cSharp
{
    public class Medewerker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalSel { get; set; }

    }

    public class Raport 
    {
        public delegate bool Condetion(Medewerker mw);

        public void prosesMedewerker(Medewerker[] medewerker,string title, Condetion condetion)
        {
            Console.WriteLine(title);
            Console.WriteLine("-------------------------------------");

            foreach (var m in medewerker)
            {
                if (condetion(m))
                {
                    Console.WriteLine($"{m.ID} | {m.Name} | {m.TotalSel}");
                }
            }
            Console.WriteLine("\n\n\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var medewerker = new Medewerker[]
            {
                new Medewerker{ID = 1, Name = "A", TotalSel = 3000},
                new Medewerker{ID = 2, Name = "B", TotalSel = 4000},
                new Medewerker{ID = 2, Name = "C", TotalSel = 5000},
                new Medewerker{ID = 4, Name = "D", TotalSel = 6000},
                new Medewerker{ID = 5, Name = "E", TotalSel = 7000},
                new Medewerker{ID = 6, Name = "F", TotalSel = 8000},
                new Medewerker{ID = 7, Name = "G", TotalSel = 9000},
                new Medewerker{ID = 8, Name = "H", TotalSel = 10000},

            };


            var raport = new Raport();
            raport.prosesMedewerker(medewerker,"groter of gelijk dan 8000",m => m.TotalSel >= 8000);
            raport.prosesMedewerker(medewerker, "kliener of gelijk dan 5000", m => m.TotalSel <= 5000);
            raport.prosesMedewerker(medewerker, "midden", m => m.TotalSel > 5000 && m.TotalSel < 8000);


            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);

            DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
            Console.WriteLine(dateTimeOffset);
            dateTimeOffset = DateTimeOffset.UtcNow;
            Console.WriteLine(dateTimeOffset);
            Console.WriteLine(IsWeenkend(dt));




            Console.WriteLine(Process.GetCurrentProcess().Id );
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);


            Console.ReadKey();
        }

        public static bool IsWeenkend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }





}
