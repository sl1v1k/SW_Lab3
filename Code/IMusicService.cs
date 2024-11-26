using System.Collections.Generic;

// Інтерфейс для роботи з різними провайдерами даних
public interface IMusicService
{
    SparqlClient SparqlClient { get; set; }
    
    List<Artist> GetArtistsByGenre(MusicGenres musicGenreType, int limit = 100);
}