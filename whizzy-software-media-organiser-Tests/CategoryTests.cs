
namespace whizzy_software_media_organiser_Tests
{
    public class CategoryTests
    {
        CategoryServiceJsonDataStore _categoryService;

        [SetUp]
        public void Setup()
        {
            _categoryService = new CategoryServiceJsonDataStore();
        }

        [Test]
        public void CategoryIsCreated()
        {
            //Arrange
            string categoryName = "cat 1";

            //Act
            _categoryService.CreateCategory(categoryName);

            //Assert
            Assert.That(_categoryService.GetCategories().Count, Is.EqualTo(1));
        }
        

        [Test]
        public void CategoryIsDeleted()
        {
            //Arrange
            string categoryName = "cat 1";

            //Act
            _categoryService.CreateCategory(categoryName);
            var deleteCategory = _categoryService.GetCategories().FirstOrDefault(c => c.CategoryName == categoryName);
            _categoryService.DeleteCategory(deleteCategory.CategoryID);

            //Assert
            Assert.That(_categoryService.GetCategories().Count, Is.EqualTo(0));
        }

        [Test]
        public void CategoryIsRenamed()
        {
            //Arrange
            string categoryName = "cat 1";
            string newCatName = "cat renamed";
            //Act
            _categoryService.CreateCategory(categoryName);
            _categoryService.RenameCategory(_categoryService.GetCategories().FirstOrDefault(c => c.CategoryName == categoryName), newCatName);

            //Assert
            Assert.That(_categoryService.GetCategories()[0].CategoryName, Is.EqualTo(newCatName));
        }
    }
}