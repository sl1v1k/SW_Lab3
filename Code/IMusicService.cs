using System.Collections.Generic;

// Інтерфейс для роботи з різними провайдерами даних
public interface IMusicService
{
    List<Artist> GetArtistsByGenre(MusicGenres musicGenreType, int limit = 100);
}