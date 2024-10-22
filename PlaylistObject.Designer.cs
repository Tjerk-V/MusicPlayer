namespace MusicPlayer
{
    partial class PlaylistObject
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            playlistLabel = new Label();
            SuspendLayout();
            // 
            // playlistLabel
            // 
            playlistLabel.Location = new Point(0, 0);
            playlistLabel.Name = "playlistLabel";
            playlistLabel.Size = new Size(100, 23);
            playlistLabel.TabIndex = 0;
            playlistLabel.Text = "Playlist Name";
            playlistLabel.TextAlign = ContentAlignment.MiddleLeft;
            playlistLabel.Click += OnClick;
            playlistLabel.MouseDoubleClick += OnDoubleClick;
            playlistLabel.MouseEnter += OnMouseEnter;
            playlistLabel.MouseLeave += OnMouseLeave;
            // 
            // PlaylistObject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(playlistLabel);
            Name = "PlaylistObject";
            Size = new Size(100, 22);
            ResumeLayout(false);
        }

        #endregion

        private Label playlistLabel;
    }
}
