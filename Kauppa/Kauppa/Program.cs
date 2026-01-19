using System;

namespace Kauppa
{
    enum TipType
    {
        Tuvala,
        Godr,
        Sovereign
    }

    enum BottomType
    {
        Simple,
        Refined,
        Mythical
    }

    class Nuoli
    {
        public TipType Tip { get;}
        public BottomType Bottom { get;}
        public int Length { get;}

        public Nuoli(TipType tip, BottomType bottom, int length)
        {
            Tip = tip;
            Bottom = bottom;
            Length = length;
        }

        public double PalautaHinta()
        {
            double hinta = 0;

            hinta += Tip switch
            {
                TipType.Tuvala => 3,
                TipType.Godr => 5,
                TipType.Sovereign => 50,
                _ => 0
            };

            hinta += Bottom switch
            {
                BottomType.Simple => 0,
                BottomType.Refined => 1,
                BottomType.Mythical => 5,
                _ => 0
            };

            hinta += Length * 0.05;

            return hinta;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervettuloa kauppaan!");
            Console.WriteLine();

            Console.WriteLine("Valitse kärki: 0 = Tuvala, 1 = Teräs, 2 = Sovereign");
            TipType Tip = (TipType)int.Parse(Console.ReadLine());

            Console.WriteLine("Valitse perä: 0 = Simple, 1 = Refined, 2 = Mythical");
            BottomType Bottom = (BottomType)int.Parse(Console.ReadLine());

            Console.WriteLine("Anna varren pituus (60–100 cm)");
            int pituus = int.Parse(Console.ReadLine());

            Nuoli nuoli = new Nuoli(Tip, Bottom, pituus);

            Console.WriteLine();
            Console.WriteLine($"Nuolen hinta: {nuoli.PalautaHinta():0.00} kultaa");
        }
    }
}
