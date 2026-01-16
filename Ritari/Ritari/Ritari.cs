using System.Security.Cryptography;

namespace Ritari
{
    internal class Program
    {
        static void Main(string[] args)

        {
            int O_HP = 15;
            int R_HP = 15;
            int O_dmg = 2;
            Random rng = new Random();
            int dmg = rng.Next(1, 6);
            Console.WriteLine("Olet ritari, joka on yrittänyt saada avattua console app'ia noin 20 minuuttia, kun hän on saanut sen toimimaan örkki hyökkää sinuun");
            Console.WriteLine($"Örkki {O_HP}/15");
            Console.WriteLine($"Sinä {R_HP}/15");
            while (O_HP > 0 && R_HP > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Mitä aijot tehdä?");
                Console.WriteLine();
                Console.WriteLine("1 - Täräytä örkkiä miekalla");
                Console.WriteLine($"2 - Puolusta itseaäsi kilvellä");
                Console.Write("Valintasi: ");
                int vastaus = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (vastaus == 1)
                    O_HP -= dmg;
                else if (vastaus == 2)
                    O_dmg /= 2;
                else
                    Console.WriteLine("Valitse 1 tai 2");
                if (O_HP > 0)
                    R_HP -= 1;
                Console.WriteLine($"Örkki {O_HP}/15");
                Console.WriteLine($"Sinä {R_HP}/15");
            }
            Console.WriteLine("Sinä voitit!!!");
        }
    }
}
