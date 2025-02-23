using PagePortServer.Models;

namespace PagePortServer.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);

        Category AddCategory(Category category);

        Category UpdateCategory(int id, Category category);

        bool DeleteCategory(int id);

        IEnumerable<Book> GetCategoryBooks(int categoryId);
    }

    public class CategoryService : ICategoryService
    {
        private static List<Category> _categories = new List<Category>();
        private static int _nextID = 1;

        public IEnumerable<Category> GetCategories() => _categories;

        public Category GetCategory(int id)
        {
            var category = _categories[id];
            return category;
        }


        public Category AddCategory(Category category)
        {
            category.Id = _nextID++;
            _categories.Add(category);
            return category;
        }

        public Category UpdateCategory(int id, Category category)
        {
            var existingCategory = GetCategory(id);
            if (existingCategory == null)
                return null;

            // Remove existing
            _categories.Remove(existingCategory);

            // Create new category with existing ID
            var updatedCategory = new Category
            {
                Id = id,
                Name = category.Name // Assuming your property is named 'Ad'
            };

            // Add updated category
            _categories.Add(updatedCategory);

            return updatedCategory;
        }

        public bool DeleteCategory(int id)
        {
            var existingCategory = GetCategory(id);
            if (existingCategory == null) return false;
            _categories.Remove(existingCategory);
            return true;
        }

        public IEnumerable<Book> GetCategoryBooks(int categoryId)
        {
            var bookService = new BookService();
            return bookService.GetAllBooks().Where(b => b.CategoryId == categoryId);
        }

    }

}
