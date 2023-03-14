using Microsoft.VisualBasic;
using System.Windows.Forms;
using whizzy_software_media_organiser_LM.Models;
using whizzy_software_media_organiser_LM.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace whizzy_software_media_organiser_LM
{
    public partial class WhizzyMediaPlayerMain : Form
    {
        PlaylistServiceJsonDataStore _playlistService;
        CategoryService _categoryService;
        public WhizzyMediaPlayerMain()
        {
            InitializeComponent();
            _playlistService = new PlaylistServiceJsonDataStore();
            _categoryService = new CategoryService();
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
            // Unbinds the data source from the mediaDataGridView control
            playlistBox.DataSource = null;

            // Bind the data source to a new instance of BindingSource
            BindingSource bs = new BindingSource();
            bs.DataSource = _playlistService.GetPlayLists();
            playlistBox.DataSource = bs;

            //set display and value member to correct properties 
            playlistBox.DisplayMember = "PlaylistName";
            playlistBox.ValueMember = "PlaylistID";

        }

        public void updateMediaGridData(Playlist playlist)
        {
            if (playlist != null && playlistBox.SelectedIndex >= 0)
            {
                // Unbinds the data source from the mediaDataGridView control
                mediaFilesGridView.DataSource = null;

                // Clear the rows and columns
                mediaFilesGridView.Rows.Clear();
                mediaFilesGridView.Columns.Clear();

                // Bind the data source to a new instance of BindingSource
                BindingSource bs = new BindingSource();
                bs.DataSource = playlist.MediaFileItems;
                mediaFilesGridView.DataSource = bs;

                //set columns and cells to Autosize
                mediaFilesGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                //Set row selection to FullRowSelect to avoid index out of range exception for adding Categories to media 
                mediaFilesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //set media grid view to read only so user can only add and delete values from the windows controls I have created
                mediaFilesGridView.ReadOnly = true;
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
                            MessageBox.Show($"{playlistName} is created");
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
        #endregion
        //MEDIA FILES CODE
        #region
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
        // CATEGORIES CODE
        #region
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            bool categoryNameExists = true;

            while (categoryNameExists)
            {
                string categoryName = Interaction.InputBox("Enter category name", "create category");

                //Check if categoryName entered is null
                switch (string.IsNullOrEmpty(categoryName))
                {
                    //if true, display message box showing the error
                    case true:
                        MessageBox.Show("Error occured: Category name cannot be empty, please try again.");
                        categoryNameExists = false;
                        break;

                    //if false but the category name exists in allCategories using Linq, display message box showing the error
                    case false:
                        if (_categoryService.GetCategories().Any(c => c.CategoryName == categoryName))
                        {
                            MessageBox.Show("Error occured: Category name already exists, please try again.");
                            categoryNameExists = true;
                        }
                        else
                        {
                            //create new instance of category
                            _categoryService.CreateCategory(categoryName);
                            MessageBox.Show($"{categoryName} is created");
                            categoryNameExists = false;
                        }
                        break;
                }
            }
        }
        #endregion

        private void btnManageMediaFileCats_Click(object sender, EventArgs e)
        {
            //when manage media files categories is clicked, create an instance of CategoryManager form
            //show form in context of a dialog box
            using (CategoryManager categoryManager = new CategoryManager(_categoryService, mediaFilesGridView, playlistBox))
            {
                categoryManager.UpdateCategoryManagerDataSource();
                categoryManager.ShowDialog();
            }
        }
    }
}