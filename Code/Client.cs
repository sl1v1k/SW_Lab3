using System;

class Client
{
    private static void Main(string[] args)
    {
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
        
        Search();
    }

    private static void Search()
    {
        var genres = (MusicGenres[]) Enum.GetValues(typeof(MusicGenres));
        for (var i = 0; i < genres.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {genres[i]}");
        }
        
        Console.WriteLine("Please chose & type genre:");
        var choice = Console.ReadLine();
        var dbpediaMusicService = new DbpediaMusicService();

        if (int.TryParse(choice, out var result) && result > genres.Length)
        {
            Console.WriteLine("Incorrect input");
        }
        else
        {
            var artists = dbpediaMusicService.GetArtistsByGenre(genres[result - 1]);

            Console.WriteLine("\nArtists:");
            for (var i = 0; i < artists.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {artists[i].Name}, (Genres: {string.Join(", ", artists[i].Genres)})");
            }
            Console.WriteLine($"Type 'Q' to back");
            
            Console.WriteLine("Please chose artist for more:");
            choice = Console.ReadLine();

            if (choice is "Q" or "q")
            {
                Console.Clear();
                Search();
            }
            else
            {
                if (int.TryParse(choice, out result) && result > artists.Count)
                {
                    Console.WriteLine("Incorrect input");
                }
                else
                {
                    var info = artists[result - 1].Info;
                    Console.WriteLine("About artist: " + info);
                }
            }
        }
    }
}