using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace MusicPlayer
{
    public partial class PlaylistObject : UserControl
    {
        public delegate void SelectPlayList(string name, bool isQuickSelect);
        public event SelectPlayList OnSelect;
        public bool IsSelected { get => isSelected; }
        private bool isSelected;

        public PlaylistObject(string name)
        {
            InitializeComponent();
            playlistLabel.Text = name;
        }

        private void OnClick(object sender, EventArgs e)
        {
            OnSelect?.Invoke(playlistLabel.Text, isSelected);
            playlistLabel.BackColor = Color.LightBlue;
            isSelected = true;
        }
        private void OnDoubleClick(object sender, MouseEventArgs e)
        {
            OnSelect?.Invoke(playlistLabel.Text, true);
            playlistLabel.BackColor = Color.LightBlue;
            isSelected = true;
        }
        public void DeSelectObject()
        {
            playlistLabel.BackColor = Color.White;
            isSelected = false;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (!isSelected)
                playlistLabel.BackColor = Color.LightGray;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (!isSelected)
                playlistLabel.BackColor = Color.White;
        }
    }
}
