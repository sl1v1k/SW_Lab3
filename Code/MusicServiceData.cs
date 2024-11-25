using System.Collections.Generic;

public enum MusicGenres
{
    Pop = 0,
    Rap = 1,
    Rock = 2,
    Metal = 3,
    Electronic = 4
}

public static class MusicServiceData
{
    public static List<string> GetSubGenresByGenre(MusicGenres musicGenre)
    {
        switch (musicGenre)
        {
            case MusicGenres.Pop:
                return GetPopSubGenres();
            case MusicGenres.Rap:
                return GetRapSubGenres();
            case MusicGenres.Rock:
                return GetRockSubGenres();
            case MusicGenres.Metal:
                return GetMetalSubGenres();
            case MusicGenres.Electronic:
                return GetElectronicSubGenres();
            default:
                return [];
        }
    }

    private static List<string> GetPopSubGenres()
    {
        return
        [
            "Pop_rock", "Pop", "Pop_rock", "Pop_music", "Power_pop", "Psychedelic_pop", "Electropop", "Country_pop",
            "Pop_rock",
            "Folk-pop", "Pop_punk", "Indie_pop", "Parody", "Novelty", "Comedy", "Dance_music", "Baroque_pop",
            "Folk_music", "Jazz", "Dance-pop", "Europop", "Indie_pop"
        ];
    }
    
    private static List<string> GetRapSubGenres()
    {
        return
        [
            "Rap_music", "Rapcore", "Rap-rock", "Rap_rock", "Hip_hop_music", "Alternative_hip_hop", "Ukrainian_hip_hop",
            "Funk"
        ];
    }
    
    private static List<string> GetRockSubGenres()
    {
        return
        [
            "Rock", "Ukrainian_rock", "Rock_music", "Punk_rock", "Dub_music", "Latin_rock", "Folk_rock", "Gypsy_punk",
            "Pop_punk", "Pop_rock", "Glam_rock", "Art_pop", "Post-punk", "New_wave_music", "Blues_rock", "Acid_rock",
            "Psychedelic_rock", "Experimental_rock", "Post-punk"
        ];
    }
    
    private static List<string> GetMetalSubGenres()
    {
        return
        [
            "Nu_metal_musical_groups", "Hardcore_punk", "Nu_metal", "Ukrainian_rock_music_groups", "Black_metal",
            "Glam_metal", "Heavy_metal_music", "Hard_rock", "Arena_rock"
        ];
    }
    
    private static List<string> GetElectronicSubGenres()
    {
        return
        [
            "Electronic_music", "Experimental_music", "Chillwave", "Electronic_drum", 
            "Trance_music", "Synth-pop", "Disco", "House_music", "Dance-pop", "Techno", "Nu-disco"
        ];
    }
}