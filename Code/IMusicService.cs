using System.Collections.Generic;

public interface IMusicService
{
    List<Artist> GetArtistsByGenre(MusicGenres musicGenreType, int limit = 100);
}