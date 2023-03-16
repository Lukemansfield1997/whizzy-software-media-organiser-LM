using Microsoft.VisualBasic;
using System.Windows.Forms;
using whizzy_software_media_organiser_LM.Interfaces;
using whizzy_software_media_organiser_LM.Models;
using whizzy_software_media_organiser_LM.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace whizzy_software_media_organiser_LM
{
    public partial class WhizzyMediaPlayerMain : Form
    {
        PlaylistServiceJsonDataStore _playlistService;
        CategoryServiceJsonDataStore _categoryService;
        IMediaPlayer _naudioPlayerService;
        public WhizzyMediaPlayerMain()
        {
            InitializeComponent();
            _playlistService = new PlaylistServiceJsonDataStore();
            _categoryService = new CategoryServiceJsonDataStore();
            _naudioPlayerService = new NAudioPlayerService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _playlistService.LoadPlaylists();
            _categoryService.LoadCategories();
            updateListBoxData();
        }

        //DATASOURCE/EVENT LISTENER AND HELPER METHODS
        #region
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

        private void mediaPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string defaultDirectory = folderBrowserDialog.SelectedPath;

                    MessageBox.Show($"Media path set to {defaultDirectory}");
                }
            }
        }

        private void playlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            updateMediaGridData(selectedPlaylist);
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
                    updateMediaGridData(selectedPlaylist);
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

            try
            {
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
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while saving the playlist: {ex.Message}");
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

        private void btnSaveCategories_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.SaveCategories();
                MessageBox.Show($"Categories saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the categories: {ex.Message}");
            }
        }

        private void btnDeleteSelectedCatMediaFile_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            var selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                string deleteCategoryFromMediaFile = Interaction.InputBox("Please enter the category name you want to delete from media file", "Delete Media File Category");

                var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                // if Category name parsed from users is in the media file categfories list then execute block of code in if statement
                if (mediaItem.CategoriesList.Any(c => c.CategoryName == deleteCategoryFromMediaFile))
                {
                    //newCategoriesList will check where categoryName in current list is not equal to category name user wants to delete
                    var newCategoriesList = mediaItem.CategoriesList.Where(c => c.CategoryName != deleteCategoryFromMediaFile).ToList();

                    //it will then add filtered list of categories to the newCategoriesList and mediaItem list will equal newCategoriesList
                    mediaItem.CategoriesList = newCategoriesList;
                    updateMediaGridData(selectedPlaylist);
                }
                else
                {
                    MessageBox.Show($"Error occured: Category {deleteCategoryFromMediaFile} does not exist in media file selected, please try again");
                }
            }
        }
        #endregion
        //MEDIA IMAGES CODE
        #region
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            int selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                // cast Media item at the selected index within the MediaFileItems list
                var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                if (mediaItem != null)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Image files|*.jpg;*.png;*.gif;*.bmp|All files|*.*";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string imagePath = openFileDialog.FileName;
                            string imageName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                            _playlistService.AddMediaImage(selectedPlaylist, selectedMediaFileRow, imagePath, imageName);
                            updateMediaGridData(selectedPlaylist);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Error occured: please select a valid playlist and media file you want to add a media image to");
            }
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            int selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                // cast Media item at the selected index within the MediaFileItems list
                var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                if (mediaItem != null)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        //filter for only image related formats
                        openFileDialog.Filter = "Image files|*.jpg;*.png;*.gif;*.bmp|All files|*.*";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //set imagePath and imageName to fileName selected in openFileDialog
                            string imagePath = openFileDialog.FileName;
                            string imageName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                            //parse values to EditMediaImage method
                            _playlistService.AddMediaImage(selectedPlaylist, selectedMediaFileRow, imagePath, imageName);
                            updateMediaGridData(selectedPlaylist);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Error occured: please select a valid playlist and media file you want to replace a media image with");
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            int selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            try
            {
                if (selectedMediaFileRow >= 0 && selectedPlaylist is not null)
                {
                    // cast Media item at the selected index within the MediaFileItems list
                    var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                    if (mediaItem != null)
                    {
                        _playlistService.DeleteMediaImage(selectedPlaylist, selectedMediaFileRow);
                        updateMediaGridData(selectedPlaylist);
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show($"Error occured: Invalid media file selected: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the media file image: {ex.Message}");
            }
        }
        #endregion
        //COMMENTS CODE
        #region
        private void btnAddComment_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            int selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                // cast Media item at the selected index within the MediaFileItems list
                var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                if (mediaItem != null)
                {
                    string comment = Interaction.InputBox("Add comment", "Add comment to media file");
                    mediaItem.Comment = comment;
                    updateMediaGridData(selectedPlaylist);
                }
            }
            else
            {
                MessageBox.Show("Error occured: please select a valid playlist and media file you want to add a comment to");
            }
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            int selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                // cast Media item at the selected index within the MediaFileItems list
                var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                if (mediaItem != null)
                {
                    string comment = Interaction.InputBox("Edit comment", "Edit comment to media file");
                    mediaItem.Comment = comment;
                    updateMediaGridData(selectedPlaylist);
                }
            }
            else
            {
                MessageBox.Show("Error occured: please select a valid playlist and media file you want to add a comment to");
            }
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            int selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                // cast Media item at the selected index within the MediaFileItems list
                var mediaItem = selectedPlaylist.MediaFileItems[selectedMediaFileRow];

                if (mediaItem != null)
                {
                    _playlistService.DeleteComment(selectedPlaylist, selectedMediaFileRow);
                    updateMediaGridData(selectedPlaylist);
                }
            }
            else
            {
                MessageBox.Show("Error occured: please select a valid playlist and media file you want to remove a comment");
            }
        }
        #endregion
        //AUDIO PLAYER CODE
        #region

        private void btnResume_Click(object sender, EventArgs e)
        {
            try
            {
                _naudioPlayerService.Resume();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error occured: error while playing media: {ex.Message}");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _naudioPlayerService.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error occured: error while stopping media: {ex.Message}");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                _naudioPlayerService.Pause();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error occured: error while pausing media: {ex.Message}");
            }
        }


        private void mediaFilesGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedPlaylist = (Playlist)playlistBox.SelectedItem;
            var selectedMediaFileRow = mediaFilesGridView.SelectedRows[0].Index;

            if (selectedPlaylist is not null && selectedMediaFileRow >= 0)
            {
                //media file path column index is 1
                int mediaFilePathColumn = 1;

                //this code will return the media file path value at the parse column and row index
                string mediaFilePath = mediaFilesGridView[mediaFilePathColumn, selectedMediaFileRow].Value.ToString();

                if (File.Exists(mediaFilePath))
                {
                    // Stop the current audio playback
                    _naudioPlayerService.Stop();

                    // Play the selected audio file
                    _naudioPlayerService.LoadMediaFile(mediaFilePath);
                    _naudioPlayerService.Play();
                }
            }
        }
        #endregion
    }
}
