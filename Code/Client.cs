using System;

class Client
{
    // Cтартова точка програми
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("                                                                      ");
        Console.WriteLine("   __  __                 _          _____               _   _         ");
        Console.WriteLine(" |  \\/  |               (_)        |  __ \\             | | (_)        ");
        Console.WriteLine(" | \\  / |  _   _   ___   _    ___  | |__) |   ___    __| |  _    __ _ ");
        Console.WriteLine(" | |\\/| | | | | | / __| | |  / __| |  ___/   / _ \\  / _` | | |  / _` |");
        Console.WriteLine(" | |  | | | |_| | \\__ \\ | | | (__  | |      |  __/ | (_| | | | | (_| |");
        Console.WriteLine(" |_|  |_|  \\__,_| |___/ |_|  \\___| |_|       \\___|  \\__,_| |_|  \\__,_|");
        Console.WriteLine("                                                                      ");
        Console.WriteLine("                                                                      ");
        Console.WriteLine("Welcome to MusicPedia");
        
        StartMusicService(new DbpediaMusicService());
    }

    // Метод який запускає сервіс для пошуку даних
    private static void StartMusicService(IMusicService musicService)
    {
        while (true)
        {
            var genres = (MusicGenres[]) Enum.GetValues(typeof(MusicGenres));
            for (var i = 0; i < genres.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {genres[i]}");
            }
        
            Console.WriteLine("Please choose genre (Enter 0 to exit):");
            var choice = Console.ReadLine();
            if (choice is "0")
            {
                Environment.Exit(0);
            }

            // Перевірка на валідні вхідні дані
            if (int.TryParse(choice, out var result) && result <= genres.Length && result > 0)
            {
                // Запит на пошук
                var artists = musicService.GetArtistsByGenre(genres[result - 1]);
                Console.WriteLine("\nArtists:");
                for (var i = 0; i < artists.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {artists[i].Name}, (Genres: {string.Join(", ", artists[i].Genres)})");
                }

                Console.WriteLine("Choose artist for more information (Enter 0 to go back, Q to quit):");
                choice = Console.ReadLine();
                if (choice is "0")
                {
                    Console.Clear();
                }
                else if (choice is "Q" or "q")
                {
                    Environment.Exit(0);
                }

                if (int.TryParse(choice, out result) && result <= artists.Count && result > 0)
                {
                    var info = artists[result - 1].Info;
                    Console.WriteLine("About artist: " + info);
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Press 0 to go back, Q to quit");
                    choice = Console.ReadLine();
                    if (choice is "0")
                    {
                        Console.Clear();
                    }
                    else if (choice is "Q" or "q")
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}