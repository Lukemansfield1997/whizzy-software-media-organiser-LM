using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using whizzy_software_media_organiser_LM.Models;
using whizzy_software_media_organiser_LM.Services;

namespace whizzy_software_media_organiser_LM
{
    public partial class CategoryManager : Form
    {
        CategoryService _categoryService;
        DataGridView _mediaDataGridView;
        ListBox _playistBox;

        //Parse an instance of categoryService, mediaDataGridView and playlistBox to the CategoryManager form
        //these objects are created in the WhizzyMediaPlayerMain Form 
        public CategoryManager(CategoryService categoryService,DataGridView mediaDataGridView, ListBox playistBox)
        {
            InitializeComponent();
            this._categoryService = categoryService;
            this._mediaDataGridView = mediaDataGridView;
            this._playistBox = playistBox;
        }

        public void UpdateCategoryManagerDataSource()
        {
            checkedCategoryBox.ClearSelected();
            checkedCategoryBox.DataSource = null;

            BindingSource bs = new BindingSource();
            bs.DataSource = _categoryService.GetCategories();
            checkedCategoryBox.DataSource = bs;
            checkedCategoryBox.DisplayMember = "CategoryName";
            checkedCategoryBox.ValueMember = "CategoryID";
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)_playistBox.SelectedItem;

            //gets the selected row in the mediaDataGridView
            int selectedMediaFileRow = _mediaDataGridView.SelectedRows[0].Index;

            //loop through all of the category items in Category Manager
            for (int i = 0; i < checkedCategoryBox.CheckedItems.Count; i++)
            {
                //Foreach category item, if category item check state is checked, assign category to media file 
                if (checkedCategoryBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    _categoryService.AssignCategoriesToMediaFile(selectedMediaFileRow, selectedPlaylist);             
                    _mediaDataGridView.Refresh();
                    UpdateCategoryManagerDataSource();
                }
            }
        }

        private void btnRenameCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCategories_Click(object sender, EventArgs e)
        {

        }
    }
}
