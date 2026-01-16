using System;
using System.Collections.Generic;

namespace Ruoka_Annos
{
    enum Ruoka { Nautaa, Kanaa, Kasviksia }
    enum Lisuke { Perunaa, Riisia, Pastaa }
    enum Kastike { Curry, Hapanimela, Pippuri, Chili }

    class Ateria
    {
        public Ruoka Ruoka { get; init; }
        public Lisuke Lisuke { get; init; }
        public Kastike Kastike { get; init; }

        public override string ToString() =>
            $"{Ruoka} ja {Lisuke} {Kastike}-kastikkeella".ToLower();
    }

    internal class Program
    {
        static void Main()
        {
            var ateriat = new List<Ateria>();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Ateria {i}");

                ateriat.Add(new Ateria
                {
                    Ruoka = KysyValinta<Ruoka>("liha"),
                    Lisuke = KysyValinta<Lisuke>("lisuke"),
                    Kastike = KysyValinta<Kastike>("kastike")
                });

                Console.WriteLine();
            }

            Console.WriteLine("Valitsemasi ateriat:");
            ateriat.ForEach(a => Console.WriteLine(a));
        }

        static T KysyValinta<T>(string nimi) where T : Enum
        {
            Console.WriteLine($"Valitse {nimi}:");
            foreach (var arvo in Enum.GetValues(typeof(T)))
                Console.WriteLine($"{(int)arvo} = {arvo}");

            return (T)Enum.Parse(typeof(T), Console.ReadLine());
        }
    }
}