namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            audioTrack = new TrackBar();
            buttonPlay = new Button();
            buttonStop = new Button();
            volumeTrack = new TrackBar();
            volumeText = new Label();
            audioPanel = new FlowLayoutPanel();
            controlsPanel = new Panel();
            playlistControl = new Button();
            Previous = new Button();
            Next = new Button();
            audioTime = new Label();
            playlistSaver = new Button();
            playlistsPanel = new FlowLayoutPanel();
            playlistTextbox = new TextBox();
            playlistNameError = new ErrorProvider(components);
            button2 = new Button();
            editPanel = new FlowLayoutPanel();
            dir = new Label();
            file = new Label();
            clear = new Label();
            label1 = new Label();
            edit = new Label();
            ((System.ComponentModel.ISupportInitialize)audioTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeTrack).BeginInit();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playlistNameError).BeginInit();
            editPanel.SuspendLayout();
            SuspendLayout();
            // 
            // audioTrack
            // 
            audioTrack.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            audioTrack.AutoSize = false;
            audioTrack.Location = new Point(3, 2);
            audioTrack.Maximum = 0;
            audioTrack.Name = "audioTrack";
            audioTrack.Size = new Size(846, 20);
            audioTrack.SmallChange = 5;
            audioTrack.TabIndex = 1;
            audioTrack.Tag = "audio";
            audioTrack.TickStyle = TickStyle.None;
            audioTrack.KeyDown += Skip;
            audioTrack.MouseDown += AudioTrackMouseDown;
            audioTrack.MouseMove += AudioTrackMouseMove;
            audioTrack.MouseUp += AudioTrackMouseUp;
            // 
            // buttonPlay
            // 
            buttonPlay.Anchor = AnchorStyles.None;
            buttonPlay.Location = new Point(429, 28);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(23, 23);
            buttonPlay.TabIndex = 0;
            buttonPlay.Text = ">";
            buttonPlay.Click += OnButtonPlayClick;
            // 
            // buttonStop
            // 
            buttonStop.Anchor = AnchorStyles.None;
            buttonStop.Location = new Point(451, 28);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(23, 23);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "[]";
            buttonStop.Click += OnButtonStopClick;
            // 
            // volumeTrack
            // 
            volumeTrack.Anchor = AnchorStyles.None;
            volumeTrack.AutoSize = false;
            volumeTrack.LargeChange = 20;
            volumeTrack.Location = new Point(502, 17);
            volumeTrack.Maximum = 100;
            volumeTrack.Name = "volumeTrack";
            volumeTrack.Orientation = Orientation.Vertical;
            volumeTrack.Size = new Size(23, 61);
            volumeTrack.SmallChange = 10;
            volumeTrack.TabIndex = 3;
            volumeTrack.TickStyle = TickStyle.None;
            volumeTrack.Value = 100;
            volumeTrack.ValueChanged += VolumeTrackValueChanged;
            volumeTrack.MouseDown += AudioTrackMouseDown;
            volumeTrack.MouseMove += AudioTrackMouseMove;
            volumeTrack.MouseUp += AudioTrackMouseUp;
            // 
            // volumeText
            // 
            volumeText.Anchor = AnchorStyles.None;
            volumeText.Location = new Point(502, 74);
            volumeText.Name = "volumeText";
            volumeText.Size = new Size(25, 15);
            volumeText.TabIndex = 4;
            volumeText.Text = "100";
            // 
            // audioPanel
            // 
            audioPanel.AllowDrop = true;
            audioPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            audioPanel.AutoScroll = true;
            audioPanel.BackColor = Color.FromArgb(250, 250, 250);
            audioPanel.BorderStyle = BorderStyle.Fixed3D;
            audioPanel.Location = new Point(120, 29);
            audioPanel.Name = "audioPanel";
            audioPanel.Size = new Size(807, 379);
            audioPanel.TabIndex = 5;
            // 
            // controlsPanel
            // 
            controlsPanel.BorderStyle = BorderStyle.FixedSingle;
            controlsPanel.Controls.Add(playlistControl);
            controlsPanel.Controls.Add(volumeText);
            controlsPanel.Controls.Add(Previous);
            controlsPanel.Controls.Add(Next);
            controlsPanel.Controls.Add(audioTime);
            controlsPanel.Controls.Add(audioTrack);
            controlsPanel.Controls.Add(volumeTrack);
            controlsPanel.Controls.Add(buttonPlay);
            controlsPanel.Controls.Add(buttonStop);
            controlsPanel.Dock = DockStyle.Bottom;
            controlsPanel.Location = new Point(0, 414);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(930, 91);
            controlsPanel.TabIndex = 0;
            // 
            // playlistControl
            // 
            playlistControl.Anchor = AnchorStyles.None;
            playlistControl.Location = new Point(473, 28);
            playlistControl.Name = "playlistControl";
            playlistControl.Size = new Size(23, 23);
            playlistControl.TabIndex = 8;
            playlistControl.Text = "L";
            playlistControl.Click += PlaylistControlClick;
            // 
            // Previous
            // 
            Previous.Anchor = AnchorStyles.None;
            Previous.Location = new Point(429, 54);
            Previous.Margin = new Padding(0);
            Previous.Name = "Previous";
            Previous.Size = new Size(32, 20);
            Previous.TabIndex = 7;
            Previous.Text = "<<";
            Previous.Click += PlayPreviousAudio;
            // 
            // Next
            // 
            Next.Anchor = AnchorStyles.None;
            Next.Location = new Point(464, 54);
            Next.Margin = new Padding(0);
            Next.Name = "Next";
            Next.Size = new Size(32, 20);
            Next.TabIndex = 6;
            Next.Text = ">>";
            Next.Click += PlayNextAudio;
            // 
            // audioTime
            // 
            audioTime.Anchor = AnchorStyles.Right;
            audioTime.Location = new Point(847, 2);
            audioTime.Name = "audioTime";
            audioTime.Size = new Size(78, 20);
            audioTime.TabIndex = 5;
            audioTime.Text = "00:00/00:00";
            audioTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // playlistSaver
            // 
            playlistSaver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            playlistSaver.Location = new Point(4, 385);
            playlistSaver.Name = "playlistSaver";
            playlistSaver.Size = new Size(55, 23);
            playlistSaver.TabIndex = 9;
            playlistSaver.Text = "Save";
            playlistSaver.UseVisualStyleBackColor = true;
            playlistSaver.Click += SavePlaylist;
            // 
            // playlistsPanel
            // 
            playlistsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            playlistsPanel.AutoScroll = true;
            playlistsPanel.BackColor = Color.FromArgb(250, 250, 250);
            playlistsPanel.BorderStyle = BorderStyle.Fixed3D;
            playlistsPanel.Location = new Point(4, 29);
            playlistsPanel.Name = "playlistsPanel";
            playlistsPanel.Size = new Size(111, 334);
            playlistsPanel.TabIndex = 0;
            // 
            // playlistTextbox
            // 
            playlistTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            playlistTextbox.Location = new Point(4, 363);
            playlistTextbox.Name = "playlistTextbox";
            playlistTextbox.Size = new Size(110, 23);
            playlistTextbox.TabIndex = 10;
            // 
            // playlistNameError
            // 
            playlistNameError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            playlistNameError.ContainerControl = this;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(59, 385);
            button2.Name = "button2";
            button2.Size = new Size(55, 23);
            button2.TabIndex = 11;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DeletePlaylist;
            // 
            // editPanel
            // 
            editPanel.BorderStyle = BorderStyle.FixedSingle;
            editPanel.Controls.Add(dir);
            editPanel.Controls.Add(file);
            editPanel.Controls.Add(clear);
            editPanel.Controls.Add(label1);
            editPanel.FlowDirection = FlowDirection.TopDown;
            editPanel.Location = new Point(3, 27);
            editPanel.Margin = new Padding(3, 10, 3, 3);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(93, 83);
            editPanel.TabIndex = 13;
            editPanel.Visible = false;
            // 
            // dir
            // 
            dir.Location = new Point(3, 0);
            dir.Name = "dir";
            dir.Size = new Size(89, 19);
            dir.TabIndex = 0;
            dir.Tag = "d";
            dir.Text = "Directory";
            dir.TextAlign = ContentAlignment.MiddleLeft;
            dir.Click += LabelClick;
            dir.MouseEnter += LabelEnter;
            dir.MouseLeave += LabelLeave;
            // 
            // file
            // 
            file.Location = new Point(3, 19);
            file.Name = "file";
            file.Size = new Size(89, 19);
            file.TabIndex = 1;
            file.Tag = "f";
            file.Text = "File";
            file.TextAlign = ContentAlignment.MiddleLeft;
            file.Click += LabelClick;
            file.MouseEnter += LabelEnter;
            file.MouseLeave += LabelLeave;
            // 
            // clear
            // 
            clear.Location = new Point(3, 38);
            clear.Name = "clear";
            clear.Size = new Size(89, 19);
            clear.TabIndex = 2;
            clear.Tag = "c";
            clear.Text = "Clear";
            clear.TextAlign = ContentAlignment.MiddleLeft;
            clear.Click += LabelClick;
            clear.MouseEnter += LabelEnter;
            clear.MouseLeave += LabelLeave;
            // 
            // label1
            // 
            label1.Location = new Point(3, 57);
            label1.Name = "label1";
            label1.Size = new Size(89, 19);
            label1.TabIndex = 3;
            label1.Tag = "r";
            label1.Text = "Remove Audio";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += LabelClick;
            label1.MouseEnter += LabelEnter;
            label1.MouseLeave += LabelLeave;
            // 
            // edit
            // 
            edit.AutoSize = true;
            edit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            edit.Location = new Point(4, 9);
            edit.Name = "edit";
            edit.Size = new Size(28, 15);
            edit.TabIndex = 12;
            edit.Text = "Edit";
            edit.Click += EditCLick;
            edit.MouseEnter += LabelEnter;
            edit.MouseLeave += LabelLeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 505);
            Controls.Add(editPanel);
            Controls.Add(edit);
            Controls.Add(playlistTextbox);
            Controls.Add(button2);
            Controls.Add(playlistSaver);
            Controls.Add(playlistsPanel);
            Controls.Add(controlsPanel);
            Controls.Add(audioPanel);
            Name = "Form1";
            Text = "Music Player";
            FormClosing += OnButtonStopClick;
            ((System.ComponentModel.ISupportInitialize)audioTrack).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeTrack).EndInit();
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)playlistNameError).EndInit();
            editPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar audioTrack;
        private Button buttonPlay;
        private Button buttonStop;
        private TrackBar volumeTrack;
        private Label volumeText;
        private FlowLayoutPanel audioPanel;
        private Panel controlsPanel;
        private Label audioTime;
        private Button Next;
        private Button Previous;
        private Button playlistControl;
        private Button playlistSaver;
        private FlowLayoutPanel playlistsPanel;
        private TextBox playlistTextbox;
        private ErrorProvider playlistNameError;
        private Button button2;
        private FlowLayoutPanel editPanel;
        private Label dir;
        private Label file;
        private Label clear;
        private Label edit;
        private Label label1;
    }
}
