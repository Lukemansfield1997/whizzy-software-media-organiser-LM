using Microsoft.VisualBasic;
using whizzy_software_media_organiser_LM.Models;
using whizzy_software_media_organiser_LM.Services;

namespace whizzy_software_media_organiser_LM
{
    public partial class Form1 : Form
    {
        PlaylistService _playlistService;
        public Form1()
        {
            InitializeComponent();
            _playlistService = new PlaylistService();
        }
        #region
        //Datasource helper methods
        public void updateListBoxData()
        {
            playlistBox.DataSource = null;
            playlistBox.DataSource = _playlistService.GetPlayLists();
            playlistBox.DisplayMember = "PlaylistName";
            playlistBox.ValueMember = "PlaylistID";

        }
        #endregion

        //Playlists code
        #region
        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            bool playlistNameExists = true;

            while (playlistNameExists)
            {
                string playlistName = Interaction.InputBox("Enter playlist name", "create playlist");

                //Check if playlistName entered is null
                switch (string.IsNullOrEmpty(playlistName))
                {
                    //if true, display message box showing the error
                    case true:
                        MessageBox.Show("Error: Playlist name cannot be empty, please try again.");
                        playlistNameExists = false;
                        break;

                    //if false but the playlist name exists in allPlaylists using Linq, display message box showing the error
                    case false:
                        if (_playlistService.GetPlayLists().Any(p => p.PlayListName == playlistName))
                        {
                            MessageBox.Show("Error: Playlist name already exists, please try again.");
                            playlistNameExists = true;
                        }
                        else
                        {
                            //create new instance of playlist and update ListBox datasource
                            var playlist = _playlistService.CreatePlaylist(playlistName);
                            updateListBoxData();
                            playlistNameExists = false;
                        }
                        break;
                }
            }
        }

        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            //Cast selected item in playlistBox as Playlist object
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;

            if (selectedPlaylist is not null)
            {
                try
                {
                    //parse selected playlist ID to DeletePlaylist method, which will remove object from allPlaylists
                    _playlistService.DeletePlaylist(selectedPlaylist.PlayListID);
                    MessageBox.Show($"playlist: {selectedPlaylist.PlayListName} is deleted from your playlists");
                    updateListBoxData();
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Error: Please select a playlist from Playlists to delete");
            }
        }

        private void btnRenamePlaylist_Click(object sender, EventArgs e)
        {
            //Get selected playlist in PlaylistBox
            Playlist selectedPlaylist = (Playlist)playlistBox.SelectedItem;

            bool playlistNameExists = true;

            while (playlistNameExists)
            {
                string playlistName = Interaction.InputBox("Please enter a new name for your playlist", "Rename Playlist");

                switch (string.IsNullOrEmpty(playlistName))
                {
                    case true:
                        MessageBox.Show("Playlist name cannot be empty, please try again.");
                        playlistNameExists = false;
                        break;

                    case false:
                        if (_playlistService.GetPlayLists().Any(p => p.PlayListName == playlistName))
                        {
                            MessageBox.Show("Playlist name already exists, please try again.");
                            playlistNameExists = true;
                        }
                        else
                        {
                            _playlistService.RenamePlaylist(selectedPlaylist, playlistName);
                            MessageBox.Show($"Playlist is now renamed as {playlistName}");
                            updateListBoxData();
                            playlistNameExists = false;
                        }
                        break;

                }
            }
        }
        #endregion

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {

        }
    }
}