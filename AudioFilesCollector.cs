namespace MusicPlayer
{
    public class AudioFilesCollector
    {
        public static IEnumerable<string> GetAudioFiles(string selectedPath)
        {
            return Directory.EnumerateFiles(selectedPath, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith("mp3") || f.EndsWith("wav"));
        }
    }
}
