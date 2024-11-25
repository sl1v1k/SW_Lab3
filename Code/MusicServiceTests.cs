using Xunit;

// Юніт тест для перевірки роботи
public class MusicServiceTests
{
    [Fact]
    public void GetArtistsByGenre_Test()
    {
        var service = new DbpediaMusicService();
        var artists = service.GetArtistsByGenre(MusicGenres.Pop);
        
        Assert.NotNull(artists);
        Assert.True(artists.Count > 0);
    }
}