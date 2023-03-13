using Microsoft.VisualBasic;
using whizzy_software_media_organiser_LM.Models;
using whizzy_software_media_organiser_LM.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace whizzy_software_media_organiser_LM
{
    public partial class Form1 : Form
    {
        PlaylistServiceJsonDataStore _playlistService;
        public Form1()
        {
            InitializeComponent();
            _playlistService = new PlaylistServiceJsonDataStore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _playlistService.LoadPlaylists();
            updateListBoxData();
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

        public void updateMediaGridData(Playlist playlist)
        {
            if (playlist != null && playlistBox.SelectedIndex >= 0)
            {
                mediaFilesGridView.DataSource = null;
                mediaFilesGridView.DataSource = playlist.MediaFileItems;
                mediaFilesGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); 
            }
        }
        #endregion

        //PLAYLIST CODE
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
                        MessageBox.Show("Error occured: Playlist name cannot be empty, please try again.");
                        playlistNameExists = false;
                        break;

                    //if false but the playlist name exists in allPlaylists using Linq, display message box showing the error
                    case false:
                        if (_playlistService.GetPlayLists().Any(p => p.PlayListName == playlistName))
                        {
                            MessageBox.Show("Error occured: Playlist name already exists, please try again.");
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
                    MessageBox.Show($"Playlist: {selectedPlaylist.PlayListName} is deleted from your playlists");
                    updateListBoxData();
                }
                //will catch exception for index out of range and inform the user
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                //will catch exception for file not found and inform the user
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occured:: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Error occured: Please select a playlist from Playlists to delete");
            }
        }

        private void btnRenamePlaylist_Click(object sender, EventArgs e)
        {
            //Get selected playlist in PlaylistBox
            Playlist selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            string oldPlaylistName = "";

            if (selectedPlaylist is not null)
            {
               oldPlaylistName = selectedPlaylist.PlayListName;
                bool playlistNameExists = true;

                while (playlistNameExists)
                {
                    string playlistName = Interaction.InputBox("Please enter a new name for your playlist", "Rename Playlist");

                    switch (string.IsNullOrEmpty(playlistName))
                    {
                        case true:
                            MessageBox.Show("Error occured: Playlist name cannot be empty, please try again.");
                            playlistNameExists = false;
                            break;

                        case false:
                            if (_playlistService.GetPlayLists().Any(p => p.PlayListName == playlistName))
                            {
                                MessageBox.Show("Error occured: Playlist name already exists, please try again.");
                                playlistNameExists = true;
                            }
                            else
                            {
                                _playlistService.RenamePlaylist(selectedPlaylist, playlistName);
                                MessageBox.Show($"Playlist {oldPlaylistName} is now renamed as {playlistName}");
                                updateListBoxData();
                                playlistNameExists = false;
                            }
                            break;

                    }
                }
            }
            else
            {
                MessageBox.Show("Error occured: Please select a playlist from Playlists to rename");
            }
        }

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;

            if (selectedPlaylist is not null)
            {
                _playlistService.SavePlaylist(selectedPlaylist);
                MessageBox.Show($"Playlist: {selectedPlaylist.PlayListName} is saved");
            }
            else
            {
                MessageBox.Show("Error occured: Please select a playlist from your Playlists to save");
            }
        }

        private void btnSelectMediaFiles_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;

            if (selectedPlaylist is not null)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Audio files|*.mp3;*.wav;*.aac;*.flac;*.wma*|All files|*.*";
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var mediaFile in openFileDialog.FileNames)
                        {
                            _playlistService.AddMediaFileToPlaylist(selectedPlaylist.PlayListID, mediaFile);
                        }
                        updateMediaGridData(selectedPlaylist);
                    }

                }
            }
            else
            {
                MessageBox.Show("Error occured: Please select the playlist you want to add media files to");
            }
        }
        #endregion

        private void playlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            updateMediaGridData(selectedPlaylist);
        }
    }
}