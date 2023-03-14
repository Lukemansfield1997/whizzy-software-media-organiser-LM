using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whizzy_software_media_organiser_LM.Models;

namespace whizzy_software_media_organiser_LM.Services
{
    public class CategoryService
    {
        private List<Category> _allCategories;
        private JsonDataStoreService _jsonDataStoreService;

        public CategoryService()
        {
            _jsonDataStoreService = new JsonDataStoreService();
            _allCategories = new List<Category>();
        }

        public void CreateCategory(string categoryName)
        {
            _allCategories.Add(new Category
            {
                CategoryId = _allCategories.Count,
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
        }

        public Category GetCategoryById(int id)
        {
            // will iterate through the playlist list and find a playlist that matches the playlist id parsed
            return _allCategories.SingleOrDefault(i => i.CategoryId == id);
        }


    }
}
