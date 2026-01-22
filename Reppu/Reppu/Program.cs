using System;
using System.Collections.Generic;
using System.Linq;

namespace Reppu
{
    public class Tavara
    {
        public double Paino { get; }
        public double Tilavuus { get; }

        public Tavara(double paino, double tilavuus)
        {
            Paino = paino;
            Tilavuus = tilavuus;
        }

        public override string ToString()
        {
            return $"{GetType().Name} (Paino: {Paino}, Tilavuus: {Tilavuus})";
        }
    }

    public class Nuoli : Tavara { public Nuoli() : base(0.1, 0.05) { } }
    public class Jousi : Tavara { public Jousi() : base(1, 4) { } }
    public class Köysi : Tavara { public Köysi() : base(1, 1.5) { } }
    public class Vesi : Tavara { public Vesi() : base(2, 2) { } }
    public class RuokaAnnos : Tavara { public RuokaAnnos() : base(1, 0.5) { } }
    public class Miekka : Tavara { public Miekka() : base(5, 3) { } }

    public class Reppu
    {
        private List<Tavara> tavarat = new();

        public int MaxTavarat { get; }
        public double MaxPaino { get; }
        public double MaxTilavuus { get; }

        public int Tavaroita => tavarat.Count;
        public double Paino => tavarat.Sum(t => t.Paino);
        public double Tilavuus => tavarat.Sum(t => t.Tilavuus);

        public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
        {
            MaxTavarat = maxTavarat;
            MaxPaino = maxPaino;
            MaxTilavuus = maxTilavuus;
        }

        public bool Lisää(Tavara tavara)
        {
            if (Tavaroita + 1 > MaxTavarat) return false;
            if (Paino + tavara.Paino > MaxPaino) return false;
            if (Tilavuus + tavara.Tilavuus > MaxTilavuus) return false;

            tavarat.Add(tavara);
            return true;
        }

        public void TulostaTila()
        {
            Console.WriteLine($"\nReppu:");
            Console.WriteLine($" Tavaroita: {Tavaroita}/{MaxTavarat}");
            Console.WriteLine($" Paino: {Paino}/{MaxPaino}");
            Console.WriteLine($" Tilavuus: {Tilavuus}/{MaxTilavuus}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Reppu reppu = new Reppu(10, 15, 15);

            while (true)
            {
                Console.Clear();
                reppu.TulostaTila();

                Console.WriteLine("\n1 Nuoli");
                Console.WriteLine("2 Jousi");
                Console.WriteLine("3 Köysi");
                Console.WriteLine("4 Vesi");
                Console.WriteLine("5 Ruoka-annos");
                Console.WriteLine("6 Miekka");
                Console.WriteLine("0 Lopeta");

                string valinta = Console.ReadLine();
                Tavara tavara = valinta switch
                {
                    "1" => new Nuoli(),
                    "2" => new Jousi(),
                    "3" => new Köysi(),
                    "4" => new Vesi(),
                    "5" => new RuokaAnnos(),
                    "6" => new Miekka(),
                    "0" => null,
                    _ => null
                };

                if (tavara == null) break;

                if (reppu.Lisää(tavara))
                    Console.WriteLine("Tavara lisätty.");
                else
                    Console.WriteLine("Ei mahdu reppuun.");
            }
        }
    }
}