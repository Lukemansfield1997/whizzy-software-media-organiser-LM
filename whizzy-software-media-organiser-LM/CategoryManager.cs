using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
                MessageBox.Show($"Categories have been assigned to media file: {selectedPlaylist.MediaFileItems[selectedMediaFileRow].Song}");                  
                checkedCategoryBox.ClearSelected();
            }
        }

        private void btnRenameCategory_Click(object sender, EventArgs e)
        {
            var selectedPlaylist = (Playlist)_playistBox.SelectedItem;
            var selectedCategory = (Category)checkedCategoryBox.SelectedItem;

            string oldCategoryName = selectedCategory.CategoryName;

            //if block will check if selected item is null or selected item checkbox state is unchecked, if true prompt user to check valid category
            if (checkedCategoryBox.SelectedItem == null || checkedCategoryBox.GetItemCheckState(checkedCategoryBox.SelectedIndex) == CheckState.Unchecked)
            {
                MessageBox.Show("Please check a valid category to rename");
            }
            else
            {
                bool categoryNameExists = true;

                while (categoryNameExists)
                {
                    string newCategoryName = Interaction.InputBox("Enter a new category name", "Rename Category");

                    //Check if newCategoryName entered is null
                    switch (string.IsNullOrEmpty(newCategoryName))
                    {
                        //if true, display message box showing the error
                        case true:
                            MessageBox.Show("Error occured: Category name cannot be empty, please try again.");
                            categoryNameExists = false;
                            break;

                        //if false but the category name exists in allCategories using Linq, display message box showing the error
                        case false:
                            if (_categoryService.GetCategories().Any(c => c.CategoryName == newCategoryName))
                            {
                                MessageBox.Show("Error occured: Category name already exists, please try again.");
                                categoryNameExists = true;
                            }
                            else
                            {
                                //rename categoryName instance
                                _categoryService.RenameCategory(selectedCategory, newCategoryName);

                                //use foreach loop to check for every media row if old category name has been assigned
                                //if it results to true, it will replace media files old category name with new category name
                                //so it matches Category Manager items list
                                foreach (DataGridViewRow row in _mediaDataGridView.Rows)
                                {
                                    foreach (DataGridViewCell oldCat in row.Cells)
                                    {
                                        if (oldCat.Value != null && oldCat.Value.ToString() == oldCategoryName)
                                        {
                                            oldCat.Value = selectedCategory.CategoryName;
                                        }
                                    }
                                }
                                _mediaDataGridView.Refresh();
                                UpdateCategoryManagerDataSource();
                                MessageBox.Show($"Category: {oldCategoryName} has been renamed to {newCategoryName}");
                                categoryNameExists = false;
                            }
                            break;
                    }
                }
            }
        }

        private void btnDeleteCategories_Click(object sender, EventArgs e)
        {

        }
    }
}
