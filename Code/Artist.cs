// Клас дата виконавця
public class Artist
{
    public string Name { get; set; }
    public string Genres { get; set; }
    public string Info { get; set; }

    public Artist(string name, string genre, string info)
    {
        Name = name;
        Genres = genre;
        Info = info;
    }
}