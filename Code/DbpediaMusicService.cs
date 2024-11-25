using System.Collections.Generic;
using System.Text;

// Клас для роботи з даними про музику
public class DbpediaMusicService : IMusicService
{
    private readonly SparqlClient _sparqlClient;

    public DbpediaMusicService()
    {
        _sparqlClient = new SparqlClient("https://dbpedia.org/sparql");
    }
    
    // Метод який повертає список українських виконавців за жанром
    public List<Artist> GetArtistsByGenre(MusicGenres musicGenreType, int limit = 100)
    {
        var genres = MusicServiceData.GetSubGenresByGenre(musicGenreType);
        var sb = new StringBuilder();
        foreach (var genre in genres)
        {
            sb.AppendLine($"                    dbr:{genre}");
        }
        
        var query = $@"
                SELECT DISTINCT ?artist ?artistLabel (GROUP_CONCAT(DISTINCT ?genreLabel; separator=', ') AS ?genres) ?abstract
                WHERE {{
                  ?artist dbo:genre ?genre;
                          dbo:hometown dbr:Ukraine;
                          rdfs:label ?artistLabel;
                          dbo:abstract ?abstract.
                  ?genre rdfs:label ?genreLabel.
                  
                  VALUES ?genre {{
{sb}
                  }}
  
                  FILTER (LANG(?artistLabel) = 'en' && LANG(?genreLabel) = 'en' && LANG(?abstract) = 'en')
                }}
                GROUP BY ?artist ?artistLabel ?genreLabel ?abstract
                LIMIT {limit}";
        
        var results = _sparqlClient.ExecuteQuery(query);
        var artists = new List<Artist>();

        foreach (var result in results)
        {
            var name = result["artistLabel"].ToString().Split('@')[0].Trim('"');;
            var genre = result["genres"]?.ToString().Split('^')[0].Trim('"') ?? "No data found";
            var info = result["abstract"]?.ToString().Split('@')[0].Trim('"') ?? "No data found";

            artists.Add(new Artist(name, genre, info));
        }

        return artists;
    }
}