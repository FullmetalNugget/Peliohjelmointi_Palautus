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

        public TipType GetTip() {return tip;}
        public BottomType GetBottom() {return bottom;}
        public int GetLength() {return length;}

        public double PalautaHinta()
        {
            double hinta = 0;

            if (tip == TipType.Tuvala) hinta += 3;
            else if (tip == TipType.Godr) hinta += 5;
            else if (tip == TipType.Sovereign) hinta += 50;

            if (bottom == BottomType.Simple) hinta += 0;
            else if (bottom == BottomType.Refined) hinta += 1;
            else if (bottom == BottomType.Mythical) hinta += 5;

            hinta += length * 0.05;

            return hinta;
        }

        public static Nuoli LuoEliittiNuoli() => new Nuoli(TipType.Sovereign, BottomType.Mythical, 100);
        public static Nuoli LuoAloittelijaNuoli() => new Nuoli(TipType.Tuvala, BottomType.Refined, 70);
        public static Nuoli LuoPerusNuoli() => new Nuoli(TipType.Godr, BottomType.Refined, 85);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa kauppaan!");
            Console.WriteLine();

            Nuoli nuoli = null;

            Console.WriteLine("Haluatko:");
            Console.WriteLine("1. Tee oma nuoli");
            Console.WriteLine("2. Ostaa valmis nuoli");
            Console.Write("Valinta: ");
            string valinta = Console.ReadLine();

            if (valinta == "2")
            {
                Console.WriteLine();
                Console.WriteLine("Valitse valmis nuoli:");
                Console.WriteLine("1. Eliittinuoli (Sovereign tip, Mythical bottom, 100 cm)");
                Console.WriteLine("2. Aloittelijanuoli (Tuvala tip, Refined bottom, 70 cm)");
                Console.WriteLine("3. Perusnuoli (Godr tip, Refined bottom, 85 cm)");
                Console.Write("Valinta: ");
                string valmisValinta = Console.ReadLine();

                switch (valmisValinta)
                {
                    case "1": nuoli = Nuoli.LuoEliittiNuoli(); break;
                    case "2": nuoli = Nuoli.LuoAloittelijaNuoli(); break;
                    case "3": nuoli = Nuoli.LuoPerusNuoli(); break;
                }
            }
            else if (valinta == "1")
            {
                Console.WriteLine();
                Console.WriteLine("Valitse nuolen kärki: 0 = Tuvala, 1 = Godr, 2 = Sovereign");
                TipType tip = (TipType)int.Parse(Console.ReadLine());

                Console.WriteLine("Valitse nuolen perä: 0 = Simple, 1 = Refined, 2 = Mythical");
                BottomType bottom = (BottomType)int.Parse(Console.ReadLine());

                Console.WriteLine("Anna varren pituus (60–100 cm)");
                int length = int.Parse(Console.ReadLine());

                if (length < 60 || length > 100)
                {
                    Console.WriteLine("Varren pituuden on oltava 60–100 cm.");
                    return;
                }

                nuoli = new Nuoli(tip, bottom, length);
            }

            Console.WriteLine();
            Console.WriteLine($"Nuolen hinta: {nuoli.PalautaHinta():0.00} kultaa");
        }
    }
}