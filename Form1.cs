using System.Diagnostics;
using NAudio.Wave;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private bool mouseIsTakingOver;

        int currentMinutes, currentSeconds;
        int maxMinutes, maxSeconds;
        PlaylistState playlistState = PlaylistState.Shuffle;

        int currentAudioListIndex;
        readonly List<AudioObject> audioObjects = [];
        readonly List<AudioObject> previousPlayedAudios = [];
        readonly List<AudioObject> playedAudios = [];

        readonly List<PlaylistObject> playlistObjects = [];

        public Form1()
        {
            InitializeComponent(); 
            System.Windows.Forms.Timer tmr = new()
            {
                Interval = 10
            };
            tmr.Tick += Update;
            tmr.Start();
            PlaylistControlClick(null, null);
            LoadPlaylists();
        }
        private void Update(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                currentMinutes = audioFile.CurrentTime.Minutes;
                currentSeconds = audioFile.CurrentTime.Seconds;


                int currentMilliseconds = (int)audioFile.CurrentTime.TotalMilliseconds;
                if (!mouseIsTakingOver && currentMilliseconds < audioTrack.Maximum)
                    audioTrack.Value = currentMilliseconds;

                if (Threshold(currentMilliseconds, (int)audioFile.TotalTime.TotalMilliseconds, 15) && playlistState != PlaylistState.End)
                    PlayNextAudio(null, null);

            }
            SetAudioTime(currentMinutes, currentSeconds, maxMinutes, maxSeconds);
            buttonPlay.Text = (outputDevice?.PlaybackState == PlaybackState.Playing) ? "||" : ">";
        }
        private void SetAudioTime(int currentMinutes, int currentSeconds, int maxMinutes, int maxSeconds)
        {
            string currentTimeString = currentMinutes.ToString().PadLeft(2, '0') + ":" + currentSeconds.ToString().PadLeft(2, '0');
            string totalTimeString = maxMinutes.ToString().PadLeft(2, '0') + ":" + maxSeconds.ToString().PadLeft(2, '0');
            audioTime.Text = currentTimeString + "/" + totalTimeString;
        }
        private static bool Threshold(float num1, float num2, float threshold)
        {
            float sum = num1 - num2;
            return threshold > MathF.Abs(sum);
        }

        #region Playlist
        private void SavePlaylist(object sender, EventArgs e)
        {
            if (playlistTextbox.Text.Trim() == string.Empty)
            {
                playlistNameError.SetError(playlistTextbox, "Name can't be empty");
                return;
            }
            if (audioObjects.Count == 0)
            {
                playlistNameError.SetError(playlistTextbox, "playlist can't be empty");
                return;
            }
            playlistNameError.Clear();
            Playlist.SavePlaylist(playlistTextbox.Text, audioObjects);
            LoadPlaylists();
        }
        private void LoadPlaylists()
        {
            List<string> playlistNames = Playlist.GetPlaylists();
            playlistsPanel.Controls.Clear();
            playlistNames.ForEach(CreateNewPlaylistObject);
        }
        private void LoadPlaylist(List<string> audioFiles)
        {
            foreach (string f in audioFiles)
                CreateNewAudioObject(f);
        }
        private void DeletePlaylist(object s, EventArgs e)
        {
            Playlist.DeletePlaylist(playlistTextbox.Text);
            LoadPlaylists();
        }

        #endregion

        #region AudioControl
        private async void PlayAudio(string filePath)
        {
            if (audioFile != null && outputDevice != null)
            {
                OnPlaybackEnd(null, null);
                await Task.Delay(100);
            }

            SetOutputDevice();
            SetAudioFile(filePath);
            maxMinutes = audioFile.TotalTime.Minutes;
            maxSeconds = audioFile.TotalTime.Seconds;
            outputDevice?.Play();
        }
        private void SetAudioFile(string filePath)
        {
            audioFile = new AudioFileReader(filePath);
            outputDevice.Init(audioFile);
            audioTrack.Maximum = (int)audioFile.TotalTime.TotalMilliseconds;
            audioFile.Volume = (float)volumeTrack.Value / 100;
            for (int i = 0; i < audioObjects.Count; i++)
            {
                if (audioObjects[i].FilePath == filePath)
                    currentAudioListIndex = i;
            }
        }
        private void SetOutputDevice()
        {
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackEnd;
        }
        private void PlayNextAudio(object sender, EventArgs args)
        {
            AudioObject nextAudioObject;
            if (playlistState == PlaylistState.Shuffle)
            {
                nextAudioObject = Shuffle(true);
            }
            else
            {
                nextAudioObject = (currentAudioListIndex < audioObjects.Count - 1) ? audioObjects[currentAudioListIndex + 1] : audioObjects[0];
                AddOrInsertAudio(true);
            }

            nextAudioObject.OnClick(null, null);

        }
        private void PlayPreviousAudio(object sender, EventArgs args)
        {
            AudioObject previousAudioObject;
            if (playlistState == PlaylistState.Shuffle)
                previousAudioObject = Shuffle();
            else
            {
                previousAudioObject = (currentAudioListIndex > 0) ? audioObjects[currentAudioListIndex - 1] : audioObjects[^1];
                AddOrInsertAudio();
            }

            previousAudioObject.OnClick(null, null);
        }
        private AudioObject Shuffle(bool isForward = false)
        {
            AudioObject ao;
            if (previousPlayedAudios.Count > 0 && !isForward)
            {
                ao = previousPlayedAudios[^1];
                previousPlayedAudios.RemoveAt(previousPlayedAudios.Count - 1);
            }
            else if (!isForward)
            {
                ao = GetRandomAudio();
                AddOrInsertAudio();

            }
            else
            {
                ao = GetRandomAudio();
                AddOrInsertAudio(true);
            }
            return ao;
        }
        private void AddOrInsertAudio(bool add = false)
        {
            if (add)
            {
                previousPlayedAudios.Add(audioObjects[currentAudioListIndex]);
                if (previousPlayedAudios.Count > 2)
                    previousPlayedAudios.RemoveAt(0);
            }
            else
            {
                previousPlayedAudios.Insert(0, audioObjects[currentAudioListIndex]);
                if (previousPlayedAudios.Count > 2)
                    previousPlayedAudios.RemoveAt(previousPlayedAudios.Count - 1);
            }
        }
        private AudioObject GetRandomAudio()
        {
            AudioObject ao;
            do
            {
                Random rnd = new();
                int r = rnd.Next(audioObjects.Count);
                ao = audioObjects[r];
            } while (previousPlayedAudios.Contains(ao) || ao == audioObjects[currentAudioListIndex]);
            return ao;
        }
        private void OnPlaybackEnd(object sender, StoppedEventArgs args)
        {
            audioTrack.Value = 0;
            currentMinutes = 0; currentSeconds = 0; 
            maxMinutes = 0; maxSeconds = 0;
            outputDevice?.Dispose();
            outputDevice = null;
            audioFile?.Dispose();
            audioFile = null;
        }
        #endregion

        #region AudioUIControl
        private void OnButtonPlayClick(object sender, EventArgs args)
        {
            switch (outputDevice?.PlaybackState)
            {
                case PlaybackState.Playing:
                    outputDevice.Pause();
                    break;
                case PlaybackState.Paused:
                    outputDevice.Play();
                    break;
                default:
                    PlayAudio(audioObjects[currentAudioListIndex].FilePath);
                    break;
            }
        }
        private void OnButtonStopClick(object sender, EventArgs args)
        {
            outputDevice?.Stop();
        }
        private void VolumeTrackValueChanged(object sender, EventArgs e)
        {
            if (audioFile != null)
                audioFile.Volume = (float)volumeTrack.Value / 100;
            volumeText.Text = volumeTrack.Value.ToString();
        }
        private void Skip(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds - 5);
            else if (e.KeyCode == Keys.Right)
                audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds + 5);
        }
        private void AudioTrackMouseDown(object sender, MouseEventArgs e)
        {
            TrackBar? trackBar = sender as TrackBar;
            mouseIsTakingOver = true;
            if (trackBar?.Tag == "audio")
                MoveAudioTrackToMouse(e.X);
            else if (trackBar?.Tag == "volume")
                MoveVolumeTrackToMouse(e.Y);
        }
        private void AudioTrackMouseUp(object sender, MouseEventArgs e)
        {
            mouseIsTakingOver = false;
        }
        private void AudioTrackMouseMove(object sender, MouseEventArgs e)
        {
            TrackBar? trackBar = sender as TrackBar;
            if (trackBar?.Tag == "audio" && mouseIsTakingOver)
                MoveAudioTrackToMouse(e.X);
            else if ((trackBar?.Tag == "volume"))
                MoveVolumeTrackToMouse(e.Y);
        }
        private void MoveVolumeTrackToMouse(int mouseYPos)
        {
            int value = (int)(((float)mouseYPos / (float)volumeTrack.Height) * volumeTrack.Maximum + 0.5f);
            volumeTrack.Value = value;
        }
        private void MoveAudioTrackToMouse(int mouseXPos)
        {
            int value = (int)(((float)mouseXPos / (float)audioTrack.Width) * audioTrack.Maximum + 0.5f);
            audioTrack.Value = (value < 0) ? 0 : value;
            if (audioFile != null)
                audioFile.CurrentTime = TimeSpan.FromMilliseconds(value);
        }
        private void PlaylistControlClick(object sender, EventArgs e)
        {
            switch (playlistState)
            {
                case PlaylistState.End:
                    playlistControl.Text = "A";
                    playlistState = PlaylistState.Auto;
                    break;
                case PlaylistState.Auto:
                    playlistControl.Text = "S";
                    playlistState = PlaylistState.Shuffle;
                    break;
                case PlaylistState.Shuffle:
                    playlistControl.Text = "E";
                    playlistState = PlaylistState.End;
                    break;
            }
        }
        #endregion

        #region EditControls
        private void EditCLick(object sender, EventArgs e)
        {
            editPanel.Visible = !editPanel.Visible;
        }
        private void LabelEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.LightGray;
        }
        private void LabelLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.White;
        }
        private void LabelClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            switch (label.Tag)
            {
                case "d":
                    OpenFileDirectory();
                    break;
                case "f":
                    OpenFile();
                    break;
                case "c":
                    ClearAudioObjects();
                    break;
                case "r":
                    RemoveAudioObject();
                    break;
            }
        }
        private void OpenFileDirectory()
        {
            FolderBrowserDialog folder = new();
            if (folder.ShowDialog(this) == DialogResult.OK)
            {
                IEnumerable<string> files = AudioFilesCollector.GetAudioFiles(folder.SelectedPath);
                foreach (string f in files)
                    CreateNewAudioObject(f);
            }
        }
        private void RemoveAudioObject()
        {
            try
            {
                AudioObject a = audioObjects.Single(a => a.IsSelected);
                OnPlaybackEnd(null, null);
                audioObjects.Remove(a);
                audioPanel.Controls.Remove(a);
            }
            catch { }
        }
        private void OpenFile()
        {
            OpenFileDialog ofd = new()
            {
                Title = "Select an audio file",
                Filter = "Audio|*.wav;*.mp3",
                Multiselect = true,
            };
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.FileNames.ToList().ForEach(CreateNewAudioObject);                
            }
        }
        private void ClearAudioObjects()
        {
            OnPlaybackEnd(null, null);
            audioPanel.Controls.Clear();
            audioObjects.Clear();
        }
        #endregion

        private void CreateNewPlaylistObject(string p)
        {
            Debug.WriteLine(p);
            PlaylistObject pO = new(p);
            pO.OnSelect += OnPlayListSelect;
            playlistObjects.Add(pO);
            playlistsPanel.Controls.Add(pO);
        }
        private void CreateNewAudioObject(string audioFilePath)
        {
            AudioObject audioObject = new(audioFilePath);
            audioObject.OnAudioClick += OnAudioSelect;
            audioPanel.Controls.Add(audioObject);
            audioObjects.Add(audioObject);
        }
        private void OnAudioSelect(AudioObject audioObject)
        {
            audioObjects.Where(i => i.IsSelected).ToList().ForEach(i => i.DeSelectObject());
            PlayAudio(audioObject.FilePath);
        }
        private void OnPlayListSelect(string name, bool isQuickSelect)
        {
            playlistObjects.Where(i => i.IsSelected).ToList().ForEach(i => i.DeSelectObject());
            playlistTextbox.Text = name;
            if (isQuickSelect)
            {
                audioPanel.Controls.Clear();
                LoadPlaylist(Playlist.GetPlaylistData(name).Files);
            }
        }
    }
}
