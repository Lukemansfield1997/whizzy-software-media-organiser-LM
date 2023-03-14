using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whizzy_software_media_organiser_LM.Models;

namespace whizzy_software_media_organiser_LM.Services
{
    public class CategoryServiceJsonDataStore
    {
        private List<Category> _allCategories;
        private JsonDataStoreService _jsonDataStoreService;

        public CategoryServiceJsonDataStore()
        {
            _jsonDataStoreService = new JsonDataStoreService();
            _allCategories = new List<Category>();
        }

        public void CreateCategory(string categoryName)
        {
            _allCategories.Add(new Category
            {
                CategoryID = _allCategories.Count,
                CategoryName = categoryName
            });
        }

        public void RenameCategory (Category category, string categoryName)
        {
            category.CategoryName = categoryName;
        }

        public void DeleteCategory(int categoryID)
        {
            _allCategories.Remove(GetCategoryById(categoryID));
            _jsonDataStoreService.DeleteCategory(categoryID);   
        }

        public Category GetCategoryById(int id)
        {
            // will iterate through the playlist list and find a playlist that matches the playlist id parsed
            return _allCategories.SingleOrDefault(i => i.CategoryID == id);
        }

        public List<Category> GetCategories()
        {
            return _allCategories;
        }

        public void SaveCategories()
        {
            _jsonDataStoreService.SaveCategories(_allCategories);
        }

        public void LoadCategories()
        {
            _jsonDataStoreService.LoadCategories(_allCategories);
        }

        public void AssignCategoriesToMediaFile(int selectedMediaRow, Playlist selectedPlaylist, List<Category> selectedCategories)
        {
            //statement checks selected media row is greater or equal 0, indicates row is selected in grid view
            //then checks selectedMediaRow is less than total playlist media file items list count to validate index is in range
            if (selectedMediaRow >= 0 && selectedMediaRow < selectedPlaylist.MediaFileItems.Count)
            {
                //finds the media file selected in the playlist media files by using the selected index of the media file row
                var mediaFile = selectedPlaylist.MediaFileItems[selectedMediaRow];

                //add categories to mediaFile item categories list
                mediaFile.CategoriesList.AddRange(selectedCategories);
            }

        }
    }
}
