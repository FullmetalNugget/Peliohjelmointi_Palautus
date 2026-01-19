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
        private TipType tip;
        private BottomType bottom;
        private int length;

        public Nuoli(TipType tip, BottomType bottom, int length)
        {
            this.tip = tip;
            this.bottom = bottom;
            this.length = length;
        }

        // Getterit
        public TipType GetTip()
        {
            return tip;
        }

        public BottomType GetBottom()
        {
            return bottom;
        }

        public int GetLength()
        {
            return length;
        }

        public double PalautaHinta()
        {
            double hinta = 0;

            hinta += tip switch
            {
                TipType.Tuvala => 3,
                TipType.Godr => 5,
                TipType.Sovereign => 50,
                _ => 0
            };

            hinta += bottom switch
            {
                BottomType.Simple => 0,
                BottomType.Refined => 1,
                BottomType.Mythical => 5,
                _ => 0
            };

            hinta += length * 0.05;

            return hinta;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervettuloa kauppaan!");
            Console.WriteLine();

            Console.WriteLine("Valitse kärki: 0 = Tuvala, 1 = Godr, 2 = Sovereign");
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
