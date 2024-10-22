namespace MusicPlayer
{
    partial class AudioObject
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
            audioName = new Label();
            albumThumbnail = new PictureBox();
            bgPanel = new Panel();
            authorName = new Label();
            ((System.ComponentModel.ISupportInitialize)albumThumbnail).BeginInit();
            bgPanel.SuspendLayout();
            SuspendLayout();
            // 
            // audioName
            // 
            audioName.AutoEllipsis = true;
            audioName.Cursor = Cursors.Hand;
            audioName.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audioName.Location = new Point(3, 111);
            audioName.Name = "audioName";
            audioName.Size = new Size(124, 41);
            audioName.TabIndex = 0;
            audioName.Text = "Audio name";
            audioName.TextAlign = ContentAlignment.TopCenter;
            audioName.Click += OnClick;
            audioName.MouseEnter += OnEnter;
            audioName.MouseLeave += OnLeave;
            // 
            // albumThumbnail
            // 
            albumThumbnail.Cursor = Cursors.Hand;
            albumThumbnail.Image = Properties.Resources.NoThumbnail;
            albumThumbnail.Location = new Point(17, 6);
            albumThumbnail.Name = "albumThumbnail";
            albumThumbnail.Size = new Size(100, 100);
            albumThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            albumThumbnail.TabIndex = 1;
            albumThumbnail.TabStop = false;
            albumThumbnail.Click += OnClick;
            albumThumbnail.MouseEnter += OnEnter;
            albumThumbnail.MouseLeave += OnLeave;
            // 
            // bgPanel
            // 
            bgPanel.Anchor = AnchorStyles.None;
            bgPanel.Controls.Add(audioName);
            bgPanel.Controls.Add(albumThumbnail);
            bgPanel.Controls.Add(authorName);
            bgPanel.Cursor = Cursors.Hand;
            bgPanel.Location = new Point(5, 5);
            bgPanel.Name = "bgPanel";
            bgPanel.Size = new Size(130, 170);
            bgPanel.TabIndex = 2;
            bgPanel.Click += OnClick;
            bgPanel.MouseEnter += OnEnter;
            // 
            // authorName
            // 
            authorName.AutoEllipsis = true;
            authorName.Cursor = Cursors.Hand;
            authorName.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            authorName.Location = new Point(3, 152);
            authorName.Name = "authorName";
            authorName.Size = new Size(124, 18);
            authorName.TabIndex = 1;
            authorName.Text = "author";
            authorName.TextAlign = ContentAlignment.MiddleCenter;
            authorName.Click += OnClick;
            authorName.MouseEnter += OnEnter;
            authorName.MouseLeave += OnLeave;
            // 
            // AudioObject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bgPanel);
            Name = "AudioObject";
            Size = new Size(140, 180);
            MouseEnter += OnEnter;
            MouseLeave += OnLeave;
            ((System.ComponentModel.ISupportInitialize)albumThumbnail).EndInit();
            bgPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label audioName;
        private PictureBox albumThumbnail;
        public Panel bgPanel;
        private Label authorName;
    }
}
