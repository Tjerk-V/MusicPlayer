using System.Text.Json;

namespace MusicPlayer
{
    public class PlaylistData
    {
        public List<string>? Files { get; set; }
    }

    public class Playlist
    {
        public static List<string> GetPlaylists()
        {
            if (!Directory.Exists("Playlists"))
                Directory.CreateDirectory("Playlists");
            
            List<string> playlistPaths = Directory.EnumerateFiles("Playlists", "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith("json")).ToList();

            List<string> playlistNames = [];
            playlistPaths.ForEach(p =>
            {
                playlistNames.Add(p.Replace(@"Playlists\", "").Replace(".json", ""));
            });
            return playlistNames;
        }

        public static void SavePlaylist(string name, List<AudioObject> audioObjects)
        {
            if (!Directory.Exists("Playlists"))
                Directory.CreateDirectory("Playlists");

            PlaylistData data = new() 
            { 
                Files = audioObjects.Select(a => a.FilePath).ToList(),
            };
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(@"Playlists\"+name+".json", json);            
        }

        public static PlaylistData GetPlaylistData(string name)
        {
            string file = @"Playlists\" + name + ".json";
            string fileData = File.ReadAllText(file);
            return JsonSerializer.Deserialize<PlaylistData>(fileData);            
        }

        public static void DeletePlaylist(string name)
        {
            File.Delete(@"Playlists\" + name + ".json");
        }
    }
}
