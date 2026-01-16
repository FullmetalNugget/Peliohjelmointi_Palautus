namespace Ovi
{
    internal class Program
    {
        enum state
        {
            auki,
            kiinni,
            lukossa
        }

        static void Main(string[] args)
        {
            state door = state.auki;

            while (true)
            {
                Console.WriteLine("Ovi on " + door);
                Console.WriteLine("Mitä haluat tehdä: ");
                string vastaus = Console.ReadLine();

                switch (vastaus)
                {
                    case "avaa":
                        if (door == state.lukossa)
                        {
                            Console.WriteLine("Ovi on lukossa sinun pitää avata lukko");
                        }
                        else
                        {
                            door = state.auki;
                            Console.WriteLine("Avasit oven");
                        }
                        break;

                    case "sulje":
                        if (door == state.auki)
                        {
                            door = state.kiinni;
                            Console.WriteLine("Suljit oven");
                        }
                        else
                        {
                            Console.WriteLine("Ovi on joko kiinni tai lukossa");
                        }
                        break;

                    case "lukitse":
                        if (door == state.kiinni)
                        {
                            door = state.lukossa;
                            Console.WriteLine("Lukitsit oven");
                        }
                        else if (door == state.auki)
                        {
                            Console.WriteLine("Ovi on auki, lukitse se ensin");
                        }
                        else
                        {
                            Console.WriteLine("Ovi on jo lukossa");
                        }
                        break;

                    case "avaa lukko":
                        if (door == state.lukossa)
                        {
                            door = state.kiinni;
                            Console.WriteLine("Avasit lukon. Ovi on nyt kiinni.");
                        }
                        else if (door == state.kiinni)
                        {
                            Console.WriteLine("Lukko on jo auki.");
                        }
                        else
                        {
                            Console.WriteLine("Ovi on auki");
                        }
                        break;

                    case "quit":
                        return;

                    default:
                        Console.WriteLine("??");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}