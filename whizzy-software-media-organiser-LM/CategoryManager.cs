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
            checkedCategoryBox.DataSource = null;

            BindingSource bs = new BindingSource();
            bs.DataSource = _categoryService.GetCategories();
            checkedCategoryBox.DataSource = bs;
            checkedCategoryBox.DisplayMember = "CategoryName";
            checkedCategoryBox.ValueMember = "CategoryID";
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            var checkedCategories = new List<Category>();

            //Get CheckedItems in Category Manager and add to List so items in the list are fixed and can be enumerated
            foreach (var selectedCat in checkedCategoryBox.CheckedItems)
            {
                var selectedCategory = (Category)selectedCat;
                checkedCategories.Add(selectedCategory);
            }

            //if list has 1 or more item then execute AssignCategoriestoMediaFile method
            if (checkedCategories.Count > 0)
            {
                //gets the selected playlist in the playlistBox
                var selectedPlaylist = (Playlist)_playistBox.SelectedItem;

                //gets the selected row in the mediaDataGridView
                int selectedMediaFileRow = _mediaDataGridView.SelectedRows[0].Index;

                //parse selected playlist, selected media row and checkedCategories to method
                _categoryService.AssignCategoriesToMediaFile(selectedMediaFileRow, selectedPlaylist, checkedCategories);
                _mediaDataGridView.Refresh();
                checkedCategoryBox.ClearSelected();
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
