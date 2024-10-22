using MusicPlayer.Properties;
using TagLib;

namespace MusicPlayer
{
    public partial class AudioObject : UserControl
    {
        #region Events

        public delegate void PlayAudio(AudioObject audioObject);
        public event PlayAudio OnAudioClick;
        #endregion

        #region Members
        private string filePath;
        private bool isSelected;
        TagLib.File metaData;
        #endregion
          
        #region Properties
        public string FilePath { get=> filePath;}
        public bool IsSelected { get => isSelected; }
        #endregion
        public AudioObject(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();            
            SetAttributes(filePath);
        }

        private void SetAttributes(string filePath)
        {
            Stream stream = System.IO.File.OpenRead(filePath);
            StreamFileAbstraction streamFileAbstraction = new(filePath, stream, stream);
            try
            {
                metaData = TagLib.File.Create(streamFileAbstraction);
            }
            catch
            {
                metaData = null;
            }
            string title = metaData?.Tag.Title;
            string artist = metaData?.Tag.FirstPerformer;
            IPicture[] pictures = metaData?.Tag.Pictures;
            audioName.Text = title ?? RemoveFilePath(filePath);
            authorName.Text = artist ?? "Unknown";
            albumThumbnail.Image = GetAlbumThumbnail(pictures);
            metaData?.Dispose();
            stream.Close();
            
        }

        private Image GetAlbumThumbnail(IPicture[]? pictures)
        {
            if(pictures?.Length > 0)
            {
                IPicture pic = pictures[0];
                MemoryStream ms = new(pic.Data.Data);
                
                try
                {
                    Image img = Image.FromStream(ms);
                    Bitmap downScaledImg = new(img, new Size(100, 100));
                    ms.Dispose();
                    img.Dispose();
                    return downScaledImg;

                }catch
                {
                    ms.Dispose();
                    return Resources.NoThumbnail;
                }               
            }
            return Resources.NoThumbnail;
        }

        private string RemoveFilePath(string audioFile)
        {
            audioFile = audioFile.Split(@"\")[^1];
            return audioFile.Remove(audioFile.Length - 4);
        }

        public void OnClick(object sender, EventArgs e)
        {
            OnAudioClick?.Invoke(this);
            bgPanel.BackColor = Color.LightBlue;
            BackColor = Color.LightBlue;
            isSelected = true;
        }

        private void OnEnter(object sender, EventArgs e)
        {
            if (isSelected) return;
            bgPanel.BackColor = Color.LightGray;
            BackColor = Color.LightGray;
        }
        private void OnLeave(object sender, EventArgs e)
        {
            if (isSelected) return;
            bgPanel.BackColor = Color.White;
            BackColor = Color.White;
        }
        public void DeSelectObject()
        {
            bgPanel.BackColor = Color.White;
            BackColor = Color.White;
            isSelected = false;
        }
    }
}
